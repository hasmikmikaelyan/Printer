using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class PrintFailedEventArgs : EventArgs
    {
        public int RemainingPages { get; set; }

        public PrintFailedEventArgs(int remainingPages)
        {
            RemainingPages = remainingPages;
        }
    }
}
