using System;
using System.IO;
using System.Collections.Generic;

namespace Application1
{
    class Program
    {

        static void Main(string[] args)
        {

            List<string> al = new List<string>{"WARN", "ERROR", "INFO", "TRACE", "DEBUG", "EVENT"};
            bool flag;

            if(args.Length == 2)
            {
                string level = args[1];
                string dir_path = Path.GetFullPath(args[0]);

            
                string level1 = args[0];
                string dir_path1= Path.GetFullPath(args[1]);

                Validator v = new Validator();
                if(level==args[1] && dir_path==args[0]){
                    level=level.ToUpper();
                    flag=al.Contains(level);
                    if(flag==true)
                        v.validate(dir_path);
                    else{
                        //call to help()
                        Program.Help();
                    }
                
                }

                else{
                    level1=level1.ToUpper();
                    flag=al.Contains(level1);
                    if(flag==true)
                        v.validate(dir_path1);
                    else{
                        //call to help()
                        Program.Help();
                    }
                }

            }//end of if

            else if(args.Length==1){
                string help=args[0];
                help=help.ToLower();

                if(help=="help")
                    Program.Help();
                else{
                    Program.Help();
                }

            }

            else{
                //call to help()
                Program.Help();
            }
                
        }//end of main()

        public static void Help()
        {
            Console.WriteLine("\n  The User is expected to pass two parameters:");
            Console.WriteLine("1. The path of the directory that has log files.  2. The level\n");
            Console.WriteLine("  dir-path      Directory to parse resursively for .log files");
            Console.WriteLine("  level    INFO|WARN|DEBUG|TRACE|ERROR|EVENT");
        }
    }
}
