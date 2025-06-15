using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosine_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
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
        for (float i = 0; i < limit; i += resolution)
        {
            vectors.Add(new Vector3(i, 0f, Mathf.Cos(i)));
        }

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        vectors.Clear();
    }
}
