using System.Collections.Generic;
using System.IO;
using System.Linq;

 namespace TrackiCore
{
    class Categories
    {
        private List<string> _categories;

        private readonly string _fileName;

        public List<string> List => _categories;
        private string FilePath => Path.Combine(Settings.DataDir, _fileName);

        public Categories(string fileName)
        {
            _fileName = fileName;
            ReadCategoriesFromFile();
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

        private void Persist()
        {
            File.WriteAllLines(FilePath, _categories);
        }
    }
}
