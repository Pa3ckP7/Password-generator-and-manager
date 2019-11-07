using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pass_gen_and_manager
{
    class Filter
    {
        static string Filters_directory = @"Saved_data\Filters";
        public static void send(String subcommand, String[] data) 
        {

            if (subcommand.Equals("list"))
            {
                List();
            }
            else if (subcommand.Equals("preview"))
            {
                Preview(data);
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Unknown subcommand use 'filter ?' for help");
                Console.ResetColor();
            }
            
        }
        static void List()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Listing all filters");
            Console.ResetColor();
            if (Directory.GetFiles(Filters_directory).Length != 0)
            {
                String[] Filters = Directory.GetFiles(Filters_directory);
                for (int i = 0; i < Filters.Length; i++)
                {
                    Filters[i] = Filters[i].Replace($"{Filters_directory}\\", "");
                    Filters[i] = Filters[i].Replace($".txt", "");
                }
                Array.ForEach(Filters, Console.WriteLine);
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No filters found");
                Console.ResetColor();
            }
        }
        static void Preview(String[] data) 
        {
            if (data.Length == 0) 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Missing parameters use 'filter ?' for help");
                Console.ResetColor();
                return;
            }
            
            if (File.Exists($@"{Filters_directory}\{data[0]}.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Previewing filter {data[0]}");
                Console.ResetColor();
                Array.ForEach(File.ReadAllLines($@"{Filters_directory}\{data[0]}.txt"), Console.Write);
                Console.Write("\n");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Filter does not exist");
                Console.ResetColor();
            }
        }
        
    }
}
