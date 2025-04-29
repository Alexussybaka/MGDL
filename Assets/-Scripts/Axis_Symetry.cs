using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_Symetry : MonoBehaviour
{
    [Header("Axis Parameters")]
    [Range(0f, 100f)]
    [SerializeField] private float axis_view_multiplier;
    [SerializeField] private Vector2 axis_vector;

    private void Update()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);
        Debug.DrawLine(Vector3.zero, -new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);
    }
}
