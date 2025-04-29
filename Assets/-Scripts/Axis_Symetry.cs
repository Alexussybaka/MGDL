using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis_Symetry : MonoBehaviour
{
    [Header("Axis Parameters")]
    [Range(0f, 100f)]
    [SerializeField] private float axis_view_multiplier;
    [SerializeField] private Vector2 axis_vector;
    [SerializeField] private List<Vector2> vertexes;

    private void Update()
    {
        //Drawing axis
        Debug.DrawLine(Vector3.zero, new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);
        Debug.DrawLine(Vector3.zero, -new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);

        //Drawing original shape
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        Vector3 second_vector = new Vector3(axis_vector.y, 0f, -axis_vector.x);
        Debug.DrawLine(Vector3.zero, second_vector);

        //for (int i = 0; i < vertexes.Count - 1; i++)
        //{

        //}
    }
}
