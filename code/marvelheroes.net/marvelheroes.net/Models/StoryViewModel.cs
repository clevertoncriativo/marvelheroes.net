using marvelheroes.net.Common.Objects;

namespace marvelheroes.net.Models
{
    public class StoryViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }        
        public string OriginalIssue { get; set; }

        public static explicit operator StoryViewModel(Story story)
        {
            return new StoryViewModel()
            {
                Description = story.Description,
                Title = story.Title,
                OriginalIssue = story.OriginalIssue.Name
            };
        }
    }
}