using SecondExam.Services.DTOs;

namespace SecondExam.Services
{
    public interface IMusicService
    {
        Guid AddMusic(MusicDto music);
        void DeleteMusic(Guid id);
        void UpdateMusic(MusicDto music);
        List<MusicDto> GetAll();
        MusicDto GetMusicById(Guid id);
        List<MusicDto> GetAllMusicByAuthorName(string name);
        MusicDto GetMostLikedMusic();
        MusicDto GetMusicByName(string name);
        List<MusicDto> GettAllMusicAboveSize(double minSize);
        List<MusicDto> GetMusicByDescriptionKeyWord(string keyword);
        List<MusicDto> GetMusicWithLikeInRange(int minLikes, int maxLikes);
        List<string> GetAllUniqueAuthors();
        double GetTotalMusicSizeByAuthor(string authorName);

    }
}