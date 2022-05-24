using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    GameObject interactableManager, gestureManager;
    InteractableManager i_manager;
    RecognizeDynamicRHand recognizeDynamic_R;
    RecognizeDynamicLHand recognizeDynamic_L;
    
    // Start is called before the first frame update
    void Start()
    {
        interactableManager = GameObject.FindGameObjectWithTag("Interactable");
        gestureManager = GameObject.FindGameObjectWithTag("GestureManager");
        i_manager = interactableManager.GetComponent<InteractableManager>();
        recognizeDynamic_R = gestureManager.GetComponent<RecognizeDynamicRHand>();
        recognizeDynamic_L = gestureManager.GetComponent<RecognizeDynamicLHand>();
    }

    public void AddMyCollectible()
    {
        i_manager.AddCollectibleToCollection(this.name);
        this.gameObject.SetActive(false);
    }

    public void ICanGrab()
    {
        recognizeDynamic_R.iCanGrab_R = true;
        recognizeDynamic_L.iCanGrab_L = true;
    }

    public void ICannotGrab()
    {
        recognizeDynamic_R.iCanGrab_R = false;
        recognizeDynamic_L.iCanGrab_L = false;
    }
}
