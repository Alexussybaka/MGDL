using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_Controller : MonoBehaviour
{
    [SerializeField] float triangle_a, triangle_b, triangle_c;
    [SerializeField] bool unknown_a, unknown_b, unknown_c;
    [SerializeField] float triangle_area;

    private void Update()
    {
        //Calculating area using a * b / 2 formula.
        triangle_area = (triangle_a * triangle_b) / 2;

        //Calculating unknown side using a^2 + b^2 = c^2.
        if (unknown_a) triangle_a = Mathf.Sqrt((triangle_c * triangle_c) - (triangle_b * triangle_b));
        if (unknown_b) triangle_b = Mathf.Sqrt((triangle_c * triangle_c) - (triangle_a * triangle_a));
        if (unknown_c) triangle_c = Mathf.Sqrt((triangle_a * triangle_a) + (triangle_b * triangle_b));

        // Drawing the triangle.

        // Side a
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, triangle_a));
        
        // Side b
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(triangle_b, 0f, 0f));
        
        // Side c
        Debug.DrawLine(new Vector3(triangle_b, 0f, 0f), new Vector3(0f, 0f, triangle_a));
    }
}
