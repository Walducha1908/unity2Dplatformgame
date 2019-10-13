using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class BestScoreMenu : MonoBehaviour
{
    public static bool isLoadedFromMainMenuScene;
    public static bool isLoadedFromEndScreen;
    public static string playernamestr;
    private Transform entries;
    private Transform entry;
    private List<Transform> scoreEntriesTransforms;

    private void Start()
    {
        entries = transform.Find("Entries");
        entry = entries.Find("Entry");
        entry.gameObject.SetActive(false);

        Scores scores = AddScoreEntry(scoreCounter.points, playernamestr);

        for (int i = 0; i < scores.scoreEntries.Count; i++)
        {
            for (int j = i + 1; j < scores.scoreEntries.Count; j++)
            {
                if (scores.scoreEntries[j].score > scores.scoreEntries[i].score)
                {
                    ScoreEntry tmp = scores.scoreEntries[i];
                    scores.scoreEntries[i] = scores.scoreEntries[j];
                    scores.scoreEntries[j] = tmp;
                }
            }
        }

        scoreEntriesTransforms = new List<Transform>();

        for (int i = 0; i < 5; i++)
        {
            ScoreEntry scoreEntry = scores.scoreEntries[i];
            CreateScoreEntryTransform(scoreEntry, entries, scoreEntriesTransforms);
        }

        if (isLoadedFromEndScreen)
        {
            isLoadedFromEndScreen = false;
            SceneManager.LoadScene("MainMenu");
        }

    }

    private void CreateScoreEntryTransform(ScoreEntry scoreEntry, Transform entries, List<Transform> scoreEntriesTransforms)
    {
        float heightBetweenEntries = 70f;
        Transform entryTransform = Instantiate(entry, entries);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -heightBetweenEntries * scoreEntriesTransforms.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = scoreEntriesTransforms.Count + 1;
        string position = rank + "";

        entryTransform.Find("Position").GetComponent<Text>().text = position;

        float score = (float)scoreEntry.score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        string playerName = scoreEntry.playerName;
        entryTransform.Find("PlayerName").GetComponent<Text>().text = playerName;

        scoreEntriesTransforms.Add(entryTransform);
    }

    private Scores AddScoreEntry(float score, string playerName)
    {
        ScoreEntry scoreEntry = new ScoreEntry { score = score, playerName = playerName };
        Scores scores;
        if (PlayerPrefs.HasKey("ScoreTable"))
        {
            string jsonStr = PlayerPrefs.GetString("ScoreTable");
            scores = JsonUtility.FromJson<Scores>(jsonStr);
        }
        else
        {
            scores = new Scores();
        }

        if (!isLoadedFromMainMenuScene)
        {
            scores.scoreEntries.Add(scoreEntry);
        }
        isLoadedFromMainMenuScene = false;

        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("ScoreTable", json);
        PlayerPrefs.Save();

        return scores;
    }

    [System.Serializable]
    private class Scores
    {
        public List<ScoreEntry> scoreEntries = new List<ScoreEntry>();
    }

    [System.Serializable]
    private class ScoreEntry
    {
        public float score;
        public string playerName;
    }
}