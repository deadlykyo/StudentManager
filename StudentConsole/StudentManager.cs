using StudentModel.Entities;
using StudentProcessor;
using StudentProcessor.Exceptions;
using StudentProcessor.Extensions;
using StudentProcessor.Readers;
using StudentProcessor.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleStudent
{
    public class StudentManager
    {
        private List<KeyValuePair<string, object>> _filters = new List<KeyValuePair<string, object>>();
        private List<string> _sortByColumns = new List<string>();

        internal List<StudentEntity> LoadRecordsFromFile(string filePath)
        {
            try
            {
                List<StudentEntity> result = new List<StudentEntity>();

                if (File.Exists(filePath))
                {
                    FileReader reader = new FileReader();
                    reader.SetReader(new CsvReader());
                    reader.SetFileName(filePath);
                    result = reader.ReadRecords();
                }
                return result;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error loading records from CSV '{filePath}'";
                throw new StudentException(errorMessage, ex);
            }
        }

        internal void DisplayRecords(List<StudentEntity> results)
        {
            try
            {
                //Filtering data before display it
                if (_filters != null && _filters.Count > 0)
                    results = results.Where(_filters).ToList();

                //Sorting data before display it
                if (_sortByColumns != null && _sortByColumns.Count > 0)
                    results = results.SortBy(_sortByColumns).ToList();

                foreach (var entity in results)
                {
                    Console.WriteLine(entity.ToString());
                }

            }
            catch (Exception ex)
            {
                string errorMessage = $"Error displaying records from the list of students.";
                throw new StudentException(errorMessage, ex);
            }
        }

        internal void SetFilters(List<string> csvFilters)
        {
            try
            {
                KeyValuePair<string, object> filterDefinition = new KeyValuePair<string, object>();
                _sortByColumns = new List<string>();

                foreach (var filter in csvFilters)
                {
                    var filterProps = filter.Split('=');

                    switch (filterProps[0].ToLower())
                    {
                        case "gender":
                            _sortByColumns.Add("LastUpdated|1");
                            filterDefinition = new KeyValuePair<string, object>(filterProps[0], filterProps[1]);
                            break;
                        case "stage":
                            _sortByColumns.Add("LastUpdated|1");
                            filterDefinition = new KeyValuePair<string, object>(filterProps[0], filterProps[1]);
                            break;
                        case "lastupdated":
                            _sortByColumns.Add("LastUpdated|0");
                            filterDefinition = new KeyValuePair<string, object>(filterProps[0], FieldParser.ConvertToDate(filterProps[1]));
                            break;
                        default:
                            _sortByColumns.Add("Name");
                            filterDefinition = new KeyValuePair<string, object>(filterProps[0], filterProps[1]);
                            break;
                    }

                    var filterProp = new KeyValuePair<string, object>(filterProps[0], filterProps[1]);

                    _filters.Add(filterProp);
                }

            }
            catch (Exception ex)
            {
                string errorMessage = $"Error setting filters for the list of students.";
                throw new StudentException(errorMessage, ex);
            }
        }
    }
}
