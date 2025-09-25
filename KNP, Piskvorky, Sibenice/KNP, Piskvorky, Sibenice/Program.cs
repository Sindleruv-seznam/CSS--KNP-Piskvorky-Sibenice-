using System.Diagnostics;

namespace KNP__Piskvorky__Sibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Running = (1);
            while (Running == 1)
            {
                //VYBER POCITACE
                Random random = new Random();
                int VyberComp = random.Next(1, 4);
                int VyberUser = 0;

                //INPUT
                Console.WriteLine("Vyberte si jedno z následujících: kámen, nůžky, papír");
                string VolbaUser = Console.ReadLine();

                //PREVOD VYBERU UZIVATELE NA CISLO
                if (VolbaUser == "kámen" || VolbaUser == "kamen" || VolbaUser == "Kámen" || VolbaUser == "Kamen")
                {
                    VyberUser = (1);
                }
                else if (VolbaUser == "nůžky" || VolbaUser == "nuzky" || VolbaUser == "nůzky" || VolbaUser == "nužky" || VolbaUser == "Nužky" || VolbaUser == "Nůžky" || VolbaUser == "Nuzky" || VolbaUser == "Nůzky")
                {
                    VyberUser = (2);
                }
                else if (VolbaUser == "papir" || VolbaUser == "papír" || VolbaUser == "Papir" || VolbaUser == "Papír")
                {
                    VyberUser = (3);
                }

                //VYPIS TEXTU
                Console.WriteLine($"Uživatel vybral {VolbaUser}");
                if (VyberComp == 1)
                {
                    Console.WriteLine("Počítač vybral kámen");
                }
                else if (VyberComp == 2)
                {
                    Console.WriteLine("Počítač vybral nůžky");
                }
                else if (VyberComp == 3)
                {
                    Console.WriteLine("Počítač vybral papír");
                }

                //POSOUZENI VITEZE
                if (VyberComp == VyberUser)
                {
                    Console.WriteLine("Remíza");
                }
                else if (VyberComp == 1 & VyberUser == 2)
                {
                    Console.WriteLine("Počítač vyhrál");
                }
                else if (VyberComp == 1 & VyberUser == 3)
                {
                    Console.WriteLine("Uživatel vyhrál");
                }
                else if (VyberComp == 2 & VyberUser == 1)
                {
                    Console.WriteLine("Uživatel vyhrál");
                }
                else if (VyberComp == 2 & VyberUser == 3)
                {
                    Console.WriteLine("Počítač vyhrál");
                }
                else if (VyberComp == 3 & VyberUser == 1)
                {
                    Console.WriteLine("Počítač vyhrál");
                }
                else if (VyberComp == 3 & VyberUser == 2)
                {
                    Console.WriteLine("Uživatel vyhrál");
                }
                Console.WriteLine("Přejete si hrát znovu? (Y/N)");
                string HratZnovu = Console.ReadLine();
                if (HratZnovu == "Y" || HratZnovu == "y")
                {
                    Running = 1;
                }
                if (HratZnovu == "N" || HratZnovu == "n")
                {
                    Running = 0;
                }

            }
        }
    }
}
