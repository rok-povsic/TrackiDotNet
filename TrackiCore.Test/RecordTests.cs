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
            var timeTracking = new FkTimeTracking();

            var category = new Shift(Shift.Type.WORK, "Test");
            var record = new Record(category, timeTracking);

            record.Start();
            timeTracking.SetStop(TimeSpan.FromMinutes(5));

            Assert.Equal(TimeSpan.FromMinutes(5), record.Stop());
        }
    }
}
