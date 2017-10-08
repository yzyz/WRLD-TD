using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerListener : MonoBehaviour {

    public GameObject storedObject;
    public ControllerListener otherListener;
    public GameObject menu;


    void Start()
    {
        GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(ActivateMenu);
        menu = transform.Find("Menu").gameObject;

        GetComponent<VRTK_ControllerEvents>().GripReleased += new ControllerInteractionEventHandler(GripReleased);
    }

    private void ActivateMenu(object sender, ControllerInteractionEventArgs e)
    {
        bool set = !menu.activeSelf;
        menu.SetActive(set);
        if (set)
        {
            otherListener.menu.SetActive(!set);
        }
        

    }

    private void GripReleased(object sender, ControllerInteractionEventArgs e)
    {
        if (storedObject != null)
        {
            storedObject.transform.parent = null;
            storedObject = null;
        }
    }
}
