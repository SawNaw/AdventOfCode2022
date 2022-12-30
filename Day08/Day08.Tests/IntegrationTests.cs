using Day08.Trees;

namespace Day08.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void TopLeft_5_IsVisible_From_Left_And_Top()
        {
            var forest = new Forest(@"testinput.txt");

            Assert.Multiple(
                () => Assert.True(forest.IsVisibleFromLeft(1, 1)),
                () => Assert.True(forest.IsVisibleFromTop(1, 1))
            );
        }

        [Fact]
        public void TopLeft_5_Is_NotVisible_From_Right_Or_Bottom()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.False(forest.IsVisibleFromRight(1, 1)),
                () => Assert.False(forest.IsVisibleFromBottom(1, 1))
            );
        }

        [Fact]
        public void TopMiddle_5_IsVisible_From_Top_And_Right()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.True(forest.IsVisibleFromRight(2, 1)),
                () => Assert.True(forest.IsVisibleFromTop(2, 1))
            );
        }

        [Fact]
        public void TopRight_1_Is_Not_Visible_From_Any_Direction()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.False(forest.IsVisibleFromRight(3, 1)),
                () => Assert.False(forest.IsVisibleFromBottom(3, 1)),
                () => Assert.False(forest.IsVisibleFromLeft(3, 1)),
                () => Assert.False(forest.IsVisibleFromTop(3, 1))
            );
        }

        [Fact]
        public void Left_Middle_5_IsVisible_Only_From_Right()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.True(forest.IsVisibleFromRight(1, 2)),
                () => Assert.False(forest.IsVisibleFromBottom(1, 2)),
                () => Assert.False(forest.IsVisibleFromLeft(1, 2)),
                () => Assert.False(forest.IsVisibleFromTop(1, 2))
            );
        }

        [Fact]
        public void Center_3_Is_Not_Visible_From_Any_Direction()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.False(forest.IsVisibleFromRight(2, 2)),
                () => Assert.False(forest.IsVisibleFromLeft(2, 2)),
                () => Assert.False(forest.IsVisibleFromBottom(2, 2)),
                () => Assert.False(forest.IsVisibleFromTop(2, 2))
            );
        }

        [Fact]
        public void RightMiddle_3_IsVisible_From_Right()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.True(forest.IsVisibleFromRight(3, 2)),
                () => Assert.False(forest.IsVisibleFromLeft(3, 2)),
                () => Assert.False(forest.IsVisibleFromTop(3, 2)),
                () => Assert.False(forest.IsVisibleFromBottom(3, 2))
            );
        }

        [Fact]
        public void In_BottomRow_5_IsVisible_But_Not_3_And_4()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Multiple(
                () => Assert.True(forest.IsVisibleFromLeft(2, 3)),
                () => Assert.True(forest.IsVisibleFromBottom(2, 3)),
                () => Assert.False(forest.IsVisibleFromRight(2, 3)),
                () => Assert.False(forest.IsVisibleFromTop(2, 3))
            );
        }

        [Fact]
        public void Number_Of_Visible_Trees_In_TestInput_Is_21()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Equal(21, forest.GetNumberOfVisibleTrees());
        }

        [Fact]
        public void Total_Scenic_Score_For_Middle_5_In_Second_Row_Is_4()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Equal(4, forest.GetTotalScenicScore(2, 1));
        }

        [Fact]
        public void Highest_Scenic_Score_For_Test_Input_Equals_8()
        {
            var forest = new Forest(@"testinput.txt");
            Assert.Equal(8, forest.FindHighestScenicScore());
        }
    }
}