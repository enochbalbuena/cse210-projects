using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime date;
        private int length;

        public Activity(DateTime date, int length)
        {
            this.date = date;
            this.length = length;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public int GetLength()
        {
            return length;
        }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({length} min)- Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
        }
    }
}
