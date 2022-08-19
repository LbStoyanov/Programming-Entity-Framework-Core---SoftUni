using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Villain_Names.IO
{
    public class SQLReader : IReader
    {
        public SQLReader(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; }
        public string ReadFile()
        {
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(currentDirectoryPath, $"/../Queries/${this.FileName}.sql");

            string query = File.ReadAllText(fullPath);
            return query;
        }
    }
}
