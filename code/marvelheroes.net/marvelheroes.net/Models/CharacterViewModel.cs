using marvelheroes.net.Common.Objects;

namespace marvelheroes.net.Models
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; } 

        public static explicit operator CharacterViewModel(Character character)
        {
            return new CharacterViewModel() { 
                Description = character.Description,
                Name = character.Name,
                Thumbnail = character.Thumbnail.ImageSource()
            };
        }
    }

    public class CharacterImageViewModel
    {
        public string Path { get; set; }
        public string Extension { get; set; }

        public string ImageSource()
        {
            return $"{Path}.{Extension}";
        }
    }
}