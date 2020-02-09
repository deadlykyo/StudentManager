using StudentModel.Interfaces;
using System;
using System.Text;

namespace StudentModel.Entities
{
    public class StudentEntity : IEntity
    {
        public Stage Stage { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastUpdated { get; set; }

        public StudentEntity()
        {
            Stage = Stage.None;
            Name = String.Empty;
            LastUpdated = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        public StudentEntity(Stage stage, string name, Gender gender, DateTime lastUpdated)
        {
            Stage = stage;
            Name = name;
            Gender = gender;
            LastUpdated = lastUpdated;
        }

        public override string ToString()
        {
            string dateFormatted = LastUpdated.ToString("yyyyMMddHHmmss");

            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, ");
            sb.Append($"Stage: {Stage}, ");
            sb.Append($"Gender: {Gender}, ");
            sb.Append($"Last date Updated: {dateFormatted}");

            return sb.ToString();
        }

        public string ToCsvString()
        {
            string dateFormatted = LastUpdated.ToString("yyyyMMddHHmmss");
            string result = $"{Stage},{Name},{Gender},{dateFormatted}1";
            return result;
        }
    }

    public enum Gender
    {
        Male = 2,
        Female = 1
    }

    public enum Stage
    {
        None = 1,
        Elementary = 2,
        High = 3,
        Kinder = 4,
        University = 5
    }

}
