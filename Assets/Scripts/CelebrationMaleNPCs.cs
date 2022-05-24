using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationMaleNPCs : MonoBehaviour
{
    public GameObject[] NPCTargets;

    public Animator NPC;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveNPC());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MaleTargets")
        {
            i += 1;
            if (i == 3)
            {
                NPC.SetBool("GoalReached", true);
            }
        }
    }

    private IEnumerator MoveNPC()
    {
        while (!NPC.GetBool("GoalReached"))
        {
            Vector3 targetPos = NPCTargets[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, NPCTargets[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
