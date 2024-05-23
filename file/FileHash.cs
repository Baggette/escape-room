using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace escape_room.file
{
    public class FileHash
    {
        private static bool hasWritePermission(string path)
        {
            bool write_allow = false;
            bool write_deny = false;


            DirectoryInfo dInfo = new DirectoryInfo(path);
            DirectorySecurity acess_control_list = dInfo.GetAccessControl();

            if (acess_control_list == null) return false;

            var acess_rules = acess_control_list.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            if (acess_rules == null) return false;

            foreach (FileSystemAccessRule rule in acess_rules)
            {
                if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write) continue;

                if (rule.AccessControlType == AccessControlType.Allow)
                {
                    write_allow = true;
                }
                else if (rule.AccessControlType == AccessControlType.Deny)
                {
                    write_deny = false;
                }
            }


            return write_allow;

        }

        private string getRandomSubFolder(string root)
        {
            DirectoryInfo dInfo = new DirectoryInfo(root);
            var dirs = dInfo.GetDirectories();
            Random rnd = new Random();
            if (dirs.Length == 0) return root;

            return dirs[rnd.Next(0, dirs.Length)].FullName;
        }

        private string getRandomFolder(string root)
        {
            string[] folders = Directory.GetDirectories(root);
            Random rnd = new Random();
            int depth = rnd.Next(0, folders.Length);
            return getRandomSubFolder(folders[depth]);
        }

        public string HashFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public string writeToFileAndHash(string content, string filename)
        {
            string random_path = "";
            string go_lower = "";

            while (true)
            {
                try
                {
                    random_path = getRandomFolder("C:");
                    go_lower = getRandomFolder(random_path);
                    //Console.WriteLine(go_lower);

                    if (hasWritePermission(random_path))
                    {
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(go_lower, $"{filename}.txt"), true))
                        {
                            outputFile.WriteLine(content);
                        }
                    }
                    break;

                }
                catch (UnauthorizedAccessException)
                {
                    //Console.WriteLine("im gonna cry00");
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine("index out of bound");
                    continue;
                }
                catch (FileNotFoundException)
                {
                    //Console.WriteLine("file not found");
                    continue;
                }
            }

            return go_lower;//HashFile(go_lower + "/sus.txt");
        }
    }
}
