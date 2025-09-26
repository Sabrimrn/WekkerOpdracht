using System;
using System.Threading;

delegate void Alarmtype();

class Program

{   static Alarmtype alarmtype = new Alarmtype(dummy);
    static Timer timer = new Timer(Start);
    static int seconden;
    static int sluimertijd;
    static int keuze;

    static void Main()
    {
        do {
            Console.WriteLine("Alarm menu:");
            Console.WriteLine("1. Stel de tijd in waarop het alarm afgaat");
            Console.WriteLine("2. Stel de sluimertijd in");
            Console.WriteLine("3. Kies het alarmtype (geluid, boodschap, knipperlicht, combinatie)");
            Console.WriteLine("4. Start het alarm");
            Console.WriteLine("5. Stop het alarm");
            Console.Write("Maak een keuze: ");
            keuze = int.Parse(Console.ReadLine());

            switch (keuze)
            {
                case 1:
                    Console.Write("Voer het aantal seconden in waarna het alarm moet afgaan: ");
                    seconden = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Voer de sluimertijd in (in seconden): ");
                    sluimertijd = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Kies het alarmtype:");
                    Console.WriteLine("1. Geluid");
                    Console.WriteLine("2. Boodschap");
                    Console.WriteLine("3. Knipperlicht");
                    Console.WriteLine("4. Combinatie");
                    int typeKeuze = int.Parse(Console.ReadLine());
                    switch (typeKeuze)
                    {
                        case 1:
                            alarmtype = new Alarmtype(Geluid);
                            break;
                        case 2:
                            alarmtype = new Alarmtype(Boodschap);
                            break;
                        case 3:
                            alarmtype = new Alarmtype(Knipperlicht);
                            break;
                        case 4:
                            alarmtype = new Alarmtype(Combinatie);
                            break;
                        default:
                            Console.WriteLine("Ongeldige keuze, standaard geluid geselecteerd.");
                            alarmtype = new Alarmtype(Geluid);
                            break;
                    }
                    break;
                case 4:
                    timer.Change(seconden * 1000, Timeout.Infinite);
                    Console.WriteLine("Alarm gestart.");
                    break;
                case 5:
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                    Console.WriteLine("Alarm gestopt.");
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze, probeer het opnieuw.");
                    break;
            }

        }while (keuze != 5);
    }

    static void Geluid()
    {
        Console.Beep();
        Console.WriteLine("Alarm: Geluid!");
    }

    static void Boodschap()
    {
        Console.WriteLine("Alarm: Tijd om op te staan!");
    }

    static void Knipperlicht()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.BackgroundColor = Console.BackgroundColor == ConsoleColor.Black ? ConsoleColor.White : ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(200);
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Alarm: Knipperlicht!");
    }

    // Optioneel: combinatie van alle manieren
    static void Combinatie()
    {
        Geluid();
        Boodschap();
        Knipperlicht();
    }

    // Dummy-methode voor initialisatie
    static void dummy() { }

    // Voorgestelde methoden
    static void Start(object state)
    {
        alarmtype();
        if (sluimertijd > 0)
        {
            timer.Change(sluimertijd * 1000, Timeout.Infinite);
        }
    }
}