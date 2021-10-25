using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadObserver.Abstractions
{
    public interface ISubscriber
    {
        public void Update(object sender, QueueEventArgs eventArgs);
    }
}
