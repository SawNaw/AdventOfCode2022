﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Core
{
    internal class FileReader
    {
        public string[] Contents { get; }
        public FileReader(string filepath)
        {
            Contents = File.ReadAllLines(filepath);
        }
        public IEnumerable<LineOfCrates> GetLinesOfCratesFromFile()
        {
            List<LineOfCrates> list = new();

            foreach(var line in Contents)
            {
                if (line[1] == '1') // this means we've reached the end of the list of crates
                {
                    break;
                }

                list.Add(new LineOfCrates(line));
            }

            return list;
        }
    }
}
