namespace FileOrganizer.Models
{
    public class FileActionLog
    {
        public DateTime Timestamp { get; set; }
        public string FileName { get; set; }
        public string Action { get; set; }
        public string TargetPath { get; set; }

        public override string ToString()
        {
            return $"> [{Timestamp}] {Action} | Datei: {Path.GetFileName(FileName)} -> {TargetPath}";
        }
    }
}