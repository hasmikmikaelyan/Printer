using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class Printer
    { 
        public Printer(string name)
        {
            Name = name; 
        } 
 
         #region Events 
         public event EventHandler PrintStarted; 
 
         public event EventHandler PrintFinished; 
 
         public event EventHandler<PrintingEventArgs> Printing; 
 
         public event EventHandler<PrintFailedEventArgs> PrintFailed; 
         #endregion 
 
 
         #region Event Raising 
         protected virtual void OnPrintStarted(EventArgs e)
         {
                PrintStarted?.Invoke(this, EventArgs.Empty);
         } 
 
         protected virtual void OnPrintFinished(EventArgs e)
         {
                PrintFinished?.Invoke(this, EventArgs.Empty);
         } 
 
 
         protected virtual void OnPrinting(PrintingEventArgs e)
         { 
                Printing?.Invoke(new object(), e);
         } 
 
 
         protected virtual void OnPrintFailed(PrintFailedEventArgs e)
         {
                PrintFailed?.Invoke(new object(), e);
         } 
         #endregion 
 
 
         public void Print(int count)
         {
            OnPrintStarted(new EventArgs());
            System.Threading.Thread.Sleep(2000);

            int remaining = count;
            for (int i = 0; i < count; i++)
            {
                if (RemainingPaperCount != 0)
                {
                    RemainingPaperCount--;

                    System.Threading.Thread.Sleep(2000);
                    OnPrinting(new PrintingEventArgs(i + 1));
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                    OnPrintFailed(new PrintFailedEventArgs(count - i));
                    break;
                }      
            }

            System.Threading.Thread.Sleep(2000);
            OnPrintFinished(new EventArgs());
         } 
 
         public string Name { get; private set; } 
 
         public int RemainingPaperCount { get; private set; } 
 
         public void LoadPaper(int count)
         {
            RemainingPaperCount += count;
         } 
     } 

}
