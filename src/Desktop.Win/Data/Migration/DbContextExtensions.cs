using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Desktop.Win.Data.Migration
{
    public static class DbContextExtensions
    {
        public static void Migrate(this DbContext context)
        {
            //TODO TimeOut
            if (context.Database.EnsureCreated())
                context.FirstRun();
            else
                context.Restart();
        }

        public static void FirstRun(this DbContext context)
        {
            HashSet<MigrationsHistory> migrationsHistoriesFromFiles = context.GetMigrationsHistoriesFromFiles();
            if (migrationsHistoriesFromFiles.Count > 0)
                context.Database.ExecuteSqlRaw(string.Concat(migrationsHistoriesFromFiles.Select(x => $"{x.CreateScript}")));
        }

        public static void Restart(this DbContext context)
        {
            HashSet<MigrationsHistory> migrationsHistoriesFromFiles = context.GetMigrationsHistoriesFromFiles();
            if (migrationsHistoriesFromFiles.Count > 0)
            {
                var migrationsHistoriesFromDb = context.Set<MigrationsHistory>().ToArray();
                if (migrationsHistoriesFromFiles.Count != migrationsHistoriesFromDb.Length)
                {
                    migrationsHistoriesFromFiles.ExceptWith(migrationsHistoriesFromDb);
                    if (migrationsHistoriesFromFiles.Count > 0)
                        context.Database.ExecuteSqlRaw(string.Concat(migrationsHistoriesFromFiles.Select(x => $"{File.ReadAllText(x.FullPatch)} {x.CreateScript}")));
                }
            }
        }

        public static HashSet<MigrationsHistory> GetMigrationsHistoriesFromFiles(this DbContext context)
        {
            return Directory.EnumerateFiles(Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Sql"), "*.sql", SearchOption.AllDirectories)
                .Select(x => new MigrationsHistory(int.Parse(Path.GetFileName(x).Split('_')[MigrationsHistory.IndexNumber]), Path.GetFileName(x))
                {
                    FullPatch = Path.GetFullPath(x),
                }).ToHashSet();
        }
    }
}