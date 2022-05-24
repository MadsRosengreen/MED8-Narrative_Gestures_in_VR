using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseRoot : MonoBehaviour
{
    public Animator root;

    public void GoIdle()
    {
        root.SetBool("RootGrabbed", true);
        root.Play("IdleNoRoot");
    }
}
