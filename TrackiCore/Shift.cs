﻿using System;
using System.IO;
 using TrackiCore.ValueObjects;

 namespace TrackiCore
{
    public class Shift
    {
        private readonly string _name;
        private DateTime _dtStart;

        private readonly DataRepo _dataRepo;

        public Shift(Type type, string name)
        {
            _name = name;
            _dataRepo = new DataRepo(type);
        }

        public void Start()
        {
            Console.WriteLine("Starting task {0}", _name);
            _dtStart = DateTime.Now;
        }

        public void Finish()
        {
            var dtEnd = DateTime.Now;
            Console.WriteLine("Finished: {0:hh}h {0:mm}min", dtEnd - _dtStart);

            Directory.CreateDirectory(Settings.DataDir);

            _dataRepo.Add(new WorkItem(_name, _dtStart, dtEnd));
        }

        public override string ToString()
        {
            return _name;
        }

        public enum Type { WORK, STUDY }
    }
}