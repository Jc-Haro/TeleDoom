using UnityEngine;
using TMPro;

public class GenerateScoreReport : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ReportUI;
    string m_ReportText;
    [SerializeField] Camera m_GameOverCamera;
    [SerializeField] Canvas m_GameOverCanvas;
    [SerializeField] EnemyScoreTypeStats[] m_enemyScoreTypeStats;
    public static GenerateScoreReport instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("More than une report");
            Destroy(this);
        }
    }

    public void GenerateReport()
    {
        m_ReportText += "Mission Over\n";
        m_ReportText += "Time survived " + FormatTime(ScoreManager.instance.GameTime)+"\n";
        for(int i = 0; i < m_enemyScoreTypeStats.Length; i++)
        {
            if (m_enemyScoreTypeStats[i].totalDefeated > 0)
            {
                m_ReportText += "Total " + m_enemyScoreTypeStats[i].displayName+ "s defeated " + m_enemyScoreTypeStats[i].totalDefeated + "\n";
            }
        }
        m_ReportUI.text = m_ReportText;
        m_GameOverCanvas.gameObject.SetActive(true);
        m_GameOverCamera.gameObject.SetActive(true);
        m_ReportUI.gameObject.SetActive(true);
    }


    static string FormatTime(float seconds)
    {
        int hours = (int)(seconds / 3600);
        seconds %= 3600; 
        int minutes = (int)(seconds / 60); 
        seconds %= 60; 

        string result = "";

        if (hours > 0)
        {
            result += (int)hours + "h" + (hours > 1 ? "s" : "")+ ":";
        }
        if (minutes > 0)
        {
            result += (int)minutes + "m" + (minutes > 1 ? "s" : "")+":";
        }
        
        result += (int)seconds + "s";

        return result;
    }
}