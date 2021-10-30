using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyApp
{
    public class WebConnectionStats
    {
        static int _Read = 0;
        static int _Written = 0;

        
        public static void Init(bool registerAsSystemProxy = false)
        {
            Fiddler.FiddlerApplication.OnReadRequestBuffer += (s, e) => Interlocked.Add(ref _Written, e.iCountOfBytes);
            Fiddler.FiddlerApplication.OnReadResponseBuffer += (s, e) => Interlocked.Add(ref _Read, e.iCountOfBytes);
            //Fiddler.FiddlerApplication.Startup(80, registerAsSystemProxy, true);
        }

        public static int Read
        {
            get { return _Read; }
        }

        public static int Written
        {
            get { return _Written; }
        }
    }
}
