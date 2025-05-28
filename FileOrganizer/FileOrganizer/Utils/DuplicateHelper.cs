namespace FileOrganizer.Utils
{
    public static class DuplicateHelper
    {
        public static List<string> FindDuplicates(string[] files)
        {
            var duplicates = new List<string>();
            var fileHashes = new Dictionary<string, string>();

            foreach (var file in files)
            {
                try
                {
                    using var md5 = System.Security.Cryptography.MD5.Create();
                    using var stream = File.OpenRead(file);
                    var hash = BitConverter.ToString(md5.ComputeHash(stream));

                    if (fileHashes.ContainsKey(hash))
                        duplicates.Add(file);
                    else
                        fileHashes[hash] = file;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Fehler beim Prüfen von {file}: {ex.Message}");
                }
            }

            return duplicates;
        }
    }
}