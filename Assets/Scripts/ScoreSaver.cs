using UnityEngine;

namespace DefaultNamespace
{
    public static class ScoreSaver
    {
        private const string BestScoreKey = "BestScore";
        
        public static void TryUpdateBestScore(Score newScore)
        {
            Score bestScore = LoadBestScore();
            
            if (!HasBestScore() || newScore > bestScore)
            {
                SaveBestScore(newScore);
            }
        }

        public static bool HasBestScore()
        {
            return PlayerPrefs.HasKey(BestScoreKey);
        }
        
        private static void SaveBestScore(Score score)
        {
            string scoreJson = JsonUtility.ToJson(score);
            
            PlayerPrefs.SetString(BestScoreKey, scoreJson);
            PlayerPrefs.Save();
        }

        public static Score LoadBestScore()
        {
            string json = PlayerPrefs.GetString(BestScoreKey);
            var score = JsonUtility.FromJson<Score>(json);
            
            return score;
        }
    }
}