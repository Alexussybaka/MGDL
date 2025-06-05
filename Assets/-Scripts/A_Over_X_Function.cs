using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Over_X_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = a/x")]
    [SerializeField] float a;
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
        for (float i = -limit; i < limit; i += resolution)
        {
            if(i == 0 ) continue;
            if(a / i <= limit) vectors.Add(new Vector3(i, 0, a / i));
        }

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        vectors.Clear();
    }
}
