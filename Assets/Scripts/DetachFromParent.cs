using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromParent : MonoBehaviour
{
    Vector3 position;

    public void DetachMeFromParent()
    {
        position = this.transform.position;
        Debug.Log("Position of root: " + position);
        if (this.transform.parent != null)
        {
            Debug.Log("Position of root before detatch: " + this.transform.position);
            this.transform.SetParent(null, false);
            this.GetComponentInParent<Animator>().StopPlayback();
            this.transform.position = position;
            Debug.Log("Position of root after detatch: " + this.transform.position);
            Debug.Log("Position of root: " + position);

        }
        //this.transform.position = position;
        Debug.Log("Position of root after reposition: " + this.transform.position);

    }


}
