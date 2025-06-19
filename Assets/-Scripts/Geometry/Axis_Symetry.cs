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

    private List<Vector2> picture = new List<Vector2>();

    private void Update()
    {
        // Drawing axis
        Debug.DrawLine(Vector3.zero, new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);
        Debug.DrawLine(Vector3.zero, -new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);

        // Drawing original shape
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        // Computing new picture point
        for (int i = 0; i < vertexes.Count; i++)
        {
            Vector2 point = vertexes[i];

            float projection_length = Vector2.Dot(point, axis_vector.normalized);

            point = projection_length * axis_vector.normalized;

            Vector2 picture_point = (point * 2) - vertexes[i];

            picture.Add(new Vector2(picture_point.x, picture_point.y));
        }

        // Rendering the picture
        if (picture.Count > 1)
        {
            for (int i = 0; i < picture.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(picture[i].x, 0f, picture[i].y), new Vector3(picture[i + 1].x, 0f, picture[i + 1].y));
            }
        }

        picture.Clear();
    }
}
