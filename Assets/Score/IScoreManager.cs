public interface IScoreManager
{
    void AddScore(int score);
    void SubtractScore(int score);
    void ResetScore();
    void SaveScore();
    int GetCurrentScore();
}
