﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class ShopItem : VRTK_InteractableObject {

    public static float rotateSpeed = .2f;

    public GameObject prefab;

    private VRTK_InteractGrab grabObject;

	void Start () {
        
    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        TakeItem(usingObject);
    }

    protected override void Update() {
        base.Update();
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
	}

    private void TakeItem(VRTK_InteractUse usingObject)
    {
        // Spawn new item and have it be grabbed
        GameObject item = Instantiate(prefab, transform.position - new Vector3(0, .1f, 0), transform.rotation);
        item.transform.parent = usingObject.gameObject.transform;
        usingObject.gameObject.GetComponent<ControllerListener>().storedObject = item;
    }
}