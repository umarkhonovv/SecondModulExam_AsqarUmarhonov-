using SecondExam.DataAccess.Enteties;
using System.Text.Json;

namespace SecondExam.Repositories;

public class MusicRepository : IMusicRepository
{
    private readonly string _path;
    private List<Music> _musicList;

    public MusicRepository()
    {
        _path = "../../../Data/DataAccess/Data/Musics.json";
        _musicList = new List<Music>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _musicList = GetAllMusics();

    }

    public Guid AddMusic(Music music)
    {
        var musicList = JsonSerializer.Deserialize<List<Music>>(_path);
        musicList.Add(music);
        SaveData();

        return music.Id;
    }

    public void DeleteMusic(Guid id)
    {
        var music = GetMusicById(id);
        _musicList.Remove(music);
        SaveData();
    }

    public List<Music> GetAllMusics()
    {
        var musicList = JsonSerializer.Deserialize<List<Music>>(_path);

        return musicList;
    }

    public void UpdateMusic(Music updatingMusic)
    {
        var music = GetMusicById(updatingMusic.Id);
        var index = _musicList.IndexOf(music);
        _musicList[index] = updatingMusic;

        SaveData();

    }


    public void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_musicList);
        File.WriteAllText(_path, musicJson);
    }

    public Music GetMusicById(Guid id)
    {
        foreach (var music in _musicList)
        {
            if (music.Id == id)
            {
                return music;
            }
        }

        throw new Exception("There is no such a music by this Id");
    }
}
