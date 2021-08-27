using System;
using System.IO;

namespace AssignmentOne
{
    class Program
    {
        static void Main(string[] args)
        {

            //ask user if they want to read file or write to file
            Console.WriteLine("1)Do you want to read file?");
            System.Console.WriteLine("2)Do you want to write to file?");
            //save the input of the user
            string decision = Console.ReadLine();
            //create variables for the file that is going to be created or already created
            string file = "Tickets.csv";
            //they want to read from file
            if (decision == "1")
            {
                if (File.Exists(file))
                {
                   //read data from the csv
                   StreamReader sr = new StreamReader(file);
                   int count = 0;
                   while(!sr.EndOfStream){
                       string line = sr.ReadLine();
                       //convert string to an array
                       string[] words = line.Split(',');
                       //display array data
                       for(int i = 0; i < words.Length; i++){
                           System.Console.Write(words[i] + " ");
                           count++;
                           if(count == 7){
                            System.Console.WriteLine();
                            count = 0;
                           }
                       }
                   } 
                }
                else
                {
                    Console.WriteLine("File does not exist!");
                }
            }
            else if (decision == "2"){
                StreamWriter sw = new StreamWriter(file);
                //create accumulator for ticket id
                int ticketID = 0;
                do{
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    //ask for summarry 
                    Console.WriteLine("What is the summary?");
                    //save summary string
                    string summary = Console.ReadLine();
                    //ask for status
                    Console.WriteLine("What is the status");
                    //save status string
                    string status = Console.ReadLine();
                    //ask for priority
                    Console.WriteLine("What is the priority of ticket");
                    //save priority string
                    string priority = Console.ReadLine();
                    //ask for submitter name
                    Console.WriteLine("What is the submitter name?");
                    //save submitter string
                    string submitter = Console.ReadLine();
                    //ask for assigned
                    Console.WriteLine("What is the assigned name?");
                    //save assigned string
                    string assigned = Console.ReadLine();
                    //ask for watching names
                    System.Console.WriteLine("How many are watching?");        
                    int watching = Int32.Parse(Console.ReadLine());
                    string watchers = "";
                    //make loop to continue asking for names
                    for(int i = 0;i < watching; i++){
                        System.Console.WriteLine($"What is person's {i+1} name?");
                        watchers += Console.ReadLine() + "|";
                    }
                    //write all info to the line
                    sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{watchers}");
                    ticketID++;

                }while(decision != "2");
                sw.Close();
            }
        
        }
    }
}
