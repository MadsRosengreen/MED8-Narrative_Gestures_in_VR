using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognizeLeftHGesture : MonoBehaviour
{
    RecordGesture recordGesture;
    HandInitializer handInitializer;

    public float threshold = 0.4f;

    public StaticGesture currentGesture_L;

    // Start is called before the first frame update
    void Start()
    {
        recordGesture = GetComponent<RecordGesture>();
        handInitializer = GetComponent<HandInitializer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (handInitializer.isInitialized && !handInitializer.debugMode)
        {
            if (RecognizedLeft().name == "SandCheck_L" && handInitializer.sandCollision_L.isTouchingSand_L)
            {
                currentGesture_L = RecognizedLeft();
                //Debug.Log("The left hand is touching and making sand!");
            }
            else if (RecognizedLeft().name != "SandCheck_L" && RecognizedLeft().name != null)
            {
                currentGesture_L = RecognizedLeft();
                //Debug.Log("I recognised the right hand doing: " + currentGesture_L.name + "!");
            }
            else
            {
                currentGesture_L = RecognizedLeft();
            }
        }
    }

    StaticGesture RecognizedLeft()
    {
        StaticGesture currentGesture = new StaticGesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in recordGesture.L_Gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < handInitializer.fingerBonesLeftH.Count; i++)
            {
                Vector3 currentData = handInitializer.leftHandSkeleton.transform.InverseTransformPoint(handInitializer.fingerBonesLeftH[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);
                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }

        }
        return currentGesture;
    }
}
