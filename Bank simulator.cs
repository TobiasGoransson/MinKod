// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// See https://aka.ms/new-console-template for more information

// Hälsning
Console.WriteLine("Välkommen till banksimulatorn");

// Variabler
int saldo = 0;
double sparSaldo = 0;
int insättning;
int uttag;
double årsränta;
int år;
int insättningSparande;
int antalInsättningar = 1;
double sparSaldoSum;
string MenySelection;
bool validInput;
double ränta;


while (true)
{
    // Menyval
    Console.WriteLine();
    Console.WriteLine("Menyval: ");
    Console.WriteLine();
    Console.WriteLine("[I]nsättning");
    Console.WriteLine("[U]ttag");
    Console.WriteLine("[S]aldo");
    Console.WriteLine("[R]äntebetalning");
    Console.WriteLine("[A]vsluta");
    Console.WriteLine();

    // Användarens val
    MenySelection = Console.ReadLine();

    switch (MenySelection)
    {
        //Insättning
        case "I":
        case "i":
            do /* do loopen kollar så att man har skrivit in siffor och ger en ny chans om man skrivit fel
                den är åter kommande igenom programmet på alla ställen där användaren skall mata in någon form 
                av siffror */
            {
                validInput = false;
                Console.WriteLine("Hur mycket vill du sätta in");
                string input = Console.ReadLine();
                if (int.TryParse(input, out insättning))
                {
                    saldo += insättning;
                    Console.WriteLine("Ditt saldo är: " + saldo + " kr");
                    validInput = true;

                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Använd bara siffror");
                    Console.WriteLine();
                }
            } while (!validInput);

            break;

        //Uttag
        case "U":
        case "u":
            do
            {
                validInput = false;
                Console.WriteLine("Hur mycket vill du ta ut?");
                string input1 = Console.ReadLine();
                if (int.TryParse(input1, out uttag))
                {
                    saldo = saldo - uttag;
                    validInput = true;
                    Console.WriteLine(saldo);
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Använd bara siffror");
                    Console.WriteLine();
                }
            } while (!validInput);

            if (saldo <0) // För att förhindra att man tar ut mer pengar än man har
            {
                Console.WriteLine("Inte tillräckligt med pengar på kontot");
                saldo = saldo + uttag;
                Console.WriteLine();
            }
            Console.WriteLine("Ditt saldo är: " + saldo + " kr");
            break;

        // Saldo på transaktionskonto
        case "S":
        case "s":
            Console.WriteLine("Ditt saldo är: " + saldo);
            break;

        // Beräkna hur mycket du får ihop med ett årligt sparande med en viss ränta
        case "R":
        case "r":
            do
            {
                validInput = false;
                Console.WriteLine(" I hur många år vill du spara? ");
                string input3 = Console.ReadLine();
                if (int.TryParse(input3, out år))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Använd bara siffror");
                    Console.WriteLine();
                }
            } while (!validInput);
            do
            {

                validInput = false;
                Console.WriteLine("Hur mycket pengar vill du spara per år");
                string input4 = Console.ReadLine();
                if (int.TryParse(input4, out insättningSparande))
                {

                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Använd bara siffror");
                    Console.WriteLine();
                }
            } while (!validInput);
            do
            {
                validInput = false;
                Console.WriteLine("Vilken ränta har du? ");
                string input5 = Console.ReadLine();
                if (double.TryParse(input5, out ränta))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Använd bara siffror");
                    Console.WriteLine();
                }
            } while (!validInput);
            årsränta = ränta / 100 + 1;

            // beräkning
            sparSaldo = insättningSparande;

            while (antalInsättningar < år)
            {
                antalInsättningar++;

                sparSaldo = sparSaldo * årsränta + insättningSparande;
            }
            sparSaldoSum = Math.Round(sparSaldo * 2);  //Avrundning till två decimaler

            //Svars meddelande
            Console.WriteLine("Om du sätter in " + insättningSparande + " om året och har en ränta på " + ränta + "procent kommer du på " + år + "år ha sparat ihop");
            Console.WriteLine(sparSaldoSum + " kr");
            Console.WriteLine();

            break;

        // Avslutar programmet och hoppar ur while loopen
        case "A":
        case "a":
            Console.WriteLine("Tack för besöket välkommen åter");
            return;


        //Meddelande vid fel inmatning i Meny läge
        default:
            Console.WriteLine("Fel inmatning!");
            Console.WriteLine();
            Console.WriteLine("Du kan bara välja på ");
            Console.WriteLine();
            Console.WriteLine("I för insättning ");
            Console.WriteLine("U för uttag ");
            Console.WriteLine("S för saldo");
            Console.WriteLine("R för räntebetalning");
            Console.WriteLine("A för att avsluta");
            Console.WriteLine();
            break;
    }
}
