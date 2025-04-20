using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thaless_Theorem : MonoBehaviour
{
    [SerializeField] private float radius;

    [Range(0f, 360f)]
    [SerializeField] private float angle;

    private void Update()
    {
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), new Vector3(radius, 0f, 0f));

        Vector3 right_point = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), 0f, Mathf.Sin(angle * (Mathf.PI / 180f)));

        Debug.DrawLine(new Vector3(radius, 0f, 0f), right_point);
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), right_point);
    }
}
