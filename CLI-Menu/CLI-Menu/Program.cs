namespace CLI.Menu.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int option = CLI.SelectOption("Kontostand abfragen", "Einzahlung", "Auszahlung", "Überweisung", "Kontoauszuüge drucken", "Beenden");

            switch (option)
            {
                case 0:
                    Console.WriteLine("Kontostand abfragen");
                    break;
                case 1:
                    Console.WriteLine("Einzahlung");
                    break;
                case 2:
                    Console.WriteLine("Auszahlung");
                    break;
                case 3:
                    Console.WriteLine("Überweisung");
                    break;
                case 4:
                    Console.WriteLine("Kontoauszüge drucken");
                    break;
                case 5:
                    Console.WriteLine("Beenden");
                    break;
                default:
                    break;
            }
        }
    }
}