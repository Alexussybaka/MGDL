using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [SerializeField] string y_equals;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.01f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool radians;
    [Space]
    [SerializeField] float evaluation;

    private List<Vector3> vectors = new List<Vector3>();

    private void Update()
    {
        string[] equation = y_equals.Split(" ");
        string x_mon = null;

        foreach (string monomial in equation)
        {
            if (monomial.EndsWith("x"))
            {
                x_mon = monomial;
                break;
            }
        }    }
}
