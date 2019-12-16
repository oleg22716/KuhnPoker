using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    class Program
    {
        static void Print(string toPrint)
        {
            Console.WriteLine(toPrint);
        }

        static void Delay()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            KuhnNode node = new KuhnNode(null);
            Print(node.ToString());
            Print(node.GetChild(0).ToString());
            Print(node.GetChild(0).GetChild(0).ToString());
            Print(node.GetChild(0).GetChild(0).GetChild(0).ToString());
         
            
            Delay();
        }
    }
}