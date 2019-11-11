using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackRose
{
    class Track
    {
        public string Name { get; private set; }
        
        public Track(string name)
        {
            Name = name;
        }
    }
}
