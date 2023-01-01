using Day10.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tests
{
    internal class CpuTests
    {
        [Test]
        public void TestFile_ProcessesCorrectly()
        {
            var cpu = new Cpu(@"TestInput\TinyProgram.txt");
            cpu.RunProgram();

            Assert.That(cpu.CurrentCycle, Is.EqualTo(6));
            Assert.That(cpu.X, Is.EqualTo(-1));
        }

        [Test]
        public void Execute_TakesTwoCycles_ToComplete_First_Addx_Instruction()
        {
            var cpu = new Cpu(@"TestInput\TinyProgram.txt");

            cpu.CycleOnce();
            cpu.CycleOnce();

            Assert.That(cpu.CompletedInstructions.Any(c => c is AddInstruction), Is.False);

            cpu.CycleOnce();

            AddInstruction inst = (AddInstruction)cpu.CompletedInstructions.Single(c => c is AddInstruction);

            Assert.Multiple(() =>
            {
                Assert.That(inst.Register, Is.EqualTo(Registers.X));
                Assert.That(cpu.X, Is.EqualTo(4));
            });
        }

        [Test]
        public void Execute_Completes_Noop_Instruction_After_One_Cycle()
        {
            var cpu = new Cpu(@"TestInput\TinyProgram.txt");
            cpu.CycleOnce();
            Assert.Multiple(() =>
            {
                Assert.That(cpu.X, Is.EqualTo(1));
                Assert.That(cpu.CompletedInstructions.Single(c => c is NoopInstruction), Is.InstanceOf<NoopInstruction>());
                Assert.That(cpu.CompletedInstructions.Any(c => c is AddInstruction), Is.False);
            });
        }

        public void CycleOnce_IncrementsCycleCounter_ByOne()
        {
            var cpu = new Cpu(@"TestInput\TinyProgram.txt");
            cpu.CycleOnce();
            cpu.CycleOnce();
            cpu.CycleOnce();
            cpu.CycleOnce();
            cpu.CycleOnce();

            Assert.That(cpu.CurrentCycle, Is.EqualTo(5));
        }
    }
}
