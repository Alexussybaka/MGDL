using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{


    [Range(1, 360)]
    [SerializeField] int subdivisions_count;
    [SerializeField] float radius;
    [SerializeField] Vector3 center;
    
    
    [SerializeField] float area;

    private List<Vector3> rotated_points;

    private void Update()
    {
        float angle = (360 / subdivisions_count) / (180 / Mathf.PI);

        for (int i = 1; i < subdivisions_count+1; i++)
        {
            // Safe procedures to ensure we don't get zero division error.
            if(subdivisions_count == 0) return;


            float x_pos = radius * Mathf.Cos(angle * i);
            float y_pos = radius* Mathf.Sin(angle * i);

            Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
            rotated_points.Add(rotation_point);

            Debug.DrawLine(center, rotation_point);
        }
    }
}
