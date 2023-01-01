using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Tests
{
    internal class IntegrationTests
    {
        [Test]
        public void LargerTestInput_ProcessesCorrectly()
        {
            var cpu = new Cpu(@"TestInput\LargerProgram.txt");
            cpu.RunProgram();

            var signalStrength1 = cpu.SignalStrengths.ElementAt(19);
            var signalStrength2 = cpu.SignalStrengths.ElementAt(59);
            var signalStrength3 = cpu.SignalStrengths.ElementAt(99);
            var signalStrength4 = cpu.SignalStrengths.ElementAt(139);
            var signalStrength5 = cpu.SignalStrengths.ElementAt(179);
            var signalStrength6 = cpu.SignalStrengths.ElementAt(219);

            Assert.Multiple(() =>
            {
                Assert.That(signalStrength1, Is.EqualTo(420));
                Assert.That(signalStrength2, Is.EqualTo(1140));
                Assert.That(signalStrength3, Is.EqualTo(1800));
                Assert.That(signalStrength4, Is.EqualTo(2940));
                Assert.That(signalStrength5, Is.EqualTo(2880));
                Assert.That(signalStrength6, Is.EqualTo(3960));

                Assert.That(signalStrength1
                            + signalStrength2
                            + signalStrength3
                            + signalStrength4
                            + signalStrength5
                            + signalStrength6, Is.EqualTo(13140));
            });
            
        }
    }
}