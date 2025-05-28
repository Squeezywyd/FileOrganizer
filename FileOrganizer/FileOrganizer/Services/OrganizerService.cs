using FileOrganizer.Models;
using FileOrganizer.Utils;

namespace FileOrganizer.Services
{
    public class OrganizerService
    {
        private readonly string _path;
        private readonly List<FileActionLog> _logs = new();

        public OrganizerService(string path)
        {
            _path = path;
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n-- Hauptmenü --");
                Console.WriteLine("1. Nach Dateityp sortieren");
                Console.WriteLine("2. Nach Erstellungsdatum sortieren");
                Console.WriteLine("3. Duplikate erkennen");
                Console.WriteLine("4. Ordnerstatistik anzeigen");
                Console.WriteLine("5. Aktionen speichern (log.txt)");
                Console.WriteLine("0. Zurück");
                Console.Write("Auswahl: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": SortByType(); break;
                    case "2": SortByDate(); break;
                    case "3": DetectDuplicates(); break;
                    case "4": ShowStats(); break;
                    case "5": SaveLogs(); break;
                    case "0": return;
                    default: Console.WriteLine("Ungültige Auswahl."); break;
                }
            }
        }

        private void SortByType()
        {
            Console.WriteLine("\n📁 Sortiere nach Dateityp...");
            var files = Directory.GetFiles(_path);

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).TrimStart('.').ToLower();
                var targetDir = Path.Combine(_path, ext);
                Directory.CreateDirectory(targetDir);
                var targetPath = Path.Combine(targetDir, Path.GetFileName(file));
                if (File.Exists(targetPath)) targetPath = Path.Combine(targetDir, $"{Guid.NewGuid()}_{Path.GetFileName(file)}");

                File.Move(file, targetPath);
                _logs.Add(new FileActionLog { Timestamp = DateTime.Now, FileName = file, Action = "Typ-Sortierung", TargetPath = targetPath });
            }

            Console.WriteLine("Sortierung abgeschlossen.");
        }

        private void SortByDate()
        {
            Console.WriteLine("\nSortiere nach Erstellungsdatum...");
            var files = Directory.GetFiles(_path);

            foreach (var file in files)
            {
                var creationDate = File.GetCreationTime(file).ToString("yyyy-MM-dd");
                var targetDir = Path.Combine(_path, creationDate);
                Directory.CreateDirectory(targetDir);
                var targetPath = Path.Combine(targetDir, Path.GetFileName(file));
                if (File.Exists(targetPath)) targetPath = Path.Combine(targetDir, $"{Guid.NewGuid()}_{Path.GetFileName(file)}");

                File.Move(file, targetPath);
                _logs.Add(new FileActionLog { Timestamp = DateTime.Now, FileName = file, Action = "Datum-Sortierung", TargetPath = targetPath });
            }

            Console.WriteLine("Sortierung abgeschlossen.");
        }

        private void DetectDuplicates()
        {
            Console.WriteLine("\nSuche nach Duplikaten...");
            var files = Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories);
            var duplicates = DuplicateHelper.FindDuplicates(files);

            foreach (var dup in duplicates)
            {
                Console.WriteLine($"Duplikat gefunden: {dup}");
                _logs.Add(new FileActionLog { Timestamp = DateTime.Now, FileName = dup, Action = "Duplikat entdeckt", TargetPath = _path });
            }

            Console.WriteLine("Suche abgeschlossen.");
        }

        private void ShowStats()
        {
            Console.WriteLine("\nOrdnerstatistik:");
            var files = Directory.GetFiles(_path, "*.*", SearchOption.AllDirectories);
            var grouped = files.GroupBy(f => Path.GetExtension(f).ToLower())
                               .Select(g => new { Extension = g.Key, Count = g.Count(), Size = g.Sum(f => new FileInfo(f).Length) });

            foreach (var group in grouped)
            {
                Console.WriteLine($"• {group.Extension}: {group.Count} Dateien, {group.Size / 1024.0:F2} KB");
            }
        }

        private void SaveLogs()
        {
            var logPath = Path.Combine(_path, "log.txt");
            File.WriteAllLines(logPath, _logs.Select(l => l.ToString()));
            Console.WriteLine($"Log gespeichert unter: {logPath}");
        }
    }
}