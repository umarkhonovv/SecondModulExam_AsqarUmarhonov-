using SecondExam.DataAccess.Enteties;
using SecondExam.Repositories;
using SecondExam.Services.DTOs;

namespace SecondExam.Services;

public class MusicService : IMusicService
{
    private readonly IMusicRepository _musicRepository;


    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }



    public Guid AddMusic(MusicDto musicToAdd)
    {
        musicToAdd.Id = Guid.NewGuid();
        var music = ConvertToEntity(musicToAdd);
        _musicRepository.AddMusic(music);

        return music.Id;
    }

    public void DeleteMusic(Guid id)
    {
        _musicRepository.DeleteMusic(id);
    }

    public List<MusicDto> GetAll()
    {
        var musics = _musicRepository.GetAllMusics();
        var dtoAllMusic = new List<MusicDto>();
        foreach (var music in musics)
        {
            dtoAllMusic.Add(ConvertToDto(music));
        }

        return dtoAllMusic;
    }

    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        var allMusic = GetAll();
        var allMusicByAuthorName = new List<MusicDto>();
        foreach (var music in allMusic)
        {
            if (music.AuthorName == name)
            {
                allMusicByAuthorName.Add(music);
            }
        }

        return allMusicByAuthorName;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var uniqueAuthors = new List<string>();
        var allMusic = GetAll();
        for (var i = 0; i < allMusic.Count; i++)
        {
            for (var j = 0; j < allMusic.Count; j++)
            {
                if (allMusic[i].AuthorName == allMusic[j].AuthorName)
                {
                    break;
                }
                uniqueAuthors.Add(allMusic[i].AuthorName);
            }
        }

        return uniqueAuthors;
    }

    

    

    public List<MusicDto> GetMusicByDescriptionKeyWord(string keyword)
    {
        var musicDtos = new List<MusicDto>();
        var allMusic = GetAll();
        for (var i = 0; i < allMusic.Count; ++i)
        {
            if (allMusic[i].Description.Contains(keyword))
            {
                musicDtos.Add(allMusic[i]);
            }
        }

        return musicDtos;
    }

    public MusicDto GetMusicById(Guid id)
    {
        var allMusic = GetAll();
        foreach (var music in allMusic)
        {
            if (music.Id == id)
            {
                return music;
            }
        }

        throw new Exception("There is no such a music by this id");
    }

    public MusicDto GetMusicByName(string name)
    {
        var allMusic = GetAll();
        foreach (var music in allMusic)
        {
            if (music.Name == name)
            {
                return music;
            }
        }

        throw new Exception("There is no such a music");
    }

    public List<MusicDto> GetMusicWithLikeInRange(int minLikes, int maxLikes)
    {
        var list = new List<MusicDto>();
        var allMusic = GetAll();
        if (minLikes > maxLikes || minLikes < 0 || maxLikes > allMusic.Count)
        {
            throw new Exception("IndexOutOfRangeException");
        }
        for (var i = minLikes; i < maxLikes; ++i)
        {
            list.Add(allMusic[i]);
        }

        return list;
    }

    public List<MusicDto> GettAllMusicAboveSize(double minSize)
    {
        var list = new List<MusicDto>();
        var allMusic = GetAll();
        foreach (var music in allMusic)
        {
            if (music.MB > minSize)
            {
                list.Add(music);
            }
        }

        return list;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var totalSize = 0.0;
        var allMusic = GetAll();
        foreach (var music in allMusic)
        { 
            if (music.AuthorName == authorName)
            {
                totalSize += music.MB;
            }
        }

        return totalSize;
    }

    public void UpdateMusic(MusicDto updatingMusic)
    {
        var music = ConvertToEntity(updatingMusic);
        _musicRepository.UpdateMusic(music);
    }








    public Music ConvertToEntity(MusicDto dto)
    {
        return new Music()
        {
            Id = dto.Id,
            Name = dto.Name,
            MB = dto.MB,
            AuthorName = dto.AuthorName,
            Description = dto.Description,
            QuentityLikes = dto.QuentityLikes,
        };
    }

    public MusicDto ConvertToDto(Music music)
    {
        return new MusicDto()
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

    public MusicDto GetMostLikedMusic()
    {
        var allMusic = GetAll();
        var mostLikedDto = allMusic[0];
        for (var i = 1; i < allMusic.Count; i++)
        {
            if (allMusic[i].QuentityLikes < allMusic[i - 1].QuentityLikes)
            {
                mostLikedDto = allMusic[i];
            }
        }

        return mostLikedDto;
    }
}
