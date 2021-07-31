using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{


    //init this instance
    public static GameManagerScript Instance; 

    //init class for sound
    public Sound[] sounds; 

    public int Score;

    public Text textScore;



    private void Awake()
    {
        //set instance
        Instance = this; 


        //copy target class
        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    //play sound by the string name
    public void Play(string name) 
    {
        //find sound anme
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //play sound
        s.source.Play();
    }


    void Start()
    {
        //define the score when the script run
        Score = 0;
    }


    public void Benar()
    {
        //if he collision of the box with the sampah match the tag, score +10
        Score += 10;
    }
    public void Salah()
    {
        //if he collision of the box with the sampah doesnt match the tag, score -15
        Score -= 15;
    }

    void Update()
    {
        //update the score text
        textScore.text = "SCORE : " + Score.ToString();

        //if the game score below zero, it will go to game over scene
        if(Score < 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


    //button funtion to play again
    public void OnPressedPlayAgain()
    {

        //load the game scene
        SceneManager.LoadScene("GameScene");
    }
}


[System.Serializable]

//class sound
public class Sound 
{
    public string name;

    public AudioClip clip;

    [HideInInspector] public AudioSource source;

    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;
}