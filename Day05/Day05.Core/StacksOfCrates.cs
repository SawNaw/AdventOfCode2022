﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Core
{
    internal class StacksOfCrates
    {
        public IReadOnlyCollection<Stack<char>> Content => _stacks;
        private readonly List<Stack<char>> _stacks = new();

        public StacksOfCrates(IEnumerable<LineOfCrates> linesOfCrates)
        {
            InitializeStacks(linesOfCrates.First().Content);
            PopulateStacks(linesOfCrates);
        }

        public void ExecuteInstruction(IEnumerable<MoveInstruction> instructions)
        {
            if (instructions.Any(i => i.NumberOfItemsToMove < 1))
            {
                throw new ArgumentException("Number of item items to move must be positive.");
            }

            foreach (var instruction in instructions) 
            {
                for (int i = 0; i < instruction.NumberOfItemsToMove; i++)
                {
                    var item = _stacks.ElementAt(instruction.Source - 1).Pop();
                    _stacks.ElementAt(instruction.Destination - 1).Push(item);
                }
            }
        }

        private void PopulateStacks(IEnumerable<LineOfCrates> linesOfCrates)
        {
            List<LineOfCrates> reversed = linesOfCrates.Reverse().ToList();

            foreach (var item in reversed)
            {
                for (int i = 0; i < reversed.Count(); i++)
                {
                    if (item.Content.ElementAt(i) != ' ')
                    {
                        _stacks.ElementAt(i).Push(item.Content.ElementAt(i));
                    }
                }
            }
        }

        private void InitializeStacks(IReadOnlyCollection<char> line)
        {
            // Add a stack for every item in the line
            foreach (var item in line)
            {
                _stacks.Add(new Stack<char>());
            }
        }
    }
}
