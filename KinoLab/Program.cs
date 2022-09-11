using KinoLab.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //1st Stage:
            //Επιλογή απο χρήστη 6 Μοναδικών αριθμών απο το 1 - 80
            //Επιλογή απο χρήστη αν θα παίξει Κινο Bonus

            //Κλήρωση 1 - 80(20 Αριθμών Μοναδικών UNIQUE)(19 + 1 ο τελευταίος θα είναι το ΚΙΝΟ BONUS)

            //Παρουσίαση αποτελέσματος ως εξής:
            //Ο χρήστης έπιασε Χ(0 - 6) νούμερα
            //Ο χρήστης εφόσον επίλεξε Κινο Bonus κέρδισε ή ΟΧΙ(NAI -OXI)

            KinoService.StartKinoGame();
        }
    }
}
