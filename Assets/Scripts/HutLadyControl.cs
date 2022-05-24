using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutLadyControl : MonoBehaviour
{

    public GameObject[] targets;
    int i = 0;
    Animator anim;
    [SerializeField]
    int ladyIndex = 0;

    public GameObject grass;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Lady", ladyIndex);

        MoveToHut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToHut()
    {
        StartCoroutine(HutBuilder());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "F1Target" && this.tag == "F1")
        {
            i += 1;
            if (i == 3)
            {
                anim.SetBool("GoalReach", true);
            }
            if (i == 4)
            {
                anim.SetBool("GoalReach", true);
            }
            if (i == 5)
            {
                anim.SetBool("GoalReach", true);
            }
        }
        else if (other.tag == "F2Target" && this.tag == "F2")
        {
            i += 1;
            if (i == 3)
            {
                anim.SetBool("GoalReach", true);
            }
            if (i == 4)
            {
                anim.SetBool("GoalReach", true);
            }
        }
    }

    public void StartHut2()
    {
        StartCoroutine(NewHut());
    }

    private IEnumerator HutBuilder()
    {
        while (!anim.GetBool("GoalReach"))
        {
            Vector3 targetPos = targets[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targets[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        grass.transform.parent = null;
        grass.GetComponent<Rigidbody>().useGravity = true;
        if (ladyIndex == 2)
        {
            yield return new WaitForSeconds(2);
            anim.SetBool("GoalReach", false);
        }
        if (ladyIndex == 1)
        {
            anim.SetBool("GoalReach", false);
            while (!anim.GetBool("GoalReach"))
            {
                Vector3 targetPos = targets[i].transform.position - this.transform.position;
                Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
                this.transform.rotation = Quaternion.LookRotation(newDir);
                this.transform.position = Vector3.MoveTowards(this.transform.position, targets[i].transform.position, 1.5f * Time.deltaTime);
                yield return null;
            }
        }
    }

    private IEnumerator NewHut()
    {
        anim.SetBool("NewHut", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("NewHut", false);
        anim.SetBool("GoalReach", false);
        while (!anim.GetBool("GoalReach"))
        {
            Vector3 targetPos = targets[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 4f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targets[i].transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
    }
}
