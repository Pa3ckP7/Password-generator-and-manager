using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pass_gen_and_manager
{
    class Password
    {
        static string Filters_directory = @"Saved_data\Filters";
        static string Passwords_directory = @"Saved_data\Passwords";
        static Random rng = new Random();
        public static void Send(String subcommand, String[] data)
        {
            if (subcommand.Equals("set"))
            {
                Set(data);
            }
            else if (subcommand.Equals("get"))
            {
                Get(data);
            }
            else if (subcommand.Equals("list"))
            {
                List();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Unknown subcommand use 'password ?' for help");
                Console.ResetColor();
            }
        }
        static void Set(String[] data)
        {
            if (data.Length < 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Missing parameters use 'password ?' for help");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Creating password with identifier {data[0]}, length {data[1]} with filter {data[2]} and key {data[3]}");
            Console.ResetColor();
            string identifier = data[0];
            int length = Convert.ToInt32(data[1]);
            string filter = $"{data[2]}.txt";
            string key = data[3];
            if (!File.Exists($@"{Filters_directory}\{filter}")) 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Filter not found canceling request...");
                Console.ResetColor();
                return;
            } 
            overide_question:
            if (File.Exists($@"{Passwords_directory}\{identifier}")) 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Password with that identifier already exists");
                Console.WriteLine("Do you want to overide?");
                Console.ResetColor();
                Console.Write("<yes/no> ");
                string answer = Console.ReadLine();
                if (answer.Equals("no"))
                {
                    return;
                }
                else if (answer.Equals("yes"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Overiding");
                    Console.ResetColor();
                    goto overide_yes;
                }
                else 
                {
                    Console.WriteLine("canceling request");
                    goto overide_question;
                }
            }
            overide_yes:
            string[] filter_data = File.ReadAllLines($@"{Filters_directory}\{filter}");
            string password="";
            for (int i = 0; i < length; i++) 
            {
                password += filter_data[rng.Next(0, filter_data.Length - 1)];
            }
            password = Encrypt.EncryptString(password, key);
            File.WriteAllText($@"{Passwords_directory}\{identifier}",password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Created password with identifier { data[0]}, length { data[1]} with filter { data[2]} and key { data[3]}");
            Console.ResetColor();
        }
        static void Get(String[] data) 
        {
            if (!File.Exists($@"{Passwords_directory}\{data[0]}"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Password associated with that identifier could not be found canceling request...");
                Console.ResetColor();
                return;
            }

            if (data.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Missing parameters use 'password ?' for help");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Decrypting password with identifier {data[0]} with key {data[1]}");
            Console.ResetColor();
            string password=(File.ReadAllText($@"{Passwords_directory}\{data[0]}"));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Password decrypted");
            Console.ResetColor();
            Console.WriteLine(Encrypt.DecryptString(password,data[1]));
        }
        static void List()
        {
            Console.WriteLine("Listing all password identifiers");
            if (Directory.GetFiles(Passwords_directory).Length != 0)
            {
                String[] Passwords = Directory.GetFiles(Passwords_directory);
                for (int i = 0; i < Passwords.Length; i++)
                {
                    Passwords[i] = Passwords[i].Replace($"{Passwords_directory}\\", "");
                    Passwords[i] = Passwords[i].Replace($".txt", "");
                }
                Array.ForEach(Passwords, Console.WriteLine);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No stored passwords found");
                Console.ResetColor();
            }
        }
    }
}
