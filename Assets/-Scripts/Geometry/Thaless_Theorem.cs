using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thaless_Theorem : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0f, 360f)]
    [SerializeField] private float angle;
    [Space]
    [SerializeField] private float radius;
    [Space]
    [SerializeField] private bool draw_circle;
    [Range(1f, 360f)]
    [SerializeField] int subdivision_count;
    private List<Vector3> rotated_points = new List<Vector3>();

    private void Update()
    {
        //Drawing a hypotenuse
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), new Vector3(radius, 0f, 0f));

        //Drawing the right angle point
        Vector3 right_point = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)) * radius, 0f, Mathf.Sin(angle * (Mathf.PI / 180f)) * radius);

        Debug.DrawLine(new Vector3(radius, 0f, 0f), right_point);
        Debug.DrawLine(new Vector3(-radius, 0f, 0f), right_point);

        if (draw_circle)
        {
            // Defining angle variable to set a specific resolution for a circle
            float angle = (360 / subdivision_count) / (180 / Mathf.PI);

            // Calculating the circle
            for (int i = 1; i < subdivision_count + 1; i++)
            {
                float x_pos = radius * Mathf.Cos(angle * i);
                float y_pos = radius * Mathf.Sin(angle * i);

                Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
                rotated_points.Add(rotation_point);
            }

            // Rendering the circle
            for (int i = 0; i < rotated_points.Count - 1; i++)
            {
                Debug.DrawLine(rotated_points[i], rotated_points[i + 1]);
            }
            Debug.DrawLine(rotated_points[rotated_points.Count - 1], rotated_points[0]);

            rotated_points.Clear();
        }
    }
}
