using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip ambience, kuduAmbience, huntAmbience, fire;
    AudioSource playSound;

    // Start is called before the first frame update
    void Start()
    {
        playSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ambience()
    {
        int IDNum = SceneManager.GetActiveScene().buildIndex;

        switch (IDNum)
        {
            case 0: //village
                playSound.PlayOneShot(ambience, 0.5f);
                playSound.PlayOneShot(fire, 0.5f);
                break;
            case 1: //trackingPt1
                playSound.PlayOneShot(ambience, 0.5f);
                break;
            case 2: //woundKudu
                playSound.PlayOneShot(kuduAmbience, 0.5f);
                playSound.PlayOneShot(huntAmbience, 0.5f);
                break;
            case 3: //day/night passing
                playSound.PlayOneShot(huntAmbience, 0.5f);
                break;
            case 4: //trackingPt2
                playSound.PlayOneShot(ambience, 0.5f);
                break;
            case 5: //killKudu
                playSound.PlayOneShot(ambience, 0.5f);
                break;
            case 6: //celebration 
                playSound.PlayOneShot(ambience, 0.5f);
                break;
            default:
                break;

        }
            
    }

}


