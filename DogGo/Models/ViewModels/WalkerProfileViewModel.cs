namespace DogGo.Models.ViewModels
{
    public class WalkerProfileViewModel
    {
        public Walker Walker { get; set; }
        public List<Walks> Walks { get; set; }
        public List<Neighborhood> Neightborhoods { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}
