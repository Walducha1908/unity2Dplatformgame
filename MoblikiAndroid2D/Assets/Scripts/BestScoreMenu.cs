using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BestScoreMenu : MonoBehaviour
{
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

        foreach (ScoreEntry se in scores.scoreEntries)
        {
            CreateScoreEntryTransform(se, entries, scoreEntriesTransforms);
        }
    }

    private void CreateScoreEntryTransform(ScoreEntry scoreEntry, Transform entries, List<Transform> scoreEntriesTransforms)
    {
        float heightBetweenEntries = 50f;
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
        scores.scoreEntries.Add(scoreEntry);

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