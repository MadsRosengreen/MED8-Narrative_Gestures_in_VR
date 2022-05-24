using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillKudoNPCTriggers : MonoBehaviour
{

    public Animator NPCOne;

    public SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KnifeTaken()
    {
        NPCOne.SetBool("KnifeTaken", true);
    }

    public void GiveKnife()
    {
        StartCoroutine(CutKudu());
    }

    private IEnumerator CutKudu()
    {
        yield return new WaitForSeconds(3);
        NPCOne.SetBool("KuduDead", true);
        Sound.PlayTwo();
        yield return null;
    }
}
