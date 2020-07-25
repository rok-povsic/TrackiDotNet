﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

 namespace TrackiCore
{
    class Categories
    {

        private List<string> _categories;

        private readonly string _fileName;

        public string this[int index] => _categories[index];

        public int Count => _categories.Count;

        public List<string> List => _categories;
        private string FilePath => Path.Combine(Settings.DataDir, _fileName);

        public Categories(string fileName)
        {
            _fileName = fileName;
            ReadCategoriesFromFile();
        }

        public void Display()
        {
            Console.WriteLine("Categories:");
            if (Count > 0)
            {
                foreach (string category in _categories)
                {
                    Console.WriteLine("\t" + category);
                }
            }
            else
            {
                Console.WriteLine("There are no categories.");
            }
        }

        private void ReadCategoriesFromFile()
        {
            Directory.CreateDirectory(Settings.DataDir);
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
                _categories = new List<string>();
                return;
            }
            string[] lines = File.ReadAllLines(FilePath);
            _categories = lines.ToList();
        }

        public void Add(string category)
        {
            _categories.Add(category);
            Persist();
        }

        public bool Contains(string category)
        {
            return _categories.Contains(category);
        }

        /// <summary>
        /// TODO: Rename work also?
        /// </summary>
        public void Rename(string oldCategory, string newCategory)
        {
            _categories[_categories.IndexOf(oldCategory)] = newCategory;
            Persist();
        }

        /// <summary>
        /// TODO: Remove work also?
        /// </summary>
        public void Remove(string category)
        {
            _categories.Remove(category);
            Persist();
        }

        private void Persist()
        {
            File.WriteAllLines(FilePath, _categories);
        }
    }
}
