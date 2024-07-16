using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] Transform entryContainer;
    [SerializeField] Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;
    string levelName;
    [SerializeField] Transform tableContainer;
    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
        levelName += "ScoreTable";
        string jsonEntry = PlayerPrefs.GetString(levelName);
        highScoreEntryTransformList = new List<Transform>();
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonEntry);
        //If there is no level highscore table we create it
        if (highScores.highScoreEntryList.Count == 0)
        {
            highScores.highScoreEntryList = new List<HighScoreEntry>();
            for (int i = 0; i < 10; i++)
            {
                HighScoreEntry tmpEntry = new HighScoreEntry { score = i*1000, name = "AAA" };
                highScores.highScoreEntryList.Add(tmpEntry);
            }
            string jsonList = JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString(levelName, jsonList);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString(levelName));
        }

        entryTemplate.gameObject.SetActive(false);

    }

    public void GenerateTable()
    {

        string jsonEntry = PlayerPrefs.GetString(levelName);
        highScoreEntryTransformList = new List<Transform>();
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonEntry);

        for(int i = 0; i<10; i++)
        { 
            CreateHighscoreEntry(highScores.highScoreEntryList[i], entryContainer,highScoreEntryTransformList); 
        }

        Debug.Log(PlayerPrefs.GetString(levelName));            
       

    }

    private void CreateHighscoreEntry(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count); ;
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankText;
        switch (rank)
        {
            case 1:
                rankText = "1st";
                break;
            case 2:
                rankText = "2nd";
                break;
            case 3:
                rankText = "3rd";
                break;
            default:
                rankText = rank + "th";
                break;
        }

        entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().text = rankText;
        long score = highScoreEntry.score;
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
        string name = highScoreEntry.name;
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        bool isBacgroundActive = transformList.Count % 2 == 0;
        entryTransform.Find("Background").gameObject.SetActive(isBacgroundActive);

        transformList.Add(entryTransform);
    }

    public void AddHighScoreEntry(long score, string name)
    {
        //Create new high score
        HighScoreEntry entry = new HighScoreEntry { score = score, name = name };
        
        //Load high scores
        string jsonEntry = PlayerPrefs.GetString(levelName);
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonEntry);

        //Add new entry
        highScores.highScoreEntryList.Add(entry);

        //Sort new list bubble sort for Angel's win
        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    //Swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        bool outOfList = true;
        while (outOfList)
        {
            try
            {
                highScores.highScoreEntryList.RemoveAt(10);
            }
            catch 
            { 
                outOfList = false;
            }
        }

        //Save high scores
        string jsonList = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString(levelName, jsonList);
        PlayerPrefs.Save();
    }

    public bool IsHighScore(long score)
    {

        //Load high scores
        string jsonEntry = PlayerPrefs.GetString(levelName);
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonEntry);

        //Sort list bubble sort for Angel's win
        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    //Swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }
        int index = highScores.highScoreEntryList.Count - 1;
        Debug.Log(highScores.highScoreEntryList);
        return (score > highScores.highScoreEntryList[index].score);
    }

    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public long score;
        public string name;
    }

}
