using System;
using System.Collections.Generic;
using System.IO;

namespace samples_hatena.Services
{
    public class FileManager
    {
        public FileManager()
        {
        }

        public List<string> GetCsvData()
        {
            string filePath = @"/Users/tetsu/Projects/samples_hatena/samples_hatena/csv/kinki.csv";
            List<string> csvlist = new List<string>();

            StreamReader reader = new StreamReader(filePath);
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(",");


                    csvlist.AddRange(values);
                }
            }
            return csvlist;

        }

        
    }

}