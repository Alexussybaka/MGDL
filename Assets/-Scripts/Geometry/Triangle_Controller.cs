using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Triangle_Controller : MonoBehaviour
{
    [Header("Sides : Changeable")]

    [SerializeField] float triangle_a;
    [SerializeField] float triangle_b;
    [SerializeField] float triangle_c;

    [Space]
    [Header("Angles : Read Only")]

    [SerializeField] float angle_a;
    [SerializeField] float angle_b;
    [SerializeField] float angle_c;

    [Space]
    [Header("Pythagorean Theorem")]

    //Set the side you want to calculate based on change of another side. Ticking all true can cause null outcome.
    [SerializeField] bool unknown_a;
    [SerializeField] bool unknown_b;
    [SerializeField] bool unknown_c;

    [Space]
    [Header("Other Info : Read Only")]

    [SerializeField] float triangle_area;

    private void Update()
    {
        //Calculating area using a * b / 2 formula.
        triangle_area = (triangle_a * triangle_b) / 2;

        //Calculating unknown side using a^2 + b^2 = c^ otherwise pythagorean theorem.
        if (unknown_a) triangle_a = Mathf.Sqrt((triangle_c * triangle_c) - (triangle_b * triangle_b));
        if (unknown_b) triangle_b = Mathf.Sqrt((triangle_c * triangle_c) - (triangle_a * triangle_a));
        if (unknown_c) triangle_c = Mathf.Sqrt((triangle_a * triangle_a) + (triangle_b * triangle_b));

        // Calculating angles using cosinus function and acos to convert it to radians and then converting to degrees
        angle_a = Mathf.Acos(triangle_b / triangle_c) * (180/Mathf.PI);
        angle_b = Mathf.Acos(triangle_a / triangle_c) * (180/Mathf.PI);
        angle_c = 90f;



        // Drawing the triangle.

        // Side a
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, triangle_a));
        
        // Side b
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(triangle_b, 0f, 0f));
        
        // Side c
        Debug.DrawLine(new Vector3(triangle_b, 0f, 0f), new Vector3(0f, 0f, triangle_a));
    }
}
