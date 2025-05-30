using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = a * x + b")]
    [SerializeField] float a;
    [SerializeField] float x;
    [SerializeField] float b;

    [SerializeField] bool horizontal;
    [SerializeField] bool show_axis;
    [SerializeField] float limit;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private void Update()
    {
        
    }
}
