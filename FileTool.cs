using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Simple_Sharp_Graph
{
    class FileTool
    {
        private readonly string _pathToFile;
        private List<string> _fileData;

        public FileTool(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void OpenFile()
        {
            using (StreamReader stream = new StreamReader(_pathToFile))
            {
                string line;
                _fileData = new List<string>();

                while ((line = stream.ReadLine()) != null)
                {
                    _fileData.Add(line);
                }
            }
        }

        public List<string> GenerateVertexes()
        {
            List<string> vertexesList = new List<string>();
            Regex regex = new Regex("(\\.[a-zA-Z0-9]+)");

            foreach (string line in _fileData)
            {
                foreach (Match matchedRegex in regex.Matches(line))
                {
                    vertexesList.Add(matchedRegex.Value);
                }
            }

            return vertexesList;
        }
    }
}
