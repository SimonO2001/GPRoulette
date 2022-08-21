namespace RouletteSpil 
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            // Start beløb på konto er 500
            int money;
            money = 500;

            // Imens du har mere end 1 i balancen, kører programmet
            while (money != 0)
            {
                Velkommen();
                Console.WriteLine($"                            DU HAR LIGE NU {money}");

                // Tjekker for hvilket type spil du vil foretage dig
                string chooseOfBetType = Console.ReadLine();
                // Tjekker om din indtastede værdi er et tal
                int.TryParse(chooseOfBetType, out int finalTypeOfBetType);

                // Hvis bruger indtaster 1, kan man indsatse på et tal mellem 1 og 36
                if (finalTypeOfBetType == 1)
                {
                    // Kalder mine return variabler i mine metoder
                    int talSatset = SpilType1();
                    int indsats = indsatsedebeløb();
                    int roll = Roll36to1();

                    
                    //Hvis det indtastede tal er mellem 0 og 36 fortsætter spillet, ellers bliver man kylet ud i start menuen
                    if (talSatset >= 0 && talSatset <= 36)
                    {
                        // Tjekker om man indsatser mere end hvad man har i balancen
                        if (indsats <= money)
                        {
                            if (roll == talSatset)
                            {   
                                // Placeholder for at vise beløbet man har vundet
                                int beløb = indsats * 35;

                                Console.WriteLine($"Du valgte {talSatset} og huset rullede {roll}");
                                Console.WriteLine($"DU VANDT: {beløb}!");
                                Console.ReadKey();

                                // Ligger gevindsten ind i din balance
                                money += indsats * 35;
                            }
                            else
                            {
                                Console.WriteLine($"Du valgte {talSatset} og huset rullede {roll}");
                                Console.WriteLine($"Du tabte: {indsats}!");
                                Console.ReadKey();

                                // Fjerner indsatsede beløb fra balancen
                                money -= indsats;
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        
                    }
                }
                if (finalTypeOfBetType == 2)
                {
                    int talIndtastet = SpilType2();
                    int indsats = indsatsedebeløb();
                    int farve = RollBlackOrRed();

                    
                    if (indsats <= money)
                    {
                        // Tjekker om man har vundet
                        if (talIndtastet == farve)
                        {
                            Console.WriteLine($"Du valgte {talIndtastet} og huset rullede {farve}");
                            Console.WriteLine($"DU VANDT: {indsats}!");
                            Console.ReadKey();

                            money += indsats;
                        }
                        else
                        {
                            Console.WriteLine($"Du valgte {talIndtastet} og huset rullede {farve}");
                            Console.WriteLine($"Du tabte: {indsats}!");
                            Console.ReadKey();
                            money -= indsats;
                        }
                    }
                    else
                    {

                    }
                }
                else 
                {
                
                }
                Console.Clear();

            }
        }



        static void Velkommen() 
        {
            // Start menuen
            Console.WriteLine("##############################################################################\n");
            Console.WriteLine("                    Velkommen til mit roulette spil");
            Console.WriteLine("                 Her kan du enten vælge en farve ELLER tal\n");
            Console.WriteLine("      1. Satser du på et tal mellem 0 og 36 vinder du 35 x din indsats");
            Console.WriteLine("    2. Satser du på en farve enten Rød eller Sort vinder du 2 x din indsats\n ");
            Console.WriteLine("##############################################################################\n\n");

            Console.WriteLine("\n                           Hvad vil du satse på?");
            Console.WriteLine("                            Indtast 1 eller 2\n\n");

        }

        static int indsatsedebeløb()
        {
            int bet;

            Console.WriteLine("Indtast din indsats, tak!");

            string tempInput = Console.ReadLine();

            // Tjekker om input er en INT
            while (!int.TryParse(tempInput, out bet))
            {
                Console.WriteLine("Din indtastning virkede ikke!");
                Console.Write("Indtast din indsats, tak!");
                tempInput = Console.ReadLine();
            }

            return bet;



        }

        public static int RollBlackOrRed() 
        {
            // Ruller mellem 1 og 2 for at bestemme hvilken farve
            Random rand = new Random();
            int farve = rand.Next(1,3);


            return farve;
        }

        public static int Roll36to1()
        {
            // Ruller mellem 1 og 36
            Random rnd = new Random();
            int roll = rnd.Next(1, 37);

            return roll;


        }

        public static int SpilType1() 
        {
            Console.Clear();
            int finalNumberBetOn;

            Console.WriteLine("Du har valgt at satse på et tal mellem 0 og 36");
            Console.WriteLine("Indtast hvilket tal du vil satse på");

            string tempInput = Console.ReadLine();
            while (!int.TryParse(tempInput, out finalNumberBetOn))
            {
                Console.WriteLine("Din indtast er ikke mellem 0 og 36!");
                Console.Write("Indtast din indsats, tak!");
                tempInput = Console.ReadLine();

                
            }
            return finalNumberBetOn;
        }

        public static int SpilType2() 
        {
            Console.Clear();
            int finalNumberBetOn;

            Console.WriteLine("Du har valgt at satse på Rød eller Sort");
            Console.WriteLine("Indtast 1 for Rød og 2 for Sort");

            string tempInput = Console.ReadLine();
            while (!int.TryParse(tempInput, out finalNumberBetOn))
            {
                Console.WriteLine("Din indtast er ikke 1 eller 2");
                Console.Write("Indtast venligst igen, tak!");
                tempInput = Console.ReadLine();


            }
            return finalNumberBetOn;


        }

    }





}