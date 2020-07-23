using System;

namespace Desktop.Win.Data.Migration
{
    public class MigrationsHistory : IEquatable<MigrationsHistory>
    {
        public const byte IndexNumber = 0;
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime DataCreated { get; set; }

        public string CreateScript => $"INSERT INTO MigrationsHistory ({nameof(Number)}, {nameof(Name)}, {nameof(DataCreated)}) VALUES({Number}, '{Name}', datetime());";
        public static string CreateTable = "Create table [MigrationsHistory]([Id] integer primary key,[Number] [int] not null,[Name] [nvarchar(max)] not null,[DataCreated] [datetime2] not null)";

        public bool Equals(MigrationsHistory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MigrationsHistory) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Number, Name);
        }
    }

    public class FileInfo : MigrationsHistory
    {
        public string FullPatch { get; set; }
    }
}
