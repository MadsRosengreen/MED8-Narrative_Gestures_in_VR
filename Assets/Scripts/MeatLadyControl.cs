using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatLadyControl : MonoBehaviour
{
    public Animator MeatLady;

    public GameObject[] TargetPoint;

    public GameObject MeatOne;
    public GameObject MeatTwo;

    private int i = 0;
    private bool MeatReached = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Walk2Meat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "F0Target")
        {
            i += 1;
            if (i == 4)
            {
                MeatLady.SetBool("MeatReached", true);
                MeatReached = true;
            }
            if (i == 7)
            {
                MeatLady.SetBool("TreeReached", true);
                MeatLady.SetBool("MeatReached", false);
            }
            if (i == 8)
            {
                MeatLady.SetBool("FireReached", true);
            }
        }
    }

    private IEnumerator Walk2Meat()
    {
        while (!MeatReached)
        {
            Vector3 targetPos = TargetPoint[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPoint[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(MeatLady.GetCurrentAnimatorStateInfo(0).length / 1.2f);
        MeatOne.transform.parent = this.transform.Find("metarig.001/spine/spine.001/spine.002/spine.003/shoulder.L/upper_arm.L/forearm.L/hand.L");
        yield return new WaitForSeconds(MeatLady.GetCurrentAnimatorStateInfo(0).length / 2);
        while (!MeatLady.GetBool("TreeReached"))
        {
            Vector3 targetPos = TargetPoint[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPoint[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(MeatLady.GetCurrentAnimatorStateInfo(0).length / 1.2f);
        MeatOne.SetActive(false);
        MeatTwo.SetActive(true);
        yield return new WaitForSeconds(MeatLady.GetCurrentAnimatorStateInfo(0).length * 0.2f);
        while (!MeatLady.GetBool("FireReached"))
        {
            Vector3 targetPos = TargetPoint[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPoint[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
