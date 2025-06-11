using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Representing_Fractions : MonoBehaviour
{
    [SerializeField] bool via_circle;
    List<Vector3> rotated_points = new List<Vector3>();

    private void Update()
    {
        float angle = 4 / (180 / Mathf.PI);

        for (int i = 1; i < 90 + 1; i++)
        {
            float x_pos = 10 * Mathf.Cos(angle * i);
            float y_pos = 10 * Mathf.Sin(angle * i);

            Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
            rotated_points.Add(rotation_point);
        }

        for (int i = 0; i < rotated_points.Count - 1; i++)
        {
            Debug.DrawLine(rotated_points[i], rotated_points[i + 1]);
        }
        Debug.DrawLine(rotated_points[rotated_points.Count - 1], rotated_points[0]);
    }
}
