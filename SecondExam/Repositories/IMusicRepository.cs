using SecondExam.DataAccess.Enteties;

namespace SecondExam.Repositories
{
    public interface IMusicRepository
    {
        Guid AddMusic(Music music);
        void DeleteMusic(Guid id);
        void UpdateMusic(Music music);
        List<Music> GetAllMusics();
        Music GetMusicById(Guid id);
    }
}