﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BestScoreMenu : MonoBehaviour
{
    /*
    public static string playernamestr; //string do ktorego przekazywana jest imie po wpisaniu go w okienku

    public Text score;
    
    ScoreTable st;

    public void Start()
    {
        ShowBestScore();
    }

    public void ShowBestScore()
    {
       st = new ScoreTable();
        st.Create();
        // score.text = playernamestr +": " + scoreCounter.points; // TODO: uwzgledniac najlepszy wynik, a nie jakikolwiek
    }

    */
    public static string playernamestr;
    private Transform entries;
    private Transform entry;
    private List<Transform> scoreEntriesTransforms;

    private void Start()
    {
        entries = transform.Find("Entries");
        entry = entries.Find("Entry");
        entry.gameObject.SetActive(false);

        /*        string jsonStr = PlayerPrefs.GetString("ScoreTable");
                Scores scores = JsonUtility.FromJson<Scores>(jsonStr);*/

        ScoreEntry scoreEntry = new ScoreEntry { score = scoreCounter.points, playerName = playernamestr };
        Scores scores = new Scores();
        scores.scoreEntries = new List<ScoreEntry>();
        scores.scoreEntries.Add(scoreEntry);

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

        /*        Scores scores = new Scores { scoreEntries = scoreEntries };
                string json = JsonUtility.ToJson(scores);
                PlayerPrefs.SetString("ScoreTable", json);
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetString("ScoreTable"));*/
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

    private void AddScoreEntry(float score, string playerName)
    {
        ScoreEntry scoreEntry = new ScoreEntry { score = score, playerName = playerName };

        string jsonStr = PlayerPrefs.GetString("ScoreTable");
        Scores scores = JsonUtility.FromJson<Scores>(jsonStr);

        scores.scoreEntries.Add(scoreEntry);
    }

    private class Scores
    {
        public List<ScoreEntry> scoreEntries;
    }

    [System.Serializable]
    private class ScoreEntry
    {
        public float score;
        public string playerName;
    }
}