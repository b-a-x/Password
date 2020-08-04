using System;

namespace Desktop.Win.Data.Migration
{
    public class MigrationsHistory
    {
        public const byte IndexNumber = 0;
        protected MigrationsHistory()
        {
        }

        public MigrationsHistory(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime DataCreated { get; set; }
        public string FullPatch { get; set; }
        public string CreateScript => $"INSERT INTO MigrationsHistory ({nameof(Number)}, {nameof(Name)}, {nameof(DataCreated)}) VALUES({Number}, '{Name}', datetime());";
    }
}