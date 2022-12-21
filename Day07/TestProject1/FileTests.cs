using File = Day07.Filesystem.File;
using Directory = Day07.Filesystem.Directory;

namespace TestProject1
{
    public class FileTests
    {
        [Test]
        public void File_NameAndSize_AreAsAssigned()
        {
            var file = new File("testfile", 42);

            Assert.Multiple(() =>
            {
                Assert.That(file.Name, Is.EqualTo("testfile"));
                Assert.That(file.Size, Is.EqualTo(42));
            });
        }

        [Test]
        public void Directory_Size_Is_Sum_Of_All_Contents()
        {
            var subdir = new Directory("subdir");
            subdir.Add(new File("File C", 3));
            subdir.Add(new File("File D", 3));

            var dir = new Directory("dir");
            dir.Add(new File("File A", 1));
            dir.Add(new File("File B", 2));
            dir.Add(subdir);

            Assert.Multiple(() =>
            {
                Assert.That(subdir.Size, Is.EqualTo(6));
                Assert.That(dir.Size, Is.EqualTo(9));
            });
        }
    }
}