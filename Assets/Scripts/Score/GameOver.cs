using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool isQuitting = false;
    public GameObject[] Enemies;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < Enemies.Length; i++)
            {
                Destroy(Enemies[i]);
            }
            GenerateScoreReport.instance.GenerateReport();
        }
    }
}
