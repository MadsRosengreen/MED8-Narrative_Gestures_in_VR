using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractableManager : MonoBehaviour
{
    public List<GameObject> collectibles, collected, spawns;
    public Animator Hunter;
    public SoundManager Sound;

    bool hasPlayed = false;
    // Update is called once per frame
    void Update()
    {
        if (collected.Count > 0 && !hasPlayed)
        {
            if (collected.Count == collectibles.Count)
            {
                if (Hunter != null && Sound != null)
                {
                    Hunter.Play("metarig_idleWave");
                    Sound.PlayTwo();
                    hasPlayed = true;
                }
                

                /*
                if (spawns[0] != null)
                {
                    for (int i = 0; i < spawns.Count; i++)
                    {
                        spawns[i].SetActive(true);
                    }
                }
                */
            }
        }
       
    }

    public void AddCollectibleToCollection(string collectibleName)
    {
        GameObject collectible = collectibles.Find(x => x.name.Contains(collectibleName));

        collected.Add(collectible);
    }
}
