using System;
using TrackiCore.Tests.Fake;
using Xunit;

namespace TrackiCore.Test
{
    public class RecordTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange.
            var timeTracking = new FkTimeTracking();

            var category = new WorkTask("Test");
            var record = new Record(category, timeTracking);

            // Act.
            record.Start();
            timeTracking.SetStop(TimeSpan.FromMinutes(5));

            // Assert.
            Assert.Equal(TimeSpan.FromMinutes(5), record.Stop());
        }
    }
}
