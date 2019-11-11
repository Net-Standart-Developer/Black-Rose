using System.Windows.Media;

namespace BlackRose
{
    class FullTrack
    {
        public Track Track { get; private set; }
        public MediaPlayer Player { get; private set; }
        public FullTrack(Track track, MediaPlayer player)
        {
            Track = track;
            Player = player;
        }
    }
}
