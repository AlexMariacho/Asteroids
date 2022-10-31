namespace Asteroids.Core.Score
{
    public class PlayerScore
    {
        public int CurrentScore { get; private set; }
        
        public void TakeScore()
        {
            CurrentScore++;
        }
    }
}