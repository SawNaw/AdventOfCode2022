namespace Day03.Core
{
    internal static class Priority
    {
        private static readonly Dictionary<char, int> lettersAndPriorities = new();
        static Priority()
        {
            InitializeLetterToPriorityLookup();
        }

        internal static int GetPriority(char letter)
        {
            return lettersAndPriorities[letter];
        }

        internal static int GetSumOfPrioritiesOfAllThreeElfGroups(string filepath)
        {
            var file = File.ReadAllLines(filepath);
            List<Rucksack> threeRucksacks = new();
            int sum = 0;
            for (int i = 1; i <= file.Length; i++)
            {
                threeRucksacks.Add(new Rucksack(file[i - 1]));
                if (i % 3 == 0)
                {
                    sum += GetPriority(Rucksack.GetCommonItemInAllRucksacks(threeRucksacks));
                    threeRucksacks.Clear();
                }
            }

            return sum;
        }

        internal static int GetSumOfPrioritiesOfAllCommonItems(string filepath)
        {
            var file = File.ReadAllLines(filepath);
            int sum = 0;
            foreach (var line in file)
            {
                var sack = new Rucksack(line);
                sum += GetPriority(sack.GetCommonItem());
            }
            return sum;
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
