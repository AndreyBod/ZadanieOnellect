using System;

namespace TestovoeZadanieOnellect
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Numbers num = new Numbers(rand);
            Console.WriteLine(num.ToString());
            num.Sort(rand);
            Console.WriteLine(num.ToString());
            Console.WriteLine(ServerAcceptLayer.SendNumbers(num));
            Console.ReadKey();
        }
    }
}
