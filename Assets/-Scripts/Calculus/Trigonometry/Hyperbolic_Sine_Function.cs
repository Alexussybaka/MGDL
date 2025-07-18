using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperbolic_Sine_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool eulers;
    [Space]
    [SerializeField] float evaluation;

    private List<Vector3> vectors = new List<Vector3>();

    private void Update()
    {
        // Clamping limit to always be a positive number
        if (limit < 0) limit = 0;

        // Calculating this function with it's limit
        for (float i = -limit; i < limit; i += resolution)
        {
            vectors.Add(new Vector3(i, 0f, Mathf.Sin(i)));
        }

        // Plotting the function
        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        vectors.Clear();

        // Additional features
        Visualise_Examined_Number();
        Show_Axis();
    }

    public void Visualise_Examined_Number()
    {
        if (eulers)
        {
            // Calculating evaluation for the analyzed number
            evaluation = Mathf.Sin(number * Mathf.PI);

            // Visualising analyzed number value on Y axis
            if (evaluation >= 0) Debug.DrawLine(new Vector3(number * Mathf.PI, 0f, 0f), new Vector3(number * Mathf.PI, 0f, -0.5f), Color.red);
            else Debug.DrawLine(new Vector3(number * Mathf.PI, 0f, 0f), new Vector3(number * Mathf.PI, 0f, 0.5f), Color.red);

            // Visualising analyzed number value on X axis
            if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(-0.5f, 0f, evaluation), Color.blue);
            else Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(0.5f, 0f, evaluation), Color.blue);

            // Rendering lines that point evaluation on the graph
            Debug.DrawLine(new Vector3(number * Mathf.PI, 0f, 0f), new Vector3(number * Mathf.PI, 0f, evaluation), Color.green);
            Debug.DrawLine(new Vector3(number * Mathf.PI, 0f, evaluation), new Vector3(0f, 0f, evaluation), Color.green);
        }
        else
        {
            // Calculating evaluation for the analyzed number
            evaluation = Mathf.Sin(number);

            // Visualising analyzed number value on Y axis
            if (evaluation >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
            else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.red);

            // Visualising analyzed number value on X axis
            if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(-0.5f, 0f, evaluation), Color.blue);
            else Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(0.5f, 0f, evaluation), Color.blue);

            // Rendering lines that point evaluation on the graph
            Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, evaluation), Color.green);
            Debug.DrawLine(new Vector3(number, 0f, evaluation), new Vector3(0f, 0f, evaluation), Color.green);
        }
    }

    public void Show_Axis()
    {
        if (show_axis)
        {
            // Plotting X and Y axis
            Debug.DrawLine(new Vector3(-limit, 0, 0), new Vector3(limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -limit), new Vector3(0, 0, limit));
        }
    }
}
