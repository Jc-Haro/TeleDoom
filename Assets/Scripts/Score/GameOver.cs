using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            GenerateScoreReport.instance.GenerateReport();
        }
    }
}
