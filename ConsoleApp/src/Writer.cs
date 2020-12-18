using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Application1
{
    public class Writer
    {
        static string path="";
        int count = 1;
        
        public Writer(){

            string createText = "No,Date,Timestamp,Level,Message" + Environment.NewLine;
            Writer.pathGetter(createText);
            
        }
        public static string pathGetter(string createText)
        {
            
            Console.Write("Enter path to CSV File : ");
            path=Console.ReadLine();

            FileInfo fi = new FileInfo(path);

            string extn = fi.Extension;  
            //Console.WriteLine("File Extension: {0}", extn);

            if(extn == ".csv")
            {
                File.WriteAllText(path, createText);
                return extn;
            }

            else{
                System.Console.WriteLine("The path to csv file is not valid");
                return null;
            }
            
        }
        public void writeToCSV(string level, string date, string timestamp, string message)
        {
            
            string text=count+","+date+","+timestamp+","+level+","+message+"\t"+"\n";
            File.AppendAllText(path, text);
            count++;

        }
    }
}