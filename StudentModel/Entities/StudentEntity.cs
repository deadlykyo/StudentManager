using StudentModel.Interfaces;
using System;
using System.Text;

namespace StudentModel.Entities
{
    public class StudentEntity : IEntity
    {
        public string Stage { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime LastUpdated { get; set; }

        public StudentEntity()
        {
            Stage = String.Empty;
            Gender = String.Empty;
            Name = String.Empty;
            LastUpdated = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        public StudentEntity(string stage, string name, string gender, DateTime lastUpdated)
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
}
