using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggers : MonoBehaviour
{
    [SerializeField]
    public Animator NPC;
    public Animator Bow;

    public GameObject Arrow;
    public GameObject[] trackPoint;

    ArrowControl ArrowScript;

    public int i = 0;
    bool hunterInPosition = false;

    void Start()
    {
        if (this.tag != "NPCThree")
        {
            Arrow = null;
            ArrowScript = null;
        }
        else
        {
            ArrowScript = Arrow.GetComponent<ArrowControl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            NPCDuck(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            NPCDuck(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            NPCReady(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            NPCReady(false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            NPCMove();
        }
    }

    public void NPCDuck(bool withReady)
    {
        if(withReady)
        {
            NPC.SetBool("DuckReady", true);
            Bow.SetBool("DuckReady", true);
            if (this.tag == "NPCThree")
            {
                Arrow.gameObject.SetActive(true);
            }
        }
        else
        {
            NPC.SetBool("Duck", true);
            Bow.SetBool("Duck", true);
        }
    }

    public void NPCReady(bool withDuck)
    {
        if (withDuck)
        {
            NPC.SetBool("ReadyDuck", true);
            Bow.SetBool("ReadyDuck", true);
            if (this.tag == "NPCThree")
            {
                Arrow.gameObject.SetActive(true);
            }
        }
        else
        {
            NPC.SetBool("Ready", true);
            Bow.SetBool("Ready", true); 
            if (this.tag == "NPCThree")
            {
                Arrow.gameObject.SetActive(true);
            }
        }
    }

    public void NPCMove()
    {
        StartCoroutine(NPCMover());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            i += 1;
            if (i == 3 || this.tag == "NPCTwo")
            {
                NPC.SetBool("Move", false);
                Bow.SetBool("Move", false);
                hunterInPosition = true;
            }
        }
    }

    private IEnumerator NPCMover()
    {
        yield return new WaitForSeconds(4);
        NPC.SetBool("Move", true);
        Bow.SetBool("Move", true);

        while (!hunterInPosition)
        {
            Vector3 targetPos1 = trackPoint[i].transform.position - this.transform.position;
            Vector3 newDir1 = Vector3.RotateTowards(this.transform.forward, targetPos1, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir1);
            this.transform.position = Vector3.MoveTowards(this.transform.position, trackPoint[i].transform.position, 2f * Time.deltaTime);
            yield return null;
        }
        if(this.tag == "NPCThree")
        {
            yield return new WaitForSeconds(5);
            Arrow.gameObject.SetActive(true);
            Bow.Play("bowRig_bowCrouched");
            NPC.Play("metarig_bowCrouched");
            yield return new WaitForSeconds(1.5f);
            Arrow.transform.parent = null;
            ArrowScript.startArrow();
        }

    }
}
