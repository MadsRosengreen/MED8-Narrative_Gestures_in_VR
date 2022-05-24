using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSandCollision : MonoBehaviour
{
    public bool isTouchingSand_R = false, isTouchingSand_L = false;
    bool isRightHand;

    private void Start()
    {
        if (this.transform.IsChildOf(GameObject.FindGameObjectWithTag("OVRHandL").transform))
        {
            isRightHand = false;
        }
        else if (this.transform.IsChildOf(GameObject.FindGameObjectWithTag("OVRHandR").transform))
        {
            isRightHand = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SandCollider" && !isRightHand)
        {
            isTouchingSand_L = true;
            Debug.Log("isThouching_L sand is: " + isTouchingSand_L);
        }
        else if (other.tag == "SandCollider" && isRightHand)
        {
            isTouchingSand_R = true;
            Debug.Log("isThouching_R sand is: " + isTouchingSand_R);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SandCollider" && !isRightHand)
        {
            isTouchingSand_L = false;
            Debug.Log("isThouching_L sand is: " + isTouchingSand_L);
        }
        else if (other.tag == "SandCollider" && isRightHand)
        {
            isTouchingSand_R = false;
            Debug.Log("isThouching_R sand is: " + isTouchingSand_R);
        }
    }
}
