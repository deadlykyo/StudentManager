using StudentModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProcessor.Interfaces
{
    public interface IReadFromFile
    {
        List<StudentEntity> ReadRecords(string filePath);
    }
}
