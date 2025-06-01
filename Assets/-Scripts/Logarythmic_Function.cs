using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logarythmic_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = log(a, x)")]
    [SerializeField] float a;
    [SerializeField] bool eulers;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private List<Vector3> vectors = new List<Vector3>();

    private void Update()
    {
        if (a == 0) return;

        for (float i = -limit; i < 0; i += resolution)
        {
            if (i == 0) continue;

            vectors.Add(new Vector3(i, 0, Mathf.Log(a, i)));
        }
        
        for (float i = 0; i < limit; i += resolution)
        {
            if (i == 0) continue;

            vectors.Add(new Vector3(i, 0, Mathf.Log(a, i)));
        }


        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        vectors.Clear();

        Visualise_Examined_Number();
        ShowAxis();
    }

    private void Visualise_Examined_Number()
    {

    }

    private void ShowAxis()
    {
        if (show_axis)
        {
            Debug.DrawLine(new Vector3(-limit, 0, 0), new Vector3(limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -limit), new Vector3(0, 0, limit));
        }
    }
}
