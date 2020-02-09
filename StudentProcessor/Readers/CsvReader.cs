using StudentModel.Entities;

using StudentProcessor.Interfaces;
using StudentProcessor.Tools;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentProcessor.Readers
{
    public class CsvReader : IReadFromFile
    {
        public char Separator { get; set; } = ',';

        public List<StudentEntity> ReadRecords(string filePath)
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                List<StudentEntity> students = new List<StudentEntity>();
                StudentEntity student;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var studentDataArray = line.Split(Separator);

                    if (studentDataArray.Length == 4)
                    {
                        var stage = studentDataArray[0];
                        var gender = studentDataArray[2];
                        var lastModifiedDate = FieldParser.ConvertToDate(studentDataArray[3]);
                        student = new StudentEntity(stage, studentDataArray[1], gender, lastModifiedDate);
                        students.Add(student);
                    }
                }
                return students;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ReadRecords:" + ex.Message + ex.StackTrace);
            }
        }


    }
}
