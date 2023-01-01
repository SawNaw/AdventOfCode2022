﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Day10.CPU
{
    /// <summary>
    /// Represents the CPU for this puzzle.
    /// </summary>
    internal class Cpu
    {
        private readonly string[] inputFileContents;
        private readonly Queue<QueuedInstruction> instructionPipeline = new();
        private QueuedInstruction currentItem;
        internal int CurrentCycle = 1;
        internal List<int> SignalStrengths { get; } = new();
        internal List<Instruction> CompletedInstructions { get; } = new();

        /// <summary>
        /// The current value of the X register.
        /// </summary>
        internal int X { get; private set; } = 1;

        internal Cpu(string filePath)
        {
            inputFileContents = File.ReadAllLines(filePath);
            LoadInstructionsIntoPipeline();
            currentItem = instructionPipeline.Dequeue();
        }

        internal void RunProgram()
        {
            while (instructionPipeline.Any() || currentItem.ExecutionTimer > 0)
            {
                CycleOnce();
            }
        }

        internal void CycleOnce()
        {
            RecordSignalStrength();
            --currentItem.ExecutionTimer;

            if (currentItem.ExecutionTimer == 0)
            {
                CompleteCurrentInstruction();
                if (instructionPipeline.Any())
                {
                    currentItem = instructionPipeline.Dequeue();
                }
            }

            CurrentCycle++;
        }
        private void RecordSignalStrength()
        {
            SignalStrengths.Add(CurrentCycle * X);
        }

        private void CompleteCurrentInstruction()
        {
            if (currentItem.Instruction is AddInstruction inst)
            {
                switch (inst.Register)
                {
                    case Registers.X:
                        X += inst.Value;
                        break;

                    default:
                        throw new NotImplementedException($"AddInstruction for Register {inst.Register} is not implemented.");
                }
            }

            CompletedInstructions.Add(currentItem.Instruction);
        }

        private void LoadInstructionsIntoPipeline()
        {
            for (int i = 0; i < inputFileContents.Length; i++)
            {
                if (inputFileContents[i] == "noop")
                {
                    instructionPipeline.Enqueue(new QueuedInstruction(new NoopInstruction(), 1));
                }
                else if (inputFileContents[i].StartsWith("add"))
                {
                    var addInstruction = ParseAddInstruction(inputFileContents[i]);
                    instructionPipeline.Enqueue(new QueuedInstruction(addInstruction, 2));
                }
            }
        }

        private static AddInstruction ParseAddInstruction(string line)
        {
            var splitLine = line.Split(' ');
            if (splitLine.First() == "addx")
            {
                return new AddInstruction(Registers.X, int.Parse(splitLine[1]));
            }

            throw new ArgumentException($"{line} is not a valid add instruction.", nameof(line));
        }
    }
}
