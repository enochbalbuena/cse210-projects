namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double distance;

        public Running(DateTime date, int length, double distance)
            : base(date, length)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (distance / GetLength()) * 60;
        }

        public override double GetPace()
        {
            return GetLength() / distance;
        }
    }
}
