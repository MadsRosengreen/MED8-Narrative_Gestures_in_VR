using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource LineOne;
    public AudioSource LineTwo;

    public SceneChange SceneScript;
    public MeatManager MeatScript;

    float timer = 0.0f;

    [SerializeField]
    float hint = 0.0f;

    bool OnePlayed = false;
    public bool timerStarted = false;
    public bool hintNeeded = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        int a = SceneScript.GetSceneIndex();
        switch (a)
        {
            case 0:
                LineOne = GameObject.Find("LineOne").GetComponent<AudioSource>();
                LineTwo = GameObject.Find("LineTwo").GetComponent<AudioSource>();
                timerStarted = true;
                break;
            case 1:
                LineOne = GameObject.Find("LineOne").GetComponent<AudioSource>();
                timerStarted = true;
                break;
            case 2:
                LineOne = GameObject.Find("LineOne").GetComponent<AudioSource>();
                break;
            case 3:
                LineOne = GameObject.Find("LineOne").GetComponent<AudioSource>();
                break;
            case 4:
                LineOne = GameObject.Find("LineOne").GetComponent<AudioSource>();
                LineTwo = GameObject.Find("LineTwo").GetComponent<AudioSource>();
                timerStarted = true;
                break;
            case 5:
                timerStarted = true;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted && hintNeeded)
        {
            timer += Time.deltaTime;
            if (timer >= hint && !OnePlayed && SceneScript.GetSceneIndex() != 5)
            {
                LineOne.Play();
                OnePlayed = true;
            }
            else if (timer >= hint && !OnePlayed && SceneScript.GetSceneIndex() == 5)
            {
                MoveMeatHintLady();
            }
        }
    }

    public void PlayOne()
    {
        LineOne.Play();
    }

    public void PlayTwo()
    {
        LineTwo.Play();
    }

    public void MoveMeatHintLady()
    {
        MeatScript.ActivateMeatLady(); //Made by Freja
    }
}
