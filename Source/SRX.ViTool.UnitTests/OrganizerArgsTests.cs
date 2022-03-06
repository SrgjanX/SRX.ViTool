//srgjanx

using NUnit.Framework;

namespace SRX.ViTool.UnitTests
{
    [TestFixture]
    internal class OrganizerArgsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Default_Values_With_Null_Args()
        {
            string[] args = null;
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix == false && oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_Empty_Args()
        {
            string[] args = new string[0];
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix == false && oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_Unsupported_Args()
        {
            string[] args = new string[]
            {
                "-something", "-else"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix == false && oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_DatePrefix_True()
        {
            string[] args = new string[]
            {
                "-dateprefix"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix);
        }

        [Test]
        public void Test_Default_Values_With_ViberDir_Empty1()
        {
            string[] args = new string[]
            {
                "-viberdir"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_ViberDir_Empty2()
        {
            string[] args = new string[]
            {
                "-viberdir "
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_ViberDir_Empty3()
        {
            string[] args = new string[]
            {
                "-viberdir         "
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == null);
        }

        [Test]
        public void Test_Default_Values_With_ViberDir_True()
        {
            string dir = "C:\\SomeFolder";
            string[] args = new string[]
            {
                $"-viberdir {dir}"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == dir);
        }
    }
}