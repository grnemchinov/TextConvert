using System.Diagnostics;
using File = System.IO.File;

namespace Practich7
{
    public static class Provodnik
    {
        static Strelki strelka = new Strelki();
        private static int a;

        private static DriveInfo b;
        private static string c;

        private static string[] vse;
        public static void Diski()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("Диски: ");
            strelka.min = 0;
            strelka.max = 1;

            Console.SetCursorPosition(0, 1);
            strelka.key = Console.ReadKey();


            foreach (DriveInfo d in drives)
            {
                Console.WriteLine("  " + d.Name);
                strelka.max += 1;
                if (d.IsReady == true)
                {
                    Console.WriteLine($"    Свободное пространство: {d.TotalFreeSpace}");
                    strelka.max += 1;
                }

            }

            while (strelka.key.Key != ConsoleKey.Enter)
            {
                strelka.Strelka();
                a = strelka.position;
            }
            for (int i = 0; i < drives.Length; i++)
            {
                if (i == a)
                {
                    b = drives[1 - 1];
                    Files();
                }
            }

        }

        private static void Files()
        {
            Console.Clear();
            Console.WriteLine("Папки или файлы: ");
            strelka.min = 0;
            strelka.max = 1;

            string dis = Convert.ToString(b);

            string[] papki = Directory.GetDirectories(dis);
            foreach (string s in papki)
            {
                Console.WriteLine("  " + s);
            }

            string[] files = Directory.GetFiles(dis);
            foreach (string s in files)
            {
                Console.WriteLine("  " + s);
            }

            vse = new string[papki.Length + files.Length];
            papki.CopyTo(vse, 0);
            files.CopyTo(vse, papki.Length);
            strelka.max += vse.Length;

            strelka.key = Console.ReadKey();
            while (strelka.key.Key != ConsoleKey.Enter)
            {
                strelka.Strelka();
                a = strelka.position;
            }



            for (int i = 0; i <= vse.Length; i++)
            {
                if (i == a)
                {
                    c = vse[i];
                    if (Directory.Exists(c))
                    {
                        Papk();
                    }
                    else if (File.Exists(c))
                    {
                        Fil();
                    }
                }
            }
        }

        private static void Papk()
        {
            Console.Clear();
            var directory = new DirectoryInfo(c);

            Console.WriteLine($"  Название каталога: {directory.Name}");
            Console.WriteLine($"  Время создания каталога: {directory.CreationTime}");
            Console.WriteLine();
            strelka.min = 2;
            strelka.max = 3;


            if (directory.Exists)
            {

                string[] dirs = Directory.GetDirectories(c);
                foreach (string dir in dirs)
                {
                    Console.WriteLine("  " + dir);
                }

                string[] files = Directory.GetFiles(c);
                foreach (string file in files)
                {
                    Console.WriteLine("  " + file);
                }

                vse = new string[dirs.Length + files.Length];
                dirs.CopyTo(vse, 0);
                files.CopyTo(vse, dirs.Length);
                strelka.max += vse.Length;
            }

            strelka.key = Console.ReadKey();
            Console.SetCursorPosition(0, 3);
            while (strelka.key.Key != ConsoleKey.Enter)
            {
                strelka.Strelka();
                a = strelka.position;
            }



            for (int i = 0; i <= vse.Length; i++)
            {
                if (i == a - 3)//потому что первые 3 позиции заняты другим
                {
                    c = vse[i];
                    if (Directory.Exists(c))
                    {
                        Papk();
                    }
                    else if (File.Exists(c))
                    {
                        Fil();
                    }
                }
            }
        }

        private static void Fil()
        {
            var file = c;
            if (File.Exists(file))
            {
                Process.Start(file);
            }
        }
    }
}