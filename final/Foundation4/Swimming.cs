namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int laps;
        private const double LapLength = 50 / 1000.0;

        public Swimming(DateTime date, int length, int laps)
            : base(date, length)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * LapLength;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / GetLength()) * 60;
        }

        public override double GetPace()
        {
            return GetLength() / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{GetDate().ToString("dd MMM yyyy")} Swimming ({GetLength()} min)- Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km, Laps: {laps}";
        }
    }
}
