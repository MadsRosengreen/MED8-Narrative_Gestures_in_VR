using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_02_FailSafe : MonoBehaviour
{
    public GameObject gestureManager;
    GestureFunctions gestureFunctions;

    float time = 0f, timer = 180f;

    bool hasFailSafed = false;

    // Start is called before the first frame update
    void Start()
    {
        gestureFunctions = gestureManager.GetComponent<GestureFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > timer && !hasFailSafed)
        {
 
            gestureFunctions.hasCheckedSand = true;
            gestureFunctions.Kudu_R();
            gestureFunctions.FlatDownUp_R();
            hasFailSafed = true;
        }
    }
}
