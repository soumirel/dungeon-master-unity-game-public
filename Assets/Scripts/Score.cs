namespace DefaultNamespace
{
    public class Score
    {
        // JsonUtility serializes only public fields
        public int Seconds;
        public int Minutes;

        public Score(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }
        
        public static bool operator >(Score firstScore, Score secondScore)
        {
            return GetInSeconds(firstScore) > GetInSeconds(secondScore);
        }

        public static bool operator <(Score firstScore, Score secondScore)
        {
            return GetInSeconds(firstScore) < GetInSeconds(secondScore);
        }

        private static int GetInSeconds(Score score)
        {
            return score.Minutes * 60 + score.Seconds;
        }

        public override string ToString()
        {
            string scoreString = "Score:";

            if (Minutes != 0)
            {
                scoreString += $" {Minutes}m";
            }

            scoreString += $" {Seconds}s";
            
            return scoreString;
        }
    }
}