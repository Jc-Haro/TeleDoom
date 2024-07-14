using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    Transform entryContainer;
    Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonEntry = PlayerPrefs.GetString("HighScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonEntry);

        highScoreEntryTransformList = new List<Transform>();
        for(int i = 0; i<10; i++)
        { 
            CreateHighscoreEntry(highScores.highScoreEntryList[i], entryContainer,highScoreEntryTransformList); 
        }

        Debug.Log(PlayerPrefs.GetString("HighScoreTable"));

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

    private void AddHighScoreEntry(long score, string name)
    {
        //Create new high score
        HighScoreEntry entry = new HighScoreEntry { score = score, name = name };
        
        //Load high scores
        string jsonEntry = PlayerPrefs.GetString("HighScoreTable");
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
        PlayerPrefs.SetString("HighScoreTable", jsonList);
        PlayerPrefs.Save();
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
