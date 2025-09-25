namespace Piškvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DEKLARACE PROMENNYCH
            string VyberZnakuUser = "";
            string VyberZnakuComp = "";
            string[] HraciPole =
                {
                    " ", " ", " ",
                    " ", " ", " ",
                    " ", " ", " "
                };

            // VYBER ZNAKU
            while (VyberZnakuUser != "X" && VyberZnakuUser != "O" && VyberZnakuUser != "o" && VyberZnakuUser != "x")
            {
                Console.Write("Vyberte si znak (X/O): ");
                VyberZnakuUser = Console.ReadLine();
                if (VyberZnakuUser != "X" && VyberZnakuUser != "O" && VyberZnakuUser != "o" && VyberZnakuUser != "x")
                {
                    Console.WriteLine("Neplatný výběr. Zkuste to znovu.");
                }
            }
            if (VyberZnakuUser == "X" || VyberZnakuUser == "x")
            {
                VyberZnakuUser = "X";
                VyberZnakuComp = "O";
            }
            else
            {
                VyberZnakuUser = "O";
                VyberZnakuComp = "X";
            }
            VyberSouradnic();
        }
        static void VyberSouradnic()
        {
            int Sloupec = 0;
            int Radek = 0;
            while (Sloupec !>0 & Sloupec !<4)
            {
                Console.Write("Zadejte číslo sloupce (1-3): ");
                Sloupec = int.Parse(Console.ReadLine());
                if (Sloupec !>0 & Sloupec !<4)
                {
                    Console.WriteLine("Neplatný výběr. Zkuste to znovu.");
                }
            }
            while (Radek! > 0 & Radek! < 4)
            {
                Console.Write("Zadejte číslo řádku (1-3): ");
                Radek = int.Parse(Console.ReadLine());
                if (Radek! > 0 & Radek! < 4)
                {
                    Console.WriteLine("Neplatný výběr. Zkuste to znovu.");
                }
            }
        }
    }   
}
