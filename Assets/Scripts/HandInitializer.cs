using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HandInitializer : MonoBehaviour
{
    public OVRSkeleton recSkeleton, rightHandSkeleton, leftHandSkeleton;
    public List<OVRBone> fingerBonesRec, fingerBonesRightH, fingerBonesLeftH;
    public List<OVRBoneCapsule> fingerCapsulesRightH, fingerCapsulesLeftH;
    public DetectSandCollision sandCollision_R, sandCollision_L;

    public bool debugMode = false, isInitialized = false;


    public IEnumerator DelayInitialize(Action actionToDo)
    {
        if (!debugMode)
        {
            while (!leftHandSkeleton.IsInitialized && !rightHandSkeleton.IsInitialized)
            {
                yield return null;
            }
            actionToDo.Invoke();
        }
        else if (debugMode)
        {
            while (!recSkeleton.IsInitialized)
            {
                yield return null;
            }
            actionToDo.Invoke();
        }

    }

    public void InitializeSkeleton()
    {
        if (!debugMode)
        {
            // Populate the public lists of fingerbones from both hands' OVRskeleton
            sandCollision_R = rightHandSkeleton.Capsules[9].CapsuleRigidbody.gameObject.AddComponent<DetectSandCollision>();
            sandCollision_L = leftHandSkeleton.Capsules[9].CapsuleRigidbody.gameObject.AddComponent<DetectSandCollision>();
            fingerBonesRightH = new List<OVRBone>(rightHandSkeleton.Bones);
            fingerBonesLeftH = new List<OVRBone>(leftHandSkeleton.Bones);

            Debug.Log("Left and right hands are be initialized");
            isInitialized = true;
        }
        else
        {
            fingerBonesRec = new List<OVRBone>(recSkeleton.Bones);
            Debug.Log("Rechand is initialized");
            isInitialized = true;
        }
    }

    void Start()
    {
        StartCoroutine(DelayInitialize(InitializeSkeleton));
    }
}
