using ConsoleStudent;
using StudentModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            List<StudentEntity> results = new List<StudentEntity>();
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("No parameters found, please set CSV file path.");
                    break;
                case 1:
                    results = manager.LoadRecordsFromFile(args[0]);
                    manager.DisplayRecords(results);
                    break;
                default:
                    manager.SetFilters(args.Skip(1).ToList());
                    results = manager.LoadRecordsFromFile(args[0]);
                    manager.DisplayRecords(results);
                    break;
            }

            Console.WriteLine("Click any key to end the execution.");
            Console.ReadKey();
        }
    }
}
