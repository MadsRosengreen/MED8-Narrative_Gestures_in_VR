using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public KudoTrigger Kudo;
    public GameObject arrowStillTarget;

    public bool hit = false, isLoose = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoose)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, arrowStillTarget.transform.position, 8f * Time.deltaTime);
        }
    }

    public void DropArrow()
    {
        this.transform.parent = null;
        this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().useGravity = true;
        //this.gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        isLoose = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kudo")
        {
            hit = !hit;
            Kudo.KudoGoBrrr();
        }
    }

    public void startArrow()
    {
        StartCoroutine(ArrowFly());
    }
    public IEnumerator ArrowFly()
    {
        while (!hit)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Kudo.transform.position + new Vector3(0, 1, 0), 8f * Time.deltaTime);
            yield return null;
        }
        this.transform.parent = null;
        this.transform.parent = Kudo.transform;
    }

    public void ArrowNoLongerLoose()
    {
        isLoose = false;
    }
}
