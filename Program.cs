namespace RemoDome
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}

/*
1. forzare tutti i sensori sulla posizione dei piedini
2. aggiungere il sensore di nord ed il piedono 
3. Togliere tutta la didascalia dei controlli della seriale
4. Togliere tutti i controlli di modifica della seriale
*/