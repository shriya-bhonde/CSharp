using System;
using System.IO;

namespace Application1
{
    public class Validator{

       public bool validate(string dir_path)
        {
            try{
                    string[] filepaths = Directory.GetFiles(@dir_path, "*.log", SearchOption.AllDirectories);   //retrieveing all the file paths
                    DataParser dp = new DataParser();

                    int i;
                    for (i = 0; i < filepaths.Length; i++)
                    {
                        dp.DataCollect(filepaths[i]);
                    }
                    return true;
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("Directory does not exist");
                return false;
            }
        }
    }
}

