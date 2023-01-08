using System.Security.Cryptography.X509Certificates;

namespace Day11.Framework
{
    public record class Test
    {
        public int Divisor { get; }
        public int TargetIfTrue { get; }
        public int TargetIfFalse { get; }

        public Test(int divisor, int targetIfTrue, int targetIfFalse)
        {
            Divisor = divisor;
            TargetIfTrue = targetIfTrue;
            TargetIfFalse = targetIfFalse;
        }

        public bool IsPass(int dividend)
        {
            return dividend % Divisor == 0;
        }
    }
}