using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPeek : MonoBehaviour
{
    public GameObject gestureManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            gestureManager.SetActive(true);
        }
    }
}
