using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpheres : MonoBehaviour
{
    public void DestroyOtherPaths(string pathName, string originSphereHand)
    {
        GameObject[] originSpheres = GameObject.FindGameObjectsWithTag(originSphereHand);

        for (int i = 0; i < originSpheres.Length; i++)
        {
            if (originSpheres[i].name != pathName)
            {
                Destroy(originSpheres[i]);
            }
        }
    }

    public void DestroyOriginSpheres(string originSphereHand)
    {
        GameObject[] originSpheres = GameObject.FindGameObjectsWithTag(originSphereHand);

        for (int i = 0; i < originSpheres.Length; i++)
        {
            Destroy(originSpheres[i]);
        }
    }
}
