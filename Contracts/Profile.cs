namespace split_me_backend.Contracts
{
    public class Profile
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public IEnumerable<string>? NameSet { get; set; }
    }
}
