using System.Diagnostics;

namespace KNP__Piskvorky__Sibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INPUT A DEKLARACE PROMENNYCH
            Random random = new Random();
            int VyberComp = random.Next(1, 4);
            Console.WriteLine("Vyberte si jedno z následujících: kámen, nůžky, papír");
            string VyberUser = Console.ReadLine();

            //VYPIS TEXTU
            Console.WriteLine($"Uživatel vybral {VyberUser}");
            if (VyberComp == 1)
            {
                Console.WriteLine("Počítač vybral kámen")
            }
            else if (VyberComp == 2)
            { 
            
            }
        }
    }
}
