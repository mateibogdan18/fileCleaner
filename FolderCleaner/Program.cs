using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderCleaner
{
    class Program
    {
        static string[] files = null;
        static string[] filesRamase = null;

        static string cale = "";
        static void Main(string[] args)
        {
            string[] extensii;
            int nrZile ;
                                
            try
            {
                string m_BaseDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string strWorkPath = System.IO.Path.GetDirectoryName(m_BaseDir);
                string strSettingsiniFilePath = System.IO.Path.Combine(strWorkPath, "configFolderCleaner.ini");

                FileIniDataParser i = new FileIniDataParser();
                i.Parser.Configuration.CommentString = "#";
                IniData data = i.ReadFile(strSettingsiniFilePath);
                cale = data["FolderClean"]["cale"];
                string extensie = data["FolderClean"]["extensii"];
                extensii = extensie.Split(';');
                nrZile = Convert.ToInt32(data["FolderClean"]["nrZileVechime"]);

            }
            catch (Exception ex)
            {
                Console.WriteLine("The ini file not found");
                Console.WriteLine("");
                Console.WriteLine("");
                return;
            }

          
            
            Console.WriteLine("");
            Console.WriteLine("--==--------------------------Folder cleaner developed by Bogdan--==----------------");
            Console.WriteLine("");
            

            bool sters = false;
            
            if (Directory.Exists(cale))
            {
                Console.WriteLine("--------------------Files from folder: " + cale + " ,before cleaning------");
                Console.WriteLine("");
                files = Directory.GetFiles(cale, "*", SearchOption.AllDirectories);
                listFiles(cale);

                foreach (string  f1 in files)
                {
                   
                    
                }
                if (sters)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------------Files from folder: " + cale + " ,after cleaning------");
                    listFilesRamase(cale);
                }
            }
            else
            {
                Console.WriteLine("the directory " + cale + " does not exist");
            }
            
            Console.WriteLine("");
            Console.WriteLine("press any key to close...");
            Console.ReadKey();
        }

        public static void listFiles(string cale1)
        {

            if (files.Length == 0) Console.WriteLine("files not found in the folder: " + cale1);
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine("File name: " + files[i]+" last modified: " +File.GetLastWriteTime(files[i]));
                }
            }
        }
        public static void listFilesRamase(string cale1)
        {
            filesRamase=Directory.GetFiles(cale, "*", SearchOption.AllDirectories);
            if (filesRamase.Length == 0) Console.WriteLine("files not found in the folder: " + cale1);
            else
            {
                for (int i = 0; i < files.Length; i++)
                {                    
                    Console.WriteLine("File name: " + filesRamase[i] + " last modified: " + File.GetLastWriteTime(filesRamase[i]));
                }
            }
        }
        public static void stergeFisiereVechi(int nrzile, string numefisier,int vechime)
        {
           
            if (Directory.Exists(cale))
            {
                if (File.Exists(numefisier))
                {
                    try
                    {

                        if (vechime > nrzile) File.Delete(numefisier);
                        else return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The file " + numefisier + " can not be deleted");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("The file " + numefisier + " not found");
                    return;
                }
            }
            else
            {
                Console.WriteLine("the directory " + cale + " not found");
                return;
            }
        }
    }

}
