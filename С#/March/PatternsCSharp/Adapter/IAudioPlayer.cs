using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Adapter
{
    internal interface IAudioPlayer
    {
        void Load(string fileName);
        void Play();
        void Stop();
    }
}
