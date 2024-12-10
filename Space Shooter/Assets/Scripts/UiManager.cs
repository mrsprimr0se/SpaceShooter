using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;


    public List<GameObject> hpPointsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameManager.uiManager = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /* Player HP
    3         0
    2         1
    1         2
    */

    public void DisableHpSprite(int value)
    {
        hpPointsList[value-1].SetActive(false);
    }
}
