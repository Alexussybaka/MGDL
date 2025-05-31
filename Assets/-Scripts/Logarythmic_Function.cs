using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logarythmic_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("a^y = x")]
    [SerializeField] float a;
    [SerializeField] bool eulers;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;
}
