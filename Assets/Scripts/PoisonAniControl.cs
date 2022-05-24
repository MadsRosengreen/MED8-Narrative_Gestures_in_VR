using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAniControl : MonoBehaviour
{
    public Animator Poison;

    public void Give()
    {
        Poison.SetBool("GivenArrow", true);
        Poison.Play("ArrowGoBack");
    }
}