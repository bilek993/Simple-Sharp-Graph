using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using QuickGraph;

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
            using (var stream = new StreamReader(_pathToFile))
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
            var vertexesList = new List<string>();
            var regex = new Regex("\\.[a-zA-Z0-9]+");

            foreach (var line in _fileData)
            {
                foreach (Match matchedRegex in regex.Matches(line))
                {
                    vertexesList.Add(matchedRegex.Value.Replace(".", ""));
                }
            }

            return vertexesList;
        }

        public List<Edge<object>> GenerateEdges()
        {
            var edgesList = new List<Edge<object>>();
            var regex = new Regex("([a-zA-Z0-9]+)\\-\\>([a-zA-Z0-9]+)");

            foreach (var line in _fileData)
            {
                foreach (Match matchedRegex in regex.Matches(line))
                {
                    var source = matchedRegex.Groups[1].Value;
                    var target = matchedRegex.Groups[2].Value;

                    edgesList.Add(new Edge<object>(source, target));
                }
            }

            return edgesList;
        }
    }
}
