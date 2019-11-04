using System;

namespace expirments
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = { "pdf.pdf", "files/pdfs/pdf1.pdf", "files/pdfs/pdf2.pdf", "files/pdfs/pdf3.pdf", "files/pdfs/lit.pdf", "files/TOs/to-10-5.txt", "files/TOs/to-11-8.txt", "files/simpletext.txt" };

            Directory root = new Directory("root");

            foreach (string filepath in filePaths)
            {
                root.FindOrCreate(filepath);
            }
        }
    }
}
