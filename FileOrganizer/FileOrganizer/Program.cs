using FileOrganizer.Services;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Willkommen beim FileOrganizer!");

        while (true)
        {
            Console.Write("Geben Sie den Pfad zu einem Ordner ein (oder 'exit' zum Beenden): ");
            string path = Console.ReadLine() ?? "";
            if (path.ToLower() == "exit") break;

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Pfad nicht gefunden. Versuchen Sie es erneut.");
                continue;
            }

            var organizer = new OrganizerService(path);
            organizer.MainMenu();
        }

        Console.WriteLine("Auf Wiedersehen!");
    }
}