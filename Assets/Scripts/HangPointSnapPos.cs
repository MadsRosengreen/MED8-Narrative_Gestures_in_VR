using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangPointSnapPos : MonoBehaviour
{
    bool isGrabbing = false;
    public bool meatIsHanging = false, isCounted = false;

    public AudioSource MeatHang;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SnapPos" && !isGrabbing)
        {
            Debug.Log("Ready to attach to tree");
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            meatIsHanging = true;
            Debug.Log("meatIsHanging is: " + meatIsHanging);
            MeatHang.Play();
        }
    }


    public void HandGrabGrabbed()
    {
        isGrabbing = true;
    }

    public void HandGrabRelease()
    {
        isGrabbing = false;
    }
}
