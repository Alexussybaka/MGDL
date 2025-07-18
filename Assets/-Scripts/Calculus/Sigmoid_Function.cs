using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigmoid_Function : MonoBehaviour // Also known as Logistics Function
{
    [Header("Graph Settings")]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.01f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private List<Vector3> vectors = new List<Vector3>();
}
