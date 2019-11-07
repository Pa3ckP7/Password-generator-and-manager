using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_gen_and_manager
{
    class CommandManager
    {
        public void send(String command, String[] data) 
        {
            if (data.Length - 1 < 0) 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Unknown command try ? for help");
                Console.ResetColor();
                return;
            }
            string[] datanew = new string[data.Length-1];
            string subcommand = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                datanew[i - 1] = data[i];
            }
            if (command.Equals("password"))
            {
                if (subcommand.Equals("?"))
                {
                    Console.WriteLine("password help\n commands, paramters and decryption:\n" +
                        "-password set [identfier] [length] [filter] [decryption-key] || creates a password with the given identifier of given length " +
                        "using characters from the given filter. Keep the decryption-key safe since if lost you will also loose the access to the password\n" +
                        "-password get [identifier] [decryption-key] || will decrypt the password chosen by the identifier with the decryption-key and display " +
                        "the decrypted password on screen. Be aware if the key is not correct the password will also be.\n" +
                        "-password list || displays all stored password identifiers");
                    return;
                }
                else 
                {
                    Password.Send(subcommand, datanew);
                }
            }
            else if (command.Equals("filter"))
            {
                if (subcommand.Equals("?"))
                {
                    Console.WriteLine("filter help\n commands and parameters:\n" +
                        "-filter list || displays all stored filters\n" +
                        "-filter preview [name] || displays the contents of [name] filter");
                }
                else
                {
                    Filter.send(subcommand, datanew);
                }

            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid command use ? for help");
                Console.ResetColor();
                return;
            }
        }
    }
}
