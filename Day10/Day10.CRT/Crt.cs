namespace Day10.CRT
{
    public class Crt
    {
        private readonly List<List<char>> pixelArray = new();
        private List<char> pixelLine = new(40);
        public Crt()
        {

        }

        /// <summary>
        /// Records a light or dark pixel depending on the value of the given X register.
        /// </summary>
        /// <param name="currentCycle">The current cycle number.</param>
        /// <param name="xRegisterValue">The value of the CPU's X register.</param>
        /// <returns>The pixel that was recorded, represented as a character.</returns>
        public char RecordPixel(int currentCycle, int xRegisterValue)
        {
            int position = currentCycle - 1;
            char pixelToRecord = CurrentPixelIsWithinSprite(position, xRegisterValue) ? '#' : '.';
            pixelLine.Add(
                CurrentPixelIsWithinSprite(position, xRegisterValue) ? '#' : '.'
                );

            if (pixelLine.Count == 40)
            {
                pixelArray.Add(pixelLine);
                pixelLine = new List<char>();
            }

            return pixelToRecord;
        }

        public void DrawImage()
        {
            foreach (var line in pixelArray)
            {
                foreach (var pixel in line)
                {
                    Console.Write(pixel);
                }
                Console.WriteLine();
            }
        }

        private static bool CurrentPixelIsWithinSprite(int position, int xRegisterValue)
        {
            if (position >= 40)
            {
                position %= 40;
            }
            return Math.Abs(xRegisterValue - position) <= 1;
        }
    }
}