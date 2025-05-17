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
        //Calculating right-angle vector
        Vector2 right_vector = new Vector2(
            axis_vector.y,
            -axis_vector.x
        );

        right_vector.Normalize();

        //Drawing axis
        Debug.DrawLine(Vector3.zero, new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);
        Debug.DrawLine(Vector3.zero, -new Vector3(axis_vector.x, 0f, axis_vector.y) * axis_view_multiplier);

        //Drawing original shape
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        //Computing new picture point
        for (int i = 0;i < vertexes.Count - 1; i++)
        {
            float distance = Mathf.Abs(axis_vector.y * vertexes[i].x - axis_vector.x * vertexes[i].y) / Mathf.Sqrt(Mathf.Pow(axis_vector.y, 2) + Mathf.Pow(axis_vector.x, 2));

            Vector2 picture_point = new Vector2(
                vertexes[i].x * distance,
                vertexes[i].y * distance
            );

            picture_point *= right_vector;

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
