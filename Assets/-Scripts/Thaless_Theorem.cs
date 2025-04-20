using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thaless_Theorem : MonoBehaviour
{
    [SerializeField] private float radius;

    [Range(0f, 360f)]
    [SerializeField] private float angle;

    [SerializeField] private bool draw_circle;
    private List<Vector3> rotated_points;

    private void Update()
    {
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), new Vector3(radius, 0f, 0f));

        Vector3 right_point = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), 0f, Mathf.Sin(angle * (Mathf.PI / 180f)));

        Debug.DrawLine(new Vector3(radius, 0f, 0f), right_point);
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), right_point);

        //Drawing circle
        if (draw_circle)
        {
            float angle = (360 / 24) / (180 / Mathf.PI);

            for (int i = 1; i < 25; i++)
            {
                float x_pos = radius * Mathf.Cos(angle * i);
                float y_pos = radius * Mathf.Sin(angle * i);

                Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
                rotated_points.Add(rotation_point);
            }

            for (int i = 0; i < rotated_points.Count - 1; i++)
            {
                Debug.DrawLine(rotated_points[i], rotated_points[i + 1]);
            }
            Debug.DrawLine(rotated_points[rotated_points.Count - 1], rotated_points[0]);

            rotated_points.Clear();
        }
    }
}
