using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private float gameTime = 0;
    private int score = 0;
    private int multiplier = 1;
    private float multiplierCounter;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        multiplierCounter -= Time.deltaTime;
        if(multiplierCounter < 0) { multiplier = 1; }
    }


    public void SetMultiplier(int _multiplier,float _durationSeconds)
    {
        if (multiplier > _multiplier)
        {
            return;
        }
        else if(multiplier == _multiplier)
        {
            multiplierCounter += _durationSeconds;
        }
        else
        {
            multiplier = _multiplier;
            multiplierCounter = _durationSeconds;
        }
    }

    //Enemies idk how to make this better LOL
    [SerializeField] EnemyScoreTypeStats cockroache;
    [SerializeField] EnemyScoreTypeStats chaser;
    [SerializeField] EnemyScoreTypeStats tank;
    [SerializeField] EnemyScoreTypeStats eye;
    [SerializeField] EnemyScoreTypeStats sniper;
        

    public void AddScore(EnemyType enemyType)
    {
        switch(enemyType)
        {
            case EnemyType.cockroache:
                cockroache.totalDefeated++;
                AddScore(cockroache.scorePoints);
                break;
            case EnemyType.cheaser:
                chaser.totalDefeated++;
                AddScore(chaser.scorePoints);
                break;
            case EnemyType.tank:
                tank.totalDefeated++;
                AddScore(tank.scorePoints);
                break;
            case EnemyType.eye:
                eye.totalDefeated++;
                AddScore(eye.scorePoints);
                break;
            case EnemyType.sniper:
                sniper.totalDefeated++;
                AddScore(sniper.scorePoints);
                break;
            default:
                Debug.Log("Invalid type");
                break;
        }
    }

    void AddScore(int _score)
    {
        score += _score * multiplier;
    }
}