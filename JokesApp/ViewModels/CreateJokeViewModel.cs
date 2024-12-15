using JokesApp.Data.Enum;

namespace JokesApp.ViewModels
{
    public class CreateJokeViewModel
    {
        public JokesCategory Category { get; set; }
        public string JokeContent { get; set; }
        public string AppUserId { get; set; }
    }

}
