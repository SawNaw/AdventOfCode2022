namespace Day08.Forestry
{
    internal class Tree
    {
        public double Height { get; }
        public Tree(double height)
        {
            if (height < 0 || height > 9)
            {
                throw new ArgumentException($"Height must be between 0 and 9 inclusive.", nameof(height));
            }

            this.Height = height;
        }
    }
}
