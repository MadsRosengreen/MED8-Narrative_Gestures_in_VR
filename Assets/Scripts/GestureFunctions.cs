using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureFunctions : MonoBehaviour
{
    HandInitializer handInitializer;
    RecognizeDynamicRHand recognizeDynamic_R;
    RecognizeDynamicLHand recognizeDynamic_L;
    [SerializeField]
    List<NPCTriggers> npcTriggers;

    public GameObject[] NPCs;

    public GameObject sandParticles;

    public bool isReady = false, isCrouching = false, hasCheckedSand = false, hasMovedNPCs = false;


    private void Start()
    {
        handInitializer = GetComponent<HandInitializer>();
        recognizeDynamic_R = GetComponent<RecognizeDynamicRHand>();
        recognizeDynamic_L = GetComponent<RecognizeDynamicLHand>();

        if (NPCs != null)
        {
            for (int i = 0; i < NPCs.Length; i++)
            {
                NPCTriggers trigger = NPCs[i].GetComponent<NPCTriggers>();
                npcTriggers.Add(trigger);
            }
        }
        
    }

    public void FlatDownUp_R()
    {
        if (!isCrouching && !isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCDuck(false);
                isCrouching = true;
            }
        }
        else if (!isCrouching && isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCDuck(true);
                isCrouching = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }
    public void FlatDownUp_L()
    {
        if (!isCrouching && !isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCDuck(false);
                isCrouching = true;
            }
        }
        else if (!isCrouching && isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCDuck(true);
                isCrouching = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }
    public void SlightDownUp_R()
    {
        if (!isCrouching && !isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCDuck(false);
                isCrouching = true;
            }
        }
        else if (!isCrouching && isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCDuck(true);
                isCrouching = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }
    public void SlightDownUp_L()
    {
        if (!isCrouching && !isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCDuck(false);
                isCrouching = true;
            }
        }
        else if (!isCrouching && isReady)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCDuck(true);
                isCrouching = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }


    public void Kudu_R()
    {
        if (!isReady && !isCrouching)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCReady(false);
                isReady = true;
            }
        }
        else if (!isReady && isCrouching)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCReady(true);
                isReady = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }

    public void Kudu_L()
    {
        if (!isReady && !isCrouching)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and not crouching, play ready animation
                npcTriggers[i].NPCReady(false);
                isReady = true;
            }
        }
        else if (!isReady && isCrouching)
        {
            for (int i = 0; i < npcTriggers.Count; i++)
            {
                // If NPCs aren't readied yet and is crouching, play crouching-ready animation
                npcTriggers[i].NPCReady(true);
                isReady = true;
            }
        }

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }

    public void SandCheck_R()
    {
        // Instantiates sand particles when this function name is recognised as a gesture
        GameObject particles = Instantiate(sandParticles, handInitializer.fingerBonesRightH[8].Transform.position, Quaternion.Euler(90, 0, 0), handInitializer.fingerBonesRightH[8].Transform);
        particles.GetComponent<ParticleSystem>().Play();
        recognizeDynamic_R.particlesInstantiated_R = true;
        hasCheckedSand = true;

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }

    public void SandCheck_L()
    {
        // Instantiates sand particles when this function name is recognised as a gesture
        GameObject particles = Instantiate(sandParticles, handInitializer.fingerBonesLeftH[8].Transform.position, Quaternion.Euler(90, 0, 0), handInitializer.fingerBonesLeftH[8].Transform);
        particles.GetComponent<ParticleSystem>().Play();
        recognizeDynamic_L.particlesInstantiated_L = true;
        hasCheckedSand = true;

        // Checks if NPCs are ready to move
        if (isCrouching && isReady && hasCheckedSand && !hasMovedNPCs)
        {
            MoveNPCS();
            hasMovedNPCs = true;
        }
    }

    public void MoveNPCS()
    {
        for (int i = 0; i < npcTriggers.Count; i++)
        {
            // Set all NPCs to move
            npcTriggers[i].NPCMove();
        }
    }
}
