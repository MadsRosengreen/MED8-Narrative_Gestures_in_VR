using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public Image Obj2Fade;
    /// <summary>
    /// Give scene number, found in File -> Build settings -> top box (If the scene is not there, add it with drag and drop)
    /// </summary>
    /// <param name="sceneNo"></param>
    /// 

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            Obj2Fade.color = new Vector4(0, 0, 0, 1);
            StartCoroutine(Fader(0, 0));
        }
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeSceneAdv(int fadeMode = 1, int sceneNo = 0)
    {
        StartCoroutine(Fader(fadeMode, sceneNo));
    }
    public void ChangeSceneSimple(int sceneNo = 0)
    {
        StartCoroutine(Fader(1, sceneNo));
    }

    private IEnumerator Fader(int a = 0, int sceneNo = 0)
    {
        float black = 0f;
        if (a == 1)
        {
            while (Obj2Fade.color.a <= 1)
            {
                black += 0.5f * Time.deltaTime;
                Obj2Fade.GetComponent<Image>().color = new Vector4(0, 0, 0, black);
                //Debug.Log(black);
                yield return null;
            }
            /*if(a == 0)
            {
                movableObject.transform.position = targetObject.transform.position;
            }*/
            SceneManager.LoadScene(sceneNo);
        }
        else if (a == 2)
        {
            SceneManager.LoadScene(sceneNo);
        }
        else
        {
            while (Obj2Fade.color.a >= 0)
            {
                black -= 0.5f * Time.deltaTime;
                Obj2Fade.GetComponent<Image>().color = new Vector4(0, 0, 0, black);
                //Debug.Log(black);
                yield return null;
            }
        }
        yield return null;
    }
}
