using StudentModel.Entities;
using StudentProcessor.Exceptions;
using StudentProcessor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentProcessor.Operations
{

    public class StudentOperation
    {
        private StudentEntity _student;
        public List<StudentEntity> Students { get; set; }

        public StudentOperation()
        {
            Students = new List<StudentEntity>();
        }

        public bool Create(string stage, string name, string gender, DateTime lastUpdated)
        {
            try
            {
                _student = new StudentEntity(stage, name, gender, lastUpdated);
                Students.Add(_student);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error creating a new student, with the next information: {_student.ToString()}";
                throw new StudentException(errorMessage, ex);
            }
        }

        public bool Delete()
        {
            try
            {
                if (_student != null && !string.IsNullOrEmpty(_student.Name))
                {
                    Students.Remove(_student);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error deleting student, with the next information: {_student.ToString()}";
                throw new StudentException(errorMessage, ex);
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public List<StudentEntity> Search(List<KeyValuePair<string, object>> filters)
        {
            return Students.Where(filters).ToList();
        }

        public List<StudentEntity> SortBy(List<string> sortColumns)
        {
            return Students.SortBy(sortColumns).ToList();
        }
    }
}
