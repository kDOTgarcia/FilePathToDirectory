using System.Collections.Generic;

namespace expirments
{
    public class Directory
    {
        public string Name { get; set; }
        public Dictionary<string, Directory> ChildDirectories { get; set; }
        // public Directory ParentDirectory { get; set; } // not sure what to do with this when current Directory is root ie no parent
        public List<string> Files { get; set; }

        public Directory(string name)
        {
            Name = name;
            // ParentDirectory = parentDirectory;
            ChildDirectories = new Dictionary<string, Directory>();
            Files = new List<string>();
        }

        public Directory FindOrCreate(string path, bool mightBeFile = true)
        {
            int i = path.IndexOf("/");

            if (i > -1)
            {
                Directory dir = FindOrCreate(path.Substring(0, i), false);
                return dir.FindOrCreate(path.Substring(i + 1), true);
            }

            if (path == "") return this;

            if (mightBeFile && path.Contains("."))
            {
                Files.Add(path);
                return this;
            }

            Directory child;

            if (ChildDirectories.ContainsKey(path))
            {
                child = ChildDirectories[path];
            }
            else
            {
                child = new Directory(path);
                ChildDirectories.Add(path, child);
            }
            return child;
        }
    }
}

// Call it like this:
// 
// var filePathArray = String[]
// Directory parent = new Directory("parent")
// foreach (string filepath in filePathArray) {
//      parent.FindOrCreate(fielpath)
// }