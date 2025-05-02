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

    private List<Vector3> picture = new List<Vector3>();

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

        //Computing new picture point
        for (int i = 0;i < vertexes.Count - 1; i++)
        {
            //formula = float det = ((vertexes[i].x - (axis_vector.y + vertexes[i].x)) * (0 - axis_vector.y)) - ((vertexes[i].y - (-axis_vector.x + vertexes[i].y)) * (0 - axis_vector.x));
            // Simplified to:
            float det = Mathf.Pow(axis_vector.y, 2) + Mathf.Pow(axis_vector.x, 2);

            if (det == 0) return;
            else
            {
                // X
                float middle_x = ((Mathf.Pow(axis_vector.x, 2) * vertexes[i].x) + (axis_vector.y * vertexes[i].y * axis_vector.x)) / det;

                // Y
                float middle_y = ((axis_vector.x * vertexes[i].x * axis_vector.y) + (Mathf.Pow(axis_vector.y, 2) * vertexes[i].y)) / det;

                Vector3 picture_point = new Vector3((2 * middle_x) - vertexes[i].x, 0f, (2 * middle_y) - vertexes[i].y);

                picture.Add(picture_point);
            }
        }

        // Rendering the picture
        if (picture.Count > 0)
        {
            for (int i = 0; i < picture.Count - 1; i++)
            {
                Debug.DrawLine(new Vector3(picture[i].x, 0f, picture[i].y), new Vector3(picture[i + 1].x, 0f, picture[i + 1].y));
            }
        }

        picture.Clear();
    }
}
