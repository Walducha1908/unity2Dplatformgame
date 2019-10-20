using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FirstLevel"))
            FindObjectOfType<AudioManager>().Play("LevelMusic");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("BestScoreMenu"))
            FindObjectOfType<AudioManager>().Play("BestScore");


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AskFirstLevel"))
            FindObjectOfType<AudioManager>().Play("ChooseNext");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AskSecondLevelInf"))
            FindObjectOfType<AudioManager>().Play("ChooseNext");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AskSecondLevelMath"))
            FindObjectOfType<AudioManager>().Play("ChooseNext");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AskSecondLevelPhysics"))
            FindObjectOfType<AudioManager>().Play("ChooseNext");
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AskThirdLevel"))
            FindObjectOfType<AudioManager>().Play("ChooseNext");

    }
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
 
