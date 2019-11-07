using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_gen_and_manager
{
    class Filter
    {
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
                Console.WriteLine("Unknown subcommand use 'filter ?' for help");
            }
            
        }
        static void List()
        {
            Console.WriteLine("Listing all filters");
        }
        static void Preview(String[] data) 
        {
            if (data.Length == 0) 
            {
                Console.WriteLine("Missing parameters use 'filter ?' for help");
                return;
            }
            Console.WriteLine($"Previewing filter {data[0]}");
        }
        
    }
}
