using System;
using TrackiCore.Stats;

namespace TrackiCore
{
    class Host
    {
        public Statistics Statistics { get; }
        public Categories WorkCategories { get; }
        public Categories StudyCategories { get; }

        public Host()
        {
            WorkCategories = new Categories("categories.txt");
            StudyCategories = new Categories("categories-study.txt");
            Statistics = new Statistics();
        }

        public Categories Categories(Shift.Type type)
        {
            return type switch
            {
                Shift.Type.WORK => WorkCategories,
                Shift.Type.STUDY => StudyCategories,
                _ => throw new Exception("Unknown type.")
            };
        }
    }
}
