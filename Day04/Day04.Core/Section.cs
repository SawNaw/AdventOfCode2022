namespace Day04.Core
{
    internal class Section
    {
        public int Start { get; }
        public int End { get; }
        public Section(int start, int end) => (Start, End) = (start, end);

        /// <example>
        /// The range 2-6 fully contains 3-5.
        /// The range 2-6 does not fully contain 4-7, though there is overlap.
        /// </example>
        public bool FullyContains(Section otherSection)
        {
            return (this.Start <= otherSection.Start
                 && this.End >= otherSection.End);
        }

        /// <example>
        /// The range 2-6 overlaps 6-8.
        ///    .23456..
        ///    .....678
        ///    
        /// The range 4-6 overlaps 2-5.
        ///    ...456..
        ///    .2345...
        ///    
        /// The range 2-6 overlaps 3-5, and also fully contains it.
        ///    .23456..
        ///    ..345...
        /// 
        /// The range 2-6 overlaps 4-6, and also fully contains it.
        ///    .23456..
        ///    ...456..
        /// </example>
        public bool Overlaps(Section otherSection)
        {
            return FullyContains(otherSection)
                || (this.End >= otherSection.Start && this.End <= otherSection.End)
                || (this.Start >= otherSection.Start && this.Start <= otherSection.End);
        }
    }
}
