using SecondExam.Services.DTOs;
using System.Runtime.CompilerServices;

namespace SecondExam.Services.Extensions;

public static class Extensions
{
    public static double GetMusicKB(this double musicMb)
    {
        int mb = (int)musicMb;
        int kb = mb - (int)musicMb;

        return mb * 1024 + kb * 1024;
    }

    public static int GetQuentityLikes(this List<MusicDto> musicDtos)
    {
        var quentity = 0;
        foreach (var music in musicDtos)
        {
            quentity += music.QuentityLikes;
        }

        return quentity;
    }
}
