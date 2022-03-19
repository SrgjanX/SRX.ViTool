﻿//srgjanx

using NUnit.Framework;
using SRX.ViTool.Utils;

namespace SRX.ViTool.UnitTests
{
    [TestFixture]
    internal class OrganizerArgsTests
    {
        private string someFolder => "C:\\SomeFolder";

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_Default_Values_With_Null_Args()
        {
            string[] args = null;
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsFalse(oArgs.DatePrefix);
            Assert.IsNull(oArgs.ViberDirectory);
            Assert.IsFalse(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_Default_Values_With_Empty_Args()
        {
            string[] args = new string[0];
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsFalse(oArgs.DatePrefix);
            Assert.IsNull(oArgs.ViberDirectory);
            Assert.IsFalse(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_Default_Values_With_Unsupported_Args()
        {
            string[] args = new string[]
            {
                "-something", "-else"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsFalse(oArgs.DatePrefix);
            Assert.IsNull(oArgs.ViberDirectory);
            Assert.IsFalse(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_DatePrefix_True()
        {
            string[] args = new string[]
            {
                "-dateprefix"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix);
        }

        [Test]
        public void Test_ViberDir_Empty()
        {
            string[] args = new string[]
            {
                "-viberdir"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsNull(oArgs.ViberDirectory);
        }

        [Test]
        public void Test_ViberDir_Empty2()
        {
            string[] args = new string[]
            {
                "-viberdir "
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsNull(oArgs.ViberDirectory);
        }

        [Test]
        public void Test_ViberDir_Empty3()
        {
            string[] args = new string[]
            {
                "-viberdir         "
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsNull(oArgs.ViberDirectory);
        }

        [Test]
        public void Test_ViberDir_Lowercase()
        {
            string[] args = new string[]
            {
                $"-viberdir {someFolder}"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == someFolder);
        }

        [Test]
        public void Test_ViberDir_Uppercase()
        {
            string[] args = new string[]
            {
                $"-viberDir {someFolder}"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.ViberDirectory == someFolder);
        }

        //[Test]
        //public void UnnamedTest()
        //{
        //    string[] args = new string[]
        //    {
        //        $"-dateprefix -viberdir {someFolder}"
        //    };
        //    OrganizerArgs oArgs = new OrganizerArgs(args);
        //    Assert.IsTrue(oArgs.DatePrefix);
        //    Assert.IsTrue(oArgs.ViberDirectory == someFolder);
        //}

        [Test]
        public void Test_DatePrefixAndUserCurrentDir_Args_True()
        {
            string[] args = new string[]
            {
                "-dateprefix", "-usecurrentDir"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix);
            Assert.IsTrue(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_DatePrefixAndUserCurrentDir_UppercaseArgs_True()
        {
            string[] args = new string[]
            {
                "-dateprefix", "-useCurrentDir"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DatePrefix);
            Assert.IsTrue(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_UseCurrentDir()
        {
            string[] args = new string[]
            {
                $"-UseCurrentDir"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_UseCurrentDir_WithPlusValues()
        {
            string[] args = new string[]
            {
                $"-UseCurrentDir test"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.UseCurrentDir);
        }

        [Test]
        public void Test_Argument_DeletePTTDirectory()
        {
            string[] args = new string[]
            {
                $"-deletePTT"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DeletePTTDirectory);
        }

        [Test]
        public void Test_Argument_DeleteTempDirectory()
        {
            string[] args = new string[]
            {
                $"-deleteTemp"
            };
            OrganizerArgs oArgs = new OrganizerArgs(args);
            Assert.IsTrue(oArgs.DeleteTempDirectory);
        }
    }
}