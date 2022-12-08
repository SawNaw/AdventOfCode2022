using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Core
{
    internal static class Priority
    {
        private static readonly Dictionary<char, int> lettersAndPriorities = new();
        static Priority()
        {
            InitializeLetterToPriorityLookup();
        }
        public static int GetPriority(char letter)
        {
            return lettersAndPriorities[letter];
        }

        private static void InitializeLetterToPriorityLookup() 
        {
            int i = 1;
            // Add priorities for 'a' through 'z'
            for (char c = 'a'; c <= 'z'; c++, i++) 
            {
                lettersAndPriorities.Add(c, i);
            }
            // Add priorities for 'A' through 'Z'
            for (char c = 'A'; c <= 'Z'; c++, i++)
            {
                lettersAndPriorities.Add(c, i);
            }
        }
    }
}
