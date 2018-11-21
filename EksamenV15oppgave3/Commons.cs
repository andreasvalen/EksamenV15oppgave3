using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenV15oppgave3 //Husk å endre!
{
    public static class Commons
    {
        /// <summary>
        /// Spør etter en gylidig int. Godtar ikke variablen før brukeren taster inn en int.
        /// </summary>
        public static int GetIntConsole(string feilmelding = "", int minVerdi = Int32.MinValue, int maksVerdi = Int32.MaxValue)
        {
            int i;
            while (!(int.TryParse(Console.ReadLine(), out i)))
            {
                if (feilmelding.Length > 0)
                    Console.WriteLine(feilmelding);
            }
            if (i < minVerdi || i > maksVerdi)

            {
                Console.WriteLine($"Verdien er ikke innenfor grensen, skriv inn en verdi mellom {minVerdi} og {maksVerdi}");
                return GetIntConsole(feilmelding, minVerdi, maksVerdi);
            }
            return i;
        }
        /// <summary>
        /// Skriver en streng til en fil
        /// </summary>
        public static void SkrivTilFil(string filplassering, string tekstTilFil, bool append = false)
        {
            if (append)
            {
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(filplassering))
                {
                    sw.WriteLine(tekstTilFil);
                }
            }
            else
            {
                string[] tekst = new string[] {tekstTilFil};
                System.IO.File.WriteAllLines(filplassering, tekst);
            }
        }
        /// <summary>
        /// Skriver et array til en fil
        /// </summary>
        public static void SkrivTilFil(string filplassering, string[] tekstTilFil, bool append = false)
        {
            if (append)
            {
                using (System.IO.StreamWriter sw = System.IO.File.AppendText(filplassering))
                {
                    foreach (string linje in tekstTilFil)
                    {
                        sw.WriteLine(linje);
                    }
                }
            }
            else
            {
                System.IO.File.WriteAllLines(filplassering, tekstTilFil);
            }
        }
        /// <summary>
        /// Leser fra en fil og returnerer ny array med innholdet
        /// </summary>
        public static string[] LesFraFil(string filplassering, int fjernOverskriftLinjer = 0)
        {
            try
            {
                string[] tekstlinjerFraFil = System.IO.File.ReadAllLines(filplassering);
                if (fjernOverskriftLinjer != 0)
                {
                    Array.Copy(tekstlinjerFraFil,fjernOverskriftLinjer, (tekstlinjerFraFil=new string[tekstlinjerFraFil.Length- fjernOverskriftLinjer]),0,tekstlinjerFraFil.Length);
                }
                return tekstlinjerFraFil;
            }
            catch (System.IO.FileNotFoundException)
            {
                return new string[] {$"Fant ikke filen {filplassering}"};
            }
        }
    }
}
