using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadObserver
{
    public class QueueEventArgs : EventArgs
    {
        public Queue<int> Queue { get; set; }
    }
}
