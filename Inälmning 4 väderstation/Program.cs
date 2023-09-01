// See https://aka.ms/new-console-template for more information
using Inälmning_4_väderstation;
using System.Collections.Generic;



// En rolig och bra uppgift jag har i detta program valt att skriva ut listan efter varje sortering 
// för att ge användaren en tydlighet i vad som händer 
// Jag är medveten om att om man gjort en större lista hade det varit ohållbartför att det då inte skulle varit överskådligt 
// men här och nu tyckte jag det var trevligt
class program
{

    public static void Main(string[] args)
    {



        //Välkomst meddelande
        Console.WriteLine("Välkommen till väder stationen");
        Console.WriteLine();

        // definiering av listan som kommer att användas genom hela programmet
        List<Stad> lista = new List<Stad>();
        Console.WriteLine("Skriv in en lista med städer");

        // Deklaration av flagga för introduktions loop. Detta är en intorduktion där användaren skapar en lista som 
        // Man kan fortsätta att jobba i senare. Anledningen till detta är att vissa av funktionerna som kommer senare behöver en lista 
        // för att fungera och på detta sättet undviker jag att programmet krachar.
        bool introLoop = true;

        while (introLoop)
        {
            bool temperatur = false;

            Stad myStad = new Stad();

            // här ger man staden ett namn, Detta är en sträng och kommer att acceptera vilket namn som helst
            Console.WriteLine();
            Console.WriteLine("Vilket namn har staden? ");
            myStad.namn = Console.ReadLine();

            // Här för du in vilken temperatur som staden har. Här är inmatningen begränsad till ett heltal
            // mellan -60 och 60. När inmatningen är kontrollerad läggs stad och temp till i listan
            Console.WriteLine();
            Console.WriteLine("Vad är det för Temperatur i staden? ");
            string str = Console.ReadLine();

            if (int.TryParse(str, out myStad.temp) && myStad.temp >= -60 && myStad.temp <= 60)
            {
                temperatur = true;
                lista.Add(myStad);
            }
            else
            {   // om Temperaturen inte stämmer får man skriva in den igen
                Console.WriteLine("Felaktig inmatning Temperaturen behöver vara ett heltal mellan -60 och 60 grader");
                temperatur = false;
            }
            // Skriver ut listan med städer så att man kan se vad man fyllt i och inte tappar bort sig
            Console.WriteLine();
            foreach (Stad stad in lista)
            {
                Console.WriteLine(stad.ToString());
            }

            while (introLoop)// Här väljer du om du vill lägga till fler städer om inte går du vidare i programmet
            {
                Console.WriteLine();
                Console.WriteLine("Vill du föra in en ny stad? J/N ");
                string str1 = Console.ReadLine();

                if (str1 == "j" || str1 == "J")
                {
                    break;
                }
                else if (str1 == "n" || str1 == "N")
                {
                    introLoop = false;
                 
                }
                else
                {
                    Console.WriteLine("Ogiltigt val endast J eller N");
                }
            }

        }


        while (true)
        {   
            // här är menyn indelad i två delar första delen är första uppgifterna och andra delen är tilläggsuppgifter

            Console.WriteLine();
            Console.WriteLine("[N]y stad");
            Console.WriteLine("[S]ök efter en stad med enspeciell temperatur"); // Linjär sökning
            Console.WriteLine("[O]rdna städerna kallast först");// Bubbel sort
            Console.WriteLine();
         
            // Tilläggs uppgift
            Console.WriteLine("[P] sortera städerna kallast först");// Selection sort
            Console.WriteLine("[T] sökefter en speciell temperatur"); // Binär sökning
            Console.WriteLine("[H]ögst temperatur");
            Console.WriteLine("[L]ägsta temperatur");
            Console.WriteLine("[A]vsluta");

            string val = Console.ReadLine();


            // här kan du lägga till en ny stad som då kommer att läggas sist i din ursprungliga lista
            // Den delen fungerar som första delen med undantaget att man lägger till en stad i taget
            if (val == "n" || val == "N") 
            {
                bool temperatur = false;

                Stad myStad = new Stad();

                Console.WriteLine("Vilket namn har staden? ");
                myStad.namn = Console.ReadLine();
                Console.WriteLine("Vad är det för Temperatur i staden? ");
                string str = Console.ReadLine();

                if (int.TryParse(str, out myStad.temp) && myStad.temp >= -60 && myStad.temp <= 60)
                {
                    temperatur = true;
                    lista.Add(myStad);
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning Temperaturen behöver vara ett heltal mellan -60 och 60 grader");
                    temperatur = false;
                }
                foreach (Stad stad in lista)
                {
                    Console.WriteLine(stad.ToString());
                }
            }


            //Den här delen åberopar en linjär sökning efter en temperatur och ger tillbaka index för staden med den temperaturen 
            //om den inte hittas meddelar programmet detta
            else if (val == "s" || val == "S")
            {
                Console.WriteLine("Skriv in en temperatur: ");
                string str = Console.ReadLine();

                if (!int.TryParse(str, out int key) && key >= -60 && key <= 60)
                {
                    Console.WriteLine("Felaktig inmatning Temperaturen behöver vara ett heltal mellan -60 och 60 grader");
                }
                else
                {
                    int pos = Stad.LinSok(lista, lista.Count, key);

                    if (pos == -1)
                    {
                        Console.WriteLine($"Inga städer hittades med temperaturen {key} grader");
                    }
                    else
                    {
                        Console.WriteLine($"Hittades med index {pos}");
                    }
                }
            }


            // Detta är en sorterings funktion som sorterar listan i stigande ordning med den lägsta temperaturen först
            // Metod som används är en bubble sort metod
            else if (val == "o" || val == "O")
            {
                lista = Stad.BubbelSort(lista);

                Console.WriteLine();
                foreach (Stad stad in lista)
                {
                    Console.WriteLine(stad.ToString());
                }
            }


            // Detta är en sorterings funktion som sorterar listan i stigande ordning med den lägsta temperaturen först
            // Metod som används är en selection sort metod
            else if (val == "p" || val == "P")
            
            {
                lista = Stad.SelectionSort(lista);
                foreach (Stad stad in lista)
                {
                    Console.WriteLine(stad.ToString());
                }
            }

            //Den här delen åberopar en binär sökning efter en temperatur och ger tillbaka index för staden med den temperaturen 
            //om den inte hittas meddelar programmet detta
            //Eftesom en binär sökning kräver att listan är sorterad kör vi först en selection sort så att vi vet att allt ligger i ordning
            else if (val == "t" || val == "T")            
            {
                lista = Stad.SelectionSort(lista);

                Console.WriteLine("Vilken temperatur söker du? ");
                string str = Console.ReadLine();

                if (!int.TryParse(str, out int key) && key >= -60 && key <= 60)
                {
                    Console.WriteLine("Felaktig inmatning Temperaturen behöver vara ett heltal mellan -60 och 60 grader");
                }
                int pos = Stad.BinSök(lista, lista.Count, key);

                if (pos == -1)
                {
                    Console.WriteLine($"Inga städer hittades med temperaturen {key} grader");
                }
                else
                {
                    Console.WriteLine($"Hittades med index {pos}");
                }
                Console.WriteLine();    
                foreach (Stad stad in lista)
                {
                    Console.WriteLine(stad.ToString());
                }
            }

            // Tar fram staden med högsta temp
            else if (val == "h" || val == "H")
            {
                string lastElement = Stad.HögstaTemp(lista);

                Console.WriteLine($"Staden med den högsta temperaturen är {lastElement}");
            }


            //Tar fram staden med lägsta temp
            else if (val == "l" || val == "L")
            {
                string firstElement = Stad.LägstaTemp(lista);

                Console.WriteLine($"Staden med lägst temperatur är {firstElement}");
            }


            // Val för att avsluta programmet 
            else if (val == "a" || val == "A")
            {
                Console.WriteLine("Tack för att du användt dig av oss för att hantera dina väderdata");
                Console.WriteLine("Välkommen åter");
                return;
            }
            else
            {
                Console.WriteLine("Du har gjort ett felktigt val välj mellan bokstäverna innan för []");
            }
        }
    }
}






