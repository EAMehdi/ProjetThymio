using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Thymio_V2
{
    class Recorder
    {

        private Process _recorderProcess;
        private ProcessStartInfo _recorderProcessInfo;


        /// <summary>
        /// Deleguate declaration
        /// </summary>
        /// <param name="capteur"></param>
        public delegate void myDelegate(int capteur);
        private  myDelegate del;


        public void Subscribe(myDelegate handler)
        {
            del += handler;
        }


  

    }
}
