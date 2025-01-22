using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
    


    [SerializeField] int subdivisions_count;
    [SerializeField] float radius;
    [SerializeField] Vector3 center;
    
    
    [SerializeField] float area;

    private Vector3[] rotated_points;

    private void Update()
    {
        float angle = (360 / subdivisions_count) / (180 / Mathf.PI);

        for (int i = 0; i < subdivisions_count+1; i++)
        {

            float x_pos = radius * Mathf.Cos(angle);
            float y_pos = radius* Mathf.Sin(angle);

            Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
            rotated_points[i] = rotation_point;

            Debug.DrawLine(center, rotation_point);
        }
    }
}
