using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int secondsElapsed = 0; // Variable für den Timer
        private List<string> recentFiles = new List<string>(); // Liste der zuletzt verwendeten Dateien
        private bool isFileSelected = false; // Flag, um die MessageBox nur einmal anzuzeigen da diese öfters angezeigt wurde

        // Registry angabe
        private string registryKeyPath = @"SOFTWARE\WinFormsApp1";

        public Form1()
        {
            InitializeComponent();

            // Drag-and-Drop für die Dropdownliste aktivieren
            comboBox1.AllowDrop = true;

            // DragEnter- und DragDrop-Ereignisse registrieren
            comboBox1.DragEnter += ComboBox1_DragEnter;
            comboBox1.DragDrop += ComboBox1_DragDrop;

            // Laden der zuletzt geöffneten Dateien
            LoadRecentFiles();

            timer1.Start(); // Der Timer startet, sobald das Programm sich öffnet
        }

        // Methode zum Laden und Anzeigen der Log-Datei in der DataGridView
        private void LoadLogFileAndDisplay(string path)
        {
            LogFileNew logFile = new LogFileNew(path);
            logFile.LoadFile();

            // DataTable erstellen und LogLines (Typ,Zeit,Nutzerinformationen hinzufügen)
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TYP");
            dataTable.Columns.Add("ZEIT");
            dataTable.Columns.Add("Nutzerinformation");

            foreach (var logLine in logFile.LogLines)           // dieser Prozess läuft nun in den 2 neuen Klassen     
            {
                DataRow row = dataTable.NewRow();
                row["TYP"] = logLine.Typ;
                row["ZEIT"] = logLine.Zeit;
                row["Nutzerinformation"] = logLine.Nutzerinformation;
                dataTable.Rows.Add(row);
            }

            // DataGridView anzeigen
            dataGridView1.DataSource = dataTable;
        }

        // Methode, um die Dateien mit Fortschrittsanzeige zu laden
        private void LoadFilesToComboBoxWithProgress(string folderPath)
        {
            // Setze den Anfangswert der ProgressBar
            progressBar1.Value = 0;
            progressBar1.Maximum = 100; // Maximum für 100%

            // Die dropdown liste leer machen damit die Zuletzt geöffneten daten reinkommen 
            comboBox1.Items.Clear();

            if (Directory.Exists(folderPath))
            {
                // Alle Dateien im Ordner holen
                string[] files = Directory.GetFiles(folderPath);

                int totalFiles = files.Length;
                int currentFile = 0;

                // for, um alle Dateien im Ordner zu durchlaufen
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    comboBox1.Items.Add(fileName);

                    // Berechne den Fortschritt als Prozentsatz
                    currentFile++;
                    int progress = (int)((double)currentFile / totalFiles * 100);

                    // Aktualisiere die ProgressBar
                    progressBar1.Value = progress;

                    // Update der UI, um die ProgressBar zu aktualisieren
                    Application.DoEvents();
                }
            }
        }

        // Methode zum Speichern der Namen der zuletzt geöffneten Dateien in der Registry
        private void SaveRecentFiles()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKeyPath))
                {
                    if (key == null)
                        throw new Exception("Failed to create or access registry key.");

                    key.SetValue("RecentFiles", string.Join("|", recentFiles));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Dateien in der Registry: {ex.Message}");
            }
        }

        // Methode zum Laden der zuletzt geöffneten Dateien aus der Registry
        private void LoadRecentFiles()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
                {
                    if (key != null)
                    {
                        string? files = key.GetValue("RecentFiles") as string;
                        if (!string.IsNullOrEmpty(files))
                        {
                            recentFiles = files.Split('|').ToList();
                            comboBox1.Items.AddRange(recentFiles.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Dateien aus der Registry: {ex.Message}");
            }
        }

        // die zuletzt verwendeten Dateien zu aktualisieren
        private void UpdateRecentFiles(string selectedFile)
        {
            // Wenn die Datei bereits in der Liste ist, entferne sie
            if (recentFiles.Contains(selectedFile))
            {
                recentFiles.Remove(selectedFile);
            }

            // Füge die Datei an den Anfang der Liste hinzu ( 0 für den anfang)
            recentFiles.Insert(0, selectedFile);

            // Behalte nur die letzten 5 Dateien
            if (recentFiles.Count > 5)
            {
                recentFiles.RemoveAt(5);
            }

            // Update der Dropdown-Liste mit den zuletzt verwendeten Dateien
            comboBox1.Items.Clear();
            foreach (var file in recentFiles)
            {
                comboBox1.Items.Add(file);
            }

            // Speichere die Liste der zuletzt geöffneten Dateien
            SaveRecentFiles();
        }

        // Timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Timer +1 Sekunde
            secondsElapsed++;

            // Berechne Stunden, Minuten und Sekunden
            int hours = secondsElapsed / 3600;
            int minutes = (secondsElapsed % 3600) / 60;
            int seconds = secondsElapsed % 60;

            // Zeit in TextBox anzeigen
            textBox2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }

        // Button für das Laden des Explorer-Dialogs
        private void Button2_Click(object sender, EventArgs e)
        {
            // Folder Explorer Dialog Knopf
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Wenn ein Ordner ausgewählt wird, lade die Dateien mit Fortschritt
                LoadFilesToComboBoxWithProgress(folderBrowserDialog1.SelectedPath);
            }
        }

        // Placeholder für den Start der Analyse
        private void Knopf(object sender, EventArgs e)
        {
            // Placeholder für den Start der Analyse
            MessageBox.Show("Analyse Gestartet.");

            // Zeige die Fortschrittsanzeige an und starte die Analyse
            progressBar1.Visible = true;
            progressBar1.Value = 0; // Setze den Anfangswert auf 0%

            // Starte den Ladevorgang der Dateien und aktualisiere den Fortschritt
            LoadFilesToComboBoxWithProgress(folderBrowserDialog1.SelectedPath);

            // Aktualisiere die UI während des Ladevorgangs
            Application.DoEvents(); // Stellt sicher, dass die UI aktualisiert wird
        }

        // Eventhandler für die Auswahl einer Datei in der ComboBox
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedFile = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFile) && !isFileSelected)
            {
                MessageBox.Show($"Die Log Datei: {selectedFile} wurde ausgewählt.");
                UpdateRecentFiles(selectedFile);
                isFileSelected = true;

                // Lade die ausgewählte Log-Datei und zeige sie an
                LoadLogFileAndDisplay(Path.Combine(folderBrowserDialog1.SelectedPath, selectedFile));
            }
            else
            {
                isFileSelected = false;
            }
        }

        // Drag-and-Drop: DragEnter-Ereignis
        private void ComboBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Drag-and-Drop: DragDrop-Ereignis
        private void ComboBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    // Datei zur ComboBox hinzufügen
                    comboBox1.Items.Add(fileName);

                    // Datei zur Liste der zuletzt verwendeten Dateien hinzufügen
                    UpdateRecentFiles(fileName);
                }

                MessageBox.Show("Dateien wurden erfolgreich hinzugefügt.");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void TextBox3_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void progressBar1_Click(object sender, EventArgs e) { }
    }
}
