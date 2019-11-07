using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_gen_and_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandManager cm = new CommandManager();
            bool run = true;
            while (run == true) 
            {
                Console.Write("password manager|> ");
                string received=Console.ReadLine();
                string[] arguments = received.Split(' ');
                string command = arguments[0];
                string[] data = new string[arguments.Length-1];
                for (int i = 1; i < arguments.Length; i++) 
                {
                    data[i - 1] = arguments[i];
                }
                if (command.Equals("?")) 
                {
                        Console.WriteLine("Available commands:\n" +
                            "-password || command for creating, listing and receiving passwords\n" +
                            "-filter || command for listing and previewing password creation filters");
                        continue;
                }
                cm.send(command, data);
            }
        }
    }
}
