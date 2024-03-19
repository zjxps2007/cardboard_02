using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform firePosition;
    public GameObject bullet;
    public Text startText;
    public int HP;
    public int score;

    private void Start()
    {
        HP = 50;
        score = 0;
        UpdatetState();
    }
    
    private void Update()
    {
        firePosition.rotation = mainCam.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void UpdatetState()
    {
        startText.text = " Score\n" + score + "\n" + " HP\n" + HP;
    }
    

    void Fire()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
    }
}
