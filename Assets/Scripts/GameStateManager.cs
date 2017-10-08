using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GameStateManager : MonoBehaviour {

    public int gold;
    public int health;
    public int maxHealth;

    public GameObject leftMenu;
    public GameObject rightMenu;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        // Update gold values
        leftMenu.transform.Find("CoinObjectTooltip").GetComponent<VRTK_ObjectTooltip>().UpdateText("" + gold);
        rightMenu.transform.Find("CoinObjectTooltip").GetComponent<VRTK_ObjectTooltip>().UpdateText("" + gold);
    }
}
