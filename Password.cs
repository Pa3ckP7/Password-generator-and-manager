using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_gen_and_manager
{
    class Password
    {
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
                Console.WriteLine("Unknown subcommand use 'password ?' for help");
            }
        }
        static void Set(String[] data)
        {
            if (data.Length < 4)
            {
                Console.WriteLine("Missing parameters use 'password ?' for help");
                return;
            }
            Console.WriteLine($"Creating password with identifier {data[0]}, length {data[1]} with filter {data[2]} and key {data[3]}");
        }
        static void Get(String[] data) 
        {
            if (data.Length < 2)
            {
                Console.WriteLine("Missing parameters use 'password ?' for help");
                return;
            }
            Console.WriteLine($"Decrypting password with identifier {data[0]} with key {data[1]}");
        }
        static void List()
        {
            Console.WriteLine("Listing all password identifiers");
        }
    }
}
