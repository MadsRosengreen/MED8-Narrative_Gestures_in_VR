using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KudoTrigger : MonoBehaviour
{
    public Animator KudoMover;
    public GameObject[] EscapePoint;

    public SoundManager Sound;
    public ArrowControl Arrow;

    public bool KudoGone = false;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KudoGoBrrr()
    {
        Sound.timerStarted = true;
        KudoMover.Play("kudoRunning");
        StartCoroutine(Mover());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            i += 1;
            if (i == 6)
            {
                Arrow.DropArrow();
            }
            if (i == 11)
            {
                KudoGone = true;
            }
        }
    }

    private IEnumerator Mover()
    {
        while (!KudoGone)
        {
            Vector3 targetPos = EscapePoint[i].transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetPos, 3.5f * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDir);
            this.transform.position = Vector3.MoveTowards(this.transform.position, EscapePoint[i].transform.position, 5f*Time.deltaTime);
            yield return null;
        }
    }
}
