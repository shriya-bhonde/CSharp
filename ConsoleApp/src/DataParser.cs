using System;
using System.IO;
using System.Linq;

namespace Application1
{
    class DataParser
    {

        Writer w=new Writer();
        
        private bool DateCheck(string date){
            try{
                DateTime dt= DateTime.Parse(date);
                return true;
            }
            catch{
                return false;
            }
        }

        public void DataCollect(string filepath)
        {
            try{
                string[] lines = System.IO.File.ReadAllLines(@filepath);            //getting the file contents
                
                
                    for(int i=0; i<lines.Length; i++)
                    {
                        if(string.IsNullOrWhiteSpace(lines[i])){
                            continue;
                        }
                        else if(string.IsNullOrWhiteSpace(lines[i+1])|| lines[i+1].StartsWith(" ")){
                            ParseLines(lines[i], "null");
                        }
                        else if(lines[i].StartsWith(" ")){
                            continue;
                        }
                    
                        else{
                            ParseLines(lines[i], lines[i+1]);
                        }
                    }

                
    
            }
            catch(Exception)
            {
                //Console.WriteLine("Exception Occured");
            }
            
        }

        private void ParseLines(string line1, string line2)
        {
            
            bool valid;
            var date="";
            var level="";
            var timestamp="";
            var message = "";
            string DateT ="";
            
            if(line2=="null")
            {
                string[] lineArr1 = line1.Split(" ");
                valid = DateCheck(lineArr1[0]);

                if(valid==true)
                {
                    date = lineArr1[0];
                    level = lineArr1[2];
                    timestamp = lineArr1[1];
                    DateTime dt = DateTime.Parse(date);

                    for(int i=3;i<lineArr1.Length; i++)
                    {
                        message += lineArr1[i];
                        message += " ";
                    }

                    //call to WriteToCSV
                    DateT = dt.ToString("dd MMM yyyy");
                    w.writeToCSV(level, DateT, timestamp, message);

                }    
            }// end of if


            else{
                string[] lineArr1 = line1.Split(" ");
                valid = DateCheck(lineArr1[0]);

                if(valid==true)
                {
                    date = lineArr1[0];
                    level = lineArr1[2];
                    timestamp = lineArr1[1];
                    DateTime dt = DateTime.Parse(date);

                    DateT = dt.ToString("dd MMM yyyy");

                    for(int i=3;i<lineArr1.Length; i++)
                    {
                        message += lineArr1[i];
                        message += " ";
                    }

                    string[] lineArr2 = line2.Split(" ");
                    valid = DateCheck(lineArr2[0]);

                    if(valid==false)
                    {
                    message += line2;
                    }

                    //call to WriteToCSV
                    w.writeToCSV(level, DateT, timestamp, message);

                }

                

            }           
        }
    }
}

