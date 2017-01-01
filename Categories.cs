using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracki
{
    class Categories
    {
        private List<string> _categories = null;

        public string this[int index]
        {
            get
            {
                if (_categories == null)
                {
                    ReadCategoriesFromFile();
                }
                return _categories[index];
            }
        }

        public int Count
        {
            get
            {
                
                if (_categories == null)
                {
                    ReadCategoriesFromFile();
                }
                return _categories.Count;
            }
        }

        private void ReadCategoriesFromFile()
        {
            Directory.CreateDirectory(Settings.DataDir);
            string filepath = Path.Combine(Settings.DataDir, "categories.txt");
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
                _categories = new List<string>();
                return;
            }
            string[] lines = File.ReadAllLines(filepath);
            _categories = lines.ToList();
        }
    }
}
