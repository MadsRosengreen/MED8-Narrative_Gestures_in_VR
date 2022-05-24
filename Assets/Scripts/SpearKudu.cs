using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearKudu : MonoBehaviour
{
    Animator animKudu;
    public bool kuduIsDead;

    public AudioSource DeadKudu;

    public KillKudoNPCTriggers NPCTrigger;

    public GameObject fade;
    SceneChange sceneChange;

    float time = 0f;
    public float timer = .3f;
    [SerializeField]
    int sceneTransitionIndex = 6;

    private void Start()
    {
        animKudu = GetComponent<Animator>();
        sceneChange = fade.GetComponent<SceneChange>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Spear" && other.isTrigger == true && !kuduIsDead)
        {
            time += Time.deltaTime;
            if (time >= timer)
            {
                // Play kudu death animation
                animKudu.SetBool("Stabbed", true);
                DeadKudu.Play();
                NPCTrigger.GiveKnife();

                // Make kudu dead
                kuduIsDead = true;
            }
        }
        if (other.tag == "Knife" && other.isTrigger == true && kuduIsDead)
        {
            time += Time.deltaTime;
            if (time >= timer)
            {
                // Transition to next scene when kudu dead and touched by knife
                sceneChange.ChangeSceneSimple(sceneTransitionIndex);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spear" && other.isTrigger == false)
        {
            time = 0f;
        }
        if (other.tag == "Knife" && other.isTrigger == false)
        {
            time = 0f;
        }
    }
}
