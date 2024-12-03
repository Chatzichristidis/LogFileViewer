using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class LogFileNew
    {
        public string Dateipfad { get; set; }
        public List<LogLineNew> LogLines { get; private set; }

        public LogFileNew(string path)
        {
            Dateipfad = path;
            LogLines = new List<LogLineNew>();
        }

        // Methode zum Einlesen der Datei und Erstellen von LogLine-Objekten für DPU6 und DPU7 Dateien
        public void LoadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Dateipfad))
                {
                    string sLine;
                    while ((sLine = sr.ReadLine()) != null)
                    {
                        
                        string typ = string.Empty; // Variable damit wir "DPU" für die DPU 6 dateien einlesen

                        
                        if (sLine.StartsWith("DPU"))// check ob die Linien mit DPU anfangen was auf eine DPU 6 Datei verweist
                        {
                            
                            int spaceIndex = sLine.IndexOf(" ");
                            if (spaceIndex > 0) // mindestens 1 spacebar nach dem DPU
                            {
                                typ = sLine.Substring(0, spaceIndex); // Hier wird das "DPU" in den Typen überschrieben
                            }

                            // wir splitten den rest in 2 Teile. Erstmal den Timestamp der alles übernimmt und dann alles nach dem ersten : . (Der erste : nach dem Timestamp natürlich) 
                            string[] parts = sLine.Split(new string[] { " : " }, StringSplitOptions.None);

                            if (parts.Length == 3)
                            {
                                string timestamp = parts[0].Trim(); // Timestamp im Format "yyyy-mm-dd hh:mi:ss.fff"
                                string userInfo = parts[2].Trim(); // Alles nach der TimeStamp und dem : ist die Nutzerinformation (userinfo)

                                LogLineNew logLine = new LogLineNew  //die Klasse LogLineNew die wir erstellt haben wird hier aufgerufen 
                                {
                                    Typ = typ, // hier wird der Typ also das "DPU" übernommen 
                                    Zeit = timestamp, // Timestamp im Format "yyyy-mm-dd hh:mi:ss.fff"
                                    Nutzerinformation = userInfo  // Nutzerinformation alles nach dem : nach der Zeit
                                };

                                LogLines.Add(logLine); // in die DropDown Liste adden
                            }
                        }
                        else          // wenn es keine DPU 6 File ist case
                        {
                             //dann übernehmen wir den Typ automatisch als DPUSCAN
                            string[] parts = sLine.Split(new string[] { " Dpuscan  " }, StringSplitOptions.None);  // das "DPUscan  " wird zum splitten benutzt um die zeit und den Typ zu erfahren
                                                                                                // 2 leertasten werden noch mitgezogen 
                            if (parts.Length == 2)
                            {
                                string timestamp = parts[0].Trim(); // Timestamp ist alles vor "dpuscan"
                                string userInfo = parts[1].Trim(); // Alles nach "dpuscan" ist die Nutzerinformation

                                LogLineNew logLine = new LogLineNew
                                {
                                    Typ = "Dpuscan", // Hier haben wir ein Default Typ eingeführt da DPUSCAN in allen DPU 7 DATEIEN DER TYP IST
                                    Zeit = timestamp, // Timestamp vor "DPUSCAN"
                                    Nutzerinformation = userInfo // Nutzerinformation alles nach "Dpuscan"
                                };

                                LogLines.Add(logLine); // in die DropDown Liste adden
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Einlesen der Log-Datei: {ex.Message}"); // error message 
            }
        }
    }
}
