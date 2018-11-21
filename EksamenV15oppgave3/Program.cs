using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenV15oppgave3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> linjerFraFil = new List<string>(Commons.LesFraFil("oppg3-data.txt", 2));
            string [] snitt = new string[linjerFraFil.Count];
            Console.WriteLine("Antall linjer lest: " + linjerFraFil.Count);
            int i = 0;
            foreach(string linje in linjerFraFil)
            {
                string[] verdier = linje.Split(' ');
                double verdi1 = Convert.ToDouble(verdier[0]);
                double verdi2 = Convert.ToDouble(verdier[1]);
                double gjennomsnitt = (verdi1 + verdi2) / 2;
                double delta = verdi1 - verdi2;//studasskommentar: Fungerer nå, men ikke hvis verdi1 er positiv og verdi2 er negativ
                if (Math.Abs(delta) > 2)
                {
                    Console.WriteLine($"Verdier på linje {i} har differanse større enn 2. Differansen er {delta:F3}");
                }
                snitt[i]=Convert.ToString(gjennomsnitt);
                i++;
            }
            double sum = 0;
            foreach(string tall in snitt)
            {
                double verdi = Convert.ToDouble(tall);
                sum += verdi;
                
            }
            double totalgjennomsnitt = sum / 20;
            double max = 0;
            double min = 100;
            foreach(string s in snitt)
            {
                double v = Convert.ToDouble(s);
                if (v > max)
                {
                    max = v;
                }
                else if (v < min)
                {
                    min = v;
                }

            }
            Console.WriteLine("Totalt gjennomsnitt: "+totalgjennomsnitt);
            Console.WriteLine("Maksimumverdi: " +max);
            Console.WriteLine("Minimumverdi: "+min);
            Commons.SkrivTilFil("oppg3-rapport.txt", snitt, false);
            Console.ReadKey();
        }
    }
}
