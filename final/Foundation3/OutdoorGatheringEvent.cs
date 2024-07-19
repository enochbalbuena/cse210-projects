namespace EventPlanning
{
    public class OutdoorGatheringEvent : Event
    {
        private string weatherStatement;

        public OutdoorGatheringEvent(string title, string description, DateTime date, string time, Address address, string weatherStatement)
            : base(title, description, date, time, address)
        {
            this.weatherStatement = weatherStatement;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {weatherStatement}";
        }
    }
}
