namespace Api.Domain.Model
{
    public class People
    {
        public long Id { get; init; }

        public string Name { get; init; }

        public int Age { get; init; }

        public int Phone { get; init; }

        public string Address { get; set; }
    }
}