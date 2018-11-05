using System;
using System.IO;

namespace IOApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DriveInfoExample();
            DirectoryExample();
        }

        static void DriveInfoExample()
        {
            var drives = DriveInfo.GetDrives();
            foreach ( DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name} Total size: {drive.TotalSize} \n" +
                    $"TotalFree: {drive.TotalFreeSpace} Available Free: {drive.AvailableFreeSpace}");
            }
        }

        static void DirectoryExample()
        {
            string dirPath = @"D:/Example";             
            var directory = Directory.CreateDirectory(dirPath);
            Console.WriteLine($"Directory exists: {directory.Exists}");

            string filePath = Path.Combine(dirPath, "example.txt");
            //File.Create(filePath);

            var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                Console.WriteLine($"FileName: {file.Name}");
            }

            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(1);
                writer.Write(false);
                writer.Write("Something");
            }
            stream.Close();

            stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using (var reader = new BinaryReader(stream))
            {
                int number = reader.ReadInt32();
                bool flag = reader.ReadBoolean();
                string word = reader.ReadString();
                Console.WriteLine($"{number} \t {flag} \t {word}");
            }

            stream.Close();

            var fileInfo = new FileInfo(filePath);
            Console.WriteLine($"File Length: {fileInfo.Length} FileName: {fileInfo.Name}");
            fileInfo.Delete();
            directory.Delete();
            Console.WriteLine($"Directory exists: {Directory.Exists(dirPath)}");

        }
    }
}
