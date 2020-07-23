using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Desktop.Win.Data.Migration
{
    public static class DbContextExtensions
    {
        public static void Migrate(this DbContext context)
        {
            ///TODO TimeOut
            try
            {
                //TODO Как проверить существует ли таблица миграции??
                context.Database.ExecuteSqlRaw(MigrationsHistory.CreateTable);
                context.Database.ExecuteSqlRaw(string.Concat(Directory
                    .EnumerateFiles(
                        Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Sql"),
                        "*.sql", SearchOption.AllDirectories)
                    .AsParallel()
                    .WithDegreeOfParallelism(2)
                    .Select(x => new FileInfo
                    {
                        Name = Path.GetFileName(x),
                        FullPatch = Path.GetFullPath(x),
                        Number = int.Parse(Path.GetFileName(x).Split('_')[MigrationsHistory.IndexNumber])
                    })
                    .Except(context.Set<MigrationsHistory>().ToList())
                    .Select(x => $"{File.ReadAllText(((FileInfo) x).FullPatch)} {x.CreateScript}")));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}