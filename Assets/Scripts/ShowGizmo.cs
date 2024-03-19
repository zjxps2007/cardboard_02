using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour
{
    Color color = Color.green;
    private float radius = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(this.transform.position, radius);
    }
}
