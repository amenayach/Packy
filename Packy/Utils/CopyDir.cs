using System;
using System.IO;

namespace Packy.Utils
{

    public class CopyDir
    {
        public static void Copy(string sourceDirectory, string targetDirectory)
        {

            if (Directory.Exists(sourceDirectory))
            {

                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

                CopyAll(diSource, diTarget);

            }
            else if (File.Exists(sourceDirectory))
            {
                var fi = new FileInfo(sourceDirectory);
                fi.CopyTo(Path.Combine(targetDirectory, fi.Name), true);
            }

        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
