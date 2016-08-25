using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class PrintingEventArgs : EventArgs
    {
        public int PaperCount { get; private set; }
   
        public PrintingEventArgs(int paperCount)
        {
            PaperCount = paperCount;
        }
    }
}
