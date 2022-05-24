using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatManager : MonoBehaviour
{

    public GameObject HutOne;
    public GameObject HutTwo;
    public GameObject Fire;

    //List<Animator> NPCsCon;
    public List<GameObject> NPCs;

    [SerializeField]
    List<GameObject> meats;
    [SerializeField]
    List<HangPointSnapPos> hangPoint;

    int meatsHanging = 0;
    bool functionHasRun = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject meat in meats)
        {
            hangPoint.Add(meat.GetComponent<HangPointSnapPos>());
        }
        foreach (GameObject NPC in NPCs)
        {
           // NPCsCon.Add(NPC.GetComponent<Animator>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (HangPointSnapPos hangPoint in hangPoint)
        {
            if (hangPoint.meatIsHanging && !hangPoint.isCounted)
            {
                meatsHanging++;
                functionHasRun = false;
                hangPoint.isCounted = true;
            }
        }

        if (meatsHanging == 1 && !functionHasRun)
        {
            MeatFunction1();
            functionHasRun = true;
        }
        else if (meatsHanging == 2 && !functionHasRun)
        {
            MeatFunction2();
            functionHasRun = true;
        }
        else if (meatsHanging == 3 && !functionHasRun)
        {
            MeatFunction3();
            functionHasRun = true;
        }
    }

    void MeatFunction1()
    {
        NPCs[1].SetActive(true);
        NPCs[2].SetActive(true);
        // Add functionality for first meat hung here
        Debug.Log("WOOOO! I just did a bunch of shit because you hang up a piece of meat");
    }

    void MeatFunction2()
    {
        HutOne.SetActive(true);

        NPCs[1].GetComponent<HutLadyControl>().StartHut2();
        NPCs[2].GetComponent<HutLadyControl>().StartHut2();
        NPCs[3].SetActive(true);
       // NPCsCon[3].SetBool("Move", true);
        
        // Add functionality for second meat hung here
        Debug.Log("WOOOO! I just did a bunch of shit because you hang up a piece of meat");
    }

    void MeatFunction3()
    {
        HutTwo.SetActive(true);
        Fire.SetActive(true);

        NPCs[4].SetActive(true);
        NPCs[5].SetActive(true);
        NPCs[6].SetActive(true);
        // Add functionality for third meat hung here
        Debug.Log("WOOOO! I just did a bunch of shit because you hang up a piece of meat");
    }

    public void ActivateMeatLady()
    {
        NPCs[0].SetActive(true);
    }
}
