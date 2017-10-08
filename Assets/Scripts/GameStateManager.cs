using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Wrld;
using Wrld.Resources.Buildings;
using Wrld.Space;

public class GameStateManager : MonoBehaviour {

    public int gold;
    public int health;
    public int maxHealth;

    public GameObject leftMenu;
    public GameObject rightMenu;

    public Material highHealth;
    public Material midHealth;
    public Material lowHealth;

    private LatLong baseLocation = LatLong.FromDegrees(37.795189, -122.402777);
    private string baseName = "Buildings_0_01131232132010_landmark_us_sf_transamericapyramid_INDEX0";
    
    public GameObject baseObject;

    private Material[] oldMaterials = new Material[1];
    private Material[] newMaterials = new Material[2];

    // Use this for initialization
    void Start () {
        health = maxHealth;

        Invoke("StartGame", 5);
	}

    void StartGame()
    {
        baseObject = GameObject.Find(baseName);

        // Material stuff
        oldMaterials[0] = baseObject.GetComponent<MeshRenderer>().material;
        newMaterials[0] = oldMaterials[0];

        StartCoroutine(Blink());
    }
	
	// Update is called once per frame
	void Update () {
        // Update gold values
        leftMenu.transform.Find("CoinObjectTooltip").GetComponent<VRTK_ObjectTooltip>().UpdateText("" + gold);
        rightMenu.transform.Find("CoinObjectTooltip").GetComponent<VRTK_ObjectTooltip>().UpdateText("" + gold);
    }

    IEnumerator Blink()
    {
        bool on = false;
        MeshRenderer meshRenderer = baseObject.GetComponent<MeshRenderer>();
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (on)
            {
                meshRenderer.materials = oldMaterials;
                on = false;
            }
            else
            {
                Material mat = null;
                if (health > maxHealth * .7)
                    mat = highHealth;
                else if (health > maxHealth * .3)
                    mat = midHealth;
                else
                    mat = lowHealth;
                newMaterials[1] = mat;
                meshRenderer.materials = newMaterials;
                on = true;
            }
        }
    }
}
