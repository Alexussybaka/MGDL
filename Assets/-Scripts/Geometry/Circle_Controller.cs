using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
    [Header("Circle : Preferences")]
    [Range(1, 360)]
    [SerializeField] int subdivisions_count;
    [SerializeField] bool show_subdivisions;
    [Space]

    [SerializeField] float radius;
    [SerializeField] Vector3 center;
    [Space]

    [Header("Info : Read Only")]
    [SerializeField] float area;
    [SerializeField] float circumference;
    [SerializeField] float diameter;

    private List<Vector3> rotated_points = new List<Vector3>();

    private void Update()
    {
        // Calculating all read-only variables
        area = Mathf.PI * (radius * radius);
        circumference = 2 * Mathf.PI * radius;
        diameter = 2 * radius;

        // Defining angle value by deviding 360 degrees with our resolution and then converting into radians
        float angle = (360 / subdivisions_count) / (180 / Mathf.PI);

        // Calculating the circle using sinus and cosinus trigonometric functions
        for (int i = 1; i < subdivisions_count+1; i++)
        {
            // Safe procedures to ensure we don't get zero division error.
            if(subdivisions_count == 0) return;

            float x_pos = radius * Mathf.Cos(angle * i);
            float y_pos = radius* Mathf.Sin(angle * i);

            Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
            rotated_points.Add(rotation_point);

            if(show_subdivisions) Debug.DrawLine(center, rotation_point);
        }

        // Rendering the circle
        for (int i = 0; i < rotated_points.Count -1; i++)
        {
            Debug.DrawLine(rotated_points[i], rotated_points[i+1]);
        }
        Debug.DrawLine(rotated_points[rotated_points.Count-1], rotated_points[0]);

        rotated_points.Clear();
    }
}
