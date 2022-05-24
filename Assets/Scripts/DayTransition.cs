using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DayTransition : MonoBehaviour
{

    public Vector3 targetAngle = new Vector3(185, 0, 0);
    Vector3 currentAngle;
    public Vector4 targetAlpha = new Vector4(0, 0, 0, 1);
    Vector4 currentAlpha;

    public float transitionSpeed = 0.5f;

    SceneChange sceneChange;
    public GameObject fade;
    public Light sun;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = fade.GetComponent<SceneChange>();
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            sun.transform.eulerAngles = new Vector3(0, 0, 0);
            currentAngle = sun.transform.eulerAngles;
            targetAngle = new Vector3(55, -30, 0);
            fade.GetComponent<Image>().color = targetAlpha;
            currentAlpha = fade.GetComponent<Image>().color;
            targetAlpha = Vector4.zero;

            GoToDay();
            Debug.Log("We are going towards day!");
        }
        else
        {
            currentAngle = sun.transform.eulerAngles;
            currentAlpha = fade.GetComponent<Image>().color;
        }
    }


    public void GoToNight()
    {
        StartCoroutine(TransitionToNight());
    }

    void GoToDay()
    {
        StartCoroutine(TransitionToDay());
    }

    private IEnumerator TransitionToNight()
    {
        while (currentAngle.x < targetAngle.x - 5f)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, transitionSpeed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, transitionSpeed * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, transitionSpeed * Time.deltaTime)
            );

            sun.transform.eulerAngles = currentAngle;

            currentAlpha = new Vector4(
                Mathf.Lerp(currentAlpha.x, targetAlpha.x, transitionSpeed * Time.deltaTime),
                Mathf.Lerp(currentAlpha.y, targetAlpha.y, transitionSpeed * Time.deltaTime),
                Mathf.Lerp(currentAlpha.z, targetAlpha.z, transitionSpeed * Time.deltaTime),
                Mathf.Lerp(currentAlpha.w, targetAlpha.w, transitionSpeed * Time.deltaTime)
                );

            fade.GetComponent<Image>().color = currentAlpha;
            yield return null;
        }
        sceneChange.ChangeSceneAdv(2, 3);
        
    }

    private IEnumerator TransitionToDay()
    {
        while (currentAngle.x < targetAngle.x - 5f)
        {
            Debug.Log(currentAngle.x);
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, (transitionSpeed - 0.25f) * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, (transitionSpeed - 0.25f) * Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, (transitionSpeed - 0.25f) * Time.deltaTime)
            );

            
            sun.transform.eulerAngles = currentAngle;

            currentAlpha = new Vector4(
                Mathf.Lerp(currentAlpha.x, targetAlpha.x, (transitionSpeed - 0.25f) * Time.deltaTime),
                Mathf.Lerp(currentAlpha.y, targetAlpha.y, (transitionSpeed - 0.25f) * Time.deltaTime),
                Mathf.Lerp(currentAlpha.z, targetAlpha.z, (transitionSpeed - 0.25f) * Time.deltaTime),
                Mathf.Lerp(currentAlpha.w, targetAlpha.w, (transitionSpeed - 0.25f) * Time.deltaTime)
                );

            fade.GetComponent<Image>().color = currentAlpha;
            yield return null;
        }
    }
}
