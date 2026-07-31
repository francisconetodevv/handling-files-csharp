namespace DataAbstract.Models
{
    public class Band
    {
        public string BandName { get; set; } = string.Empty;

        public static IEnumerable<Band> RequestBand(StreamReader stream)
        {
            var line = stream.ReadLine();

            while (line is not null)
            {
                var split = line.Split(';');
                var band = new Band
                {
                    BandName = split[1]
                };

                yield return band;
                line = stream.ReadLine();
            }
        }
    }
}