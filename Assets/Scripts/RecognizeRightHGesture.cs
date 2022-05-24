using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognizeRightHGesture : MonoBehaviour
{
    RecordGesture recordGesture;
    HandInitializer handInitializer;

    public float threshold = 0.4f;

    public StaticGesture currentGesture_R;

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
            if (RecognizedRight().name == "SandCheck_R" && handInitializer.sandCollision_R.isTouchingSand_R)
            {
                currentGesture_R = RecognizedRight();
                //Debug.Log("The right hand is touching and making sand!");
            }
            else if (RecognizedRight().name != "SandCheck_R" && RecognizedRight().name != null)
            {
                currentGesture_R = RecognizedRight();
                //Debug.Log("I recognised the right hand doing: " + currentGesture_R.name + "!");
            }
            else
            {
                currentGesture_R = RecognizedRight();
            }
        }
    }

    StaticGesture RecognizedRight()
    {
        StaticGesture currentGesture = new StaticGesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in recordGesture.R_Gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < handInitializer.fingerBonesRightH.Count; i++)
            {
                Vector3 currentData = handInitializer.rightHandSkeleton.transform.InverseTransformPoint(handInitializer.fingerBonesRightH[i].Transform.position);
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
