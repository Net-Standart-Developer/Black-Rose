using System.Collections.Generic;

namespace BlackRose
{
    interface IFileService
    {
        string Path { get; }
        string[] ext { get; }
        List<FullTrack> DirOfTracks { get; }
    }
}
