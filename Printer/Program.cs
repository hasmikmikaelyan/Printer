using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please load paper!");
            //int paperCount = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the count of printing pages!");
            //int printingPagesCount = int.Parse(Console.ReadLine());

            var hp = new Printer("HP");
            var canon = new Printer("Canon");

            hp.PrintStarted += Hp_PrintStarted;
            hp.Printing += Hp_Printing; 
            hp.PrintFailed += Hp_PrintFailed;
            hp.PrintFinished += Hp_PrintFinished;

            //hp.LoadPaper(paperCount);
            //hp.Print(printingPagesCount);

            hp.LoadPaper(5);
            hp.Print(8);

        }

        private static void Hp_PrintStarted(object sender, EventArgs e)
        {
            Console.WriteLine("PRINT STARTED!");
        }

        private static void Hp_Printing(object sender, PrintingEventArgs e)
        {
            Console.WriteLine("HP printer is printing paper number {0}", e.PaperCount);
        }

        private static void Hp_PrintFailed(object sender, PrintFailedEventArgs e)
        {
           Console.WriteLine("PRINT FAILED! There is no enough paper! Remaining {0} pages to print!", e.RemainingPages);
        } 

        private static void Hp_PrintFinished(object sender, EventArgs e)
        {
            Console.WriteLine("PRINT FINISHED!");
        }

    }
}
