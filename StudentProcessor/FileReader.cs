using StudentModel.Entities;
using StudentProcessor.Interfaces;
using System.Collections.Generic;

namespace StudentProcessor
{
    public class FileReader
    {
        private string _filePath = string.Empty;
        private IReadFromFile _reader;

        public void SetReader(IReadFromFile reader)
        {
            _reader = reader;
        }

        public void SetFileName(string filePath)
        {
            _filePath = filePath;
        }

        public List<StudentEntity> ReadRecords()
        {
            var results = _reader.ReadRecords(_filePath);
            return results;
        }
    }
}
