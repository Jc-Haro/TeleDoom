using UnityEngine;

public class EnemyScoreTypeStats : MonoBehaviour {
    public string displayName;
    public int scorePoints;
    public int totalDefeated;
    public EnemyScoreTypeStats(string _displyName, int _scorePoints)
    {
        displayName = _displyName;
        scorePoints = _scorePoints;
        totalDefeated = 0;
    }
}
