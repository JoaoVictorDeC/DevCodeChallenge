namespace DevCodeChallenge.Entities
{
    public class NasaApod
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string Explanation { get; set; }
        public string Hdurl { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

    }
}
