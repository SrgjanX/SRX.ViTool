//srgjanx

using NUnit.Framework;
using SRX.ViTool.Utils;
using System;
using System.IO;

namespace SRX.ViTool.UnitTests
{
    [TestFixture]
    internal class OrganizerTests
    {
        private IOrganizerArgs oArgs_null;

        [SetUp]
        public void Setup()
        {
            oArgs_null = new OrganizerArgs(null);
        }

        [Test]
        public void Test_Constructor_InvalidDirectory_NullStringDirectory()
        {
            Organizer organizer = new Organizer(null, oArgs_null);
            Assert.That(() => organizer.Organize(out int? filesProcessedCount),
                Throws.TypeOf<DirectoryNotFoundException>());
        }

        [Test]
        public void Test_Constructor_InvalidDirectory_EmptyStringDirectory()
        {
            Organizer organizer = new Organizer(string.Empty, oArgs_null);
            Assert.That(() => organizer.Organize(out int? filesProcessedCount),
                Throws.TypeOf<DirectoryNotFoundException>());
        }

        [Test]
        public void Test_Constructor_InvalidDirectory_UnexistentDireectory()
        {
            string invalidDir = $"Z:\\{Guid.NewGuid()}";
            Organizer organizer = new Organizer(invalidDir, oArgs_null);
            Assert.That(() => organizer.Organize(out int? filesProcessedCount),
                Throws.TypeOf<DirectoryNotFoundException>());
        }
    }
}