using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tracki.Fake;

namespace Tracki.Tests
{
    [TestFixture]
    class RecordTests
    {
        [Test]
        public void Should_()
        {
            // Arrange.
            var timeTracking = new FkTimeTracking();

            var category = new WorkTask("Test");
            var record = new Record(category, timeTracking);

            // Act.
            record.Start();
            timeTracking.SetStop(TimeSpan.FromMinutes(5));

            // Assert.
            Assert.AreEqual(TimeSpan.FromMinutes(5), record.Stop());
        }
    }
}
