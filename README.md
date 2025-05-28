## Projektbeschreibung

FileOrganizer ist ein vielseitiges C#-Konsolenprogramm zur automatisierten Verwaltung und Strukturierung von lokalen Dateien. Die Anwendung bietet Werkzeuge, um grosse Mengen unsortierter Dateien effizient zu analysieren, zu ordnen und zu bereinigen. Der Fokus liegt auf einfacher Bedienung über die Konsole, praktischer Funktionalität für den Alltag und einem sauberen, modularen Codeaufbau.

### Motivation

Viele Nutzer:innen haben im Laufe der Zeit überfüllte Ordner, wie z. B. den Download-Ordner oder Projektverzeichnisse mit hunderten Dateien verschiedenster Formate. Manuelles Sortieren ist fehleranfällig und zeitaufwändig. FileOrganizer löst dieses Problem automatisiert und nachvollziehbar – lokal und ohne zusätzliche Softwareinstallation.

### Zielgruppe

- Privatpersonen mit überfüllten Ordnern
- Entwickler:innen und Studierende, die viele Projektdateien handhaben
- KMUs mit strukturlosen Dateiablagen
- Alle, die Ordnung in ihre Dateisysteme bringen möchten

### Hauptfunktionen

- **Sortierung nach Dateityp**: Erstellt automatisch Ordner für jede Dateiendung und verschiebt Dateien entsprechend.
- **Sortierung nach Erstellungsdatum**: Sortiert Dateien in Tagesordner (z. B. `2024-10-21`) zur besseren chronologischen Übersicht.
- **Duplikaterkennung**: Identifiziert doppelte Dateien durch MD5-Hash-Vergleich – unabhängig vom Dateinamen.
- **Statistikanzeige**: Zeigt Anzahl und Gesamtgrösse pro Dateityp.
- **Logbuchfunktion**: Protokolliert alle Aktionen (Verschieben, Erkennung etc.) in `log.txt`.

### Technologie-Stack

- Programmiersprache: **C#**
- Framework: **.NET 6+**
- Kernbibliotheken: `System.IO`, `System.Security.Cryptography`, `LINQ`
- Keine externen Abhängigkeiten



