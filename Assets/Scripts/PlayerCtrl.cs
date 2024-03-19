using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform firePosition;
    public GameObject bullet;

    private void Update()
    {
        firePosition.rotation = mainCam.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
    }
}
