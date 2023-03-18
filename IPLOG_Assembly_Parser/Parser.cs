namespace IPLOG_Assembly_Parser
{
    internal class Parser
    {
        private string pathToFile;
        List<string> lines = new();
        SortedDictionary<string, Dictionary<string, int>> IO = new();

        public Parser(string pathToFile)
        {
            this.pathToFile = pathToFile;
            FileRead();
            Parse();
        }

        private void FileRead()
        {
            try
            {
                StreamReader sr = new(pathToFile);
                while (sr.ReadLine() != null)
                {
                    lines.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private void Parse()
        {
            List<string> trimmedLines = new();
            List<string> cutLines = new();
            List<string> distinctLines = new();

            for (int index = 0; index < lines.Count; index++)
            {
                if (lines[index].Length > 9)
                {
                    trimmedLines.Add(lines[index].Remove(0, 6));
                }
            }
            for (int index = 0; index < trimmedLines.Count; index++)
            {
                if (trimmedLines[index].Contains("/if/i/") || trimmedLines[index].Contains("/if/o/"))
                {
                    cutLines.Add(trimmedLines[index].Remove(FindNextChar('/', 11, trimmedLines[index])));
                }
                else if (trimmedLines[index].Contains("/o/") || trimmedLines[index].Contains("/i/"))
                {
                    cutLines.Add(trimmedLines[index].Remove(FindNextChar('/', 7, trimmedLines[index])));
                }
            }
            distinctLines.AddRange(cutLines.Distinct());
            for (int addressIndex = 0; addressIndex < 33; addressIndex++)
            {
                for (int lineIndex = 0; lineIndex < distinctLines.Count; lineIndex++)
                {
                    if (distinctLines[lineIndex].Contains(addressIndex.ToString("d3")))
                    {
                        if (!IO.ContainsKey(addressIndex.ToString()))
                        {
                            IO.Add(addressIndex.ToString(),
                                new Dictionary<string, int>{ {"i", 0}, {"o", 0}, {"if/i", 0}, {"if/o", 0} });
                        }
                        if (distinctLines[lineIndex].Contains("if/o/"))
                        {
                            IO[addressIndex.ToString()]["if/o"]++;
                        }
                        else if (distinctLines[lineIndex].Contains("/o/"))
                        {
                            IO[addressIndex.ToString()]["o"]++;
                        }
                        else if (distinctLines[lineIndex].Contains("/if/i/"))
                        {
                            IO[addressIndex.ToString()]["if/i"]++;
                        }
                        else if (distinctLines[lineIndex].Contains("/i/"))
                        {
                            IO[addressIndex.ToString()]["i"]++;
                        }
                    }
                }
            }
        }

        private static int FindNextChar(char character, int startPosition, string whereToSearch)
        {
            if (whereToSearch.IndexOf(character, startPosition) == -1)
            {
                return whereToSearch.Length;
            }
            else
            {
                return whereToSearch.IndexOf(character, startPosition);
            }
        }

        internal List<IOModule> ConvertIOToIPLOG()
        {
            List<IOModule> root = new();
            for (int index = 0; index < IO.Count; index++)
            {
                root.Add(new IOModule(index,
                                      IO[index.ToString()]["i"] + IO[index.ToString()]["if/i"],
                                      IO[index.ToString()]["o"] + IO[index.ToString()]["if/o"],
                                      new IFModule(IO[index.ToString()]["if/i"],
                                                   IO[index.ToString()]["if/o"])));
            }

            return root;
        }
    }
}
