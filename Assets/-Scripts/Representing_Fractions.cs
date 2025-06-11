using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Representing_Fractions : MonoBehaviour
{
    [SerializeField] bool via_circle;
    [SerializeField] float fraction_value;
    [SerializeField] float maximum_value;
    List<Vector3> rotated_points = new List<Vector3>();

    private void Update()
    {
        if (maximum_value == 0) maximum_value = 0.0000000001f;

        if (via_circle)
        {
            float angle = 4 / (180 / Mathf.PI);
            float radians_fraction = (fraction_value / maximum_value) * 2 * Mathf.PI;

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

            Debug.DrawLine(Vector3.zero, new Vector3(10, 0f, 0f));
            Debug.DrawLine(Vector3.zero, 10 * new Vector3(Mathf.Cos(radians_fraction), 0f, Mathf.Sin(radians_fraction)));
        }
    }
}
