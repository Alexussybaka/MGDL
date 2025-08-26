using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = ax^3 + bx^2 + cx + d")]
    [SerializeField] float a;
    [SerializeField] float b;
    [SerializeField] float c;
    [SerializeField] float d;
    [SerializeField] bool horizontal;
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool is_cubed;
    [Space]
    [SerializeField] float evaluation;


    private List<Vector3> vectors = new List<Vector3>();

    float CubeRoot(float x)
    {
        return x < 0 ? -Mathf.Pow(-x, 1f / 3f) : Mathf.Pow(x, 1f / 3f);
    }


    public void Update()
    {
        // Created all points to draw line.
        for (float i = -limit; i < limit; i += resolution)
        {
            vectors.Add(new Vector3(i, 0f, (a * Mathf.Pow(i, 3)) + (b * Mathf.Pow(i, 2)) + (c * i) + d));
        }

        // Drawing all lines
        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        // Reseting the list, so we can change parameter and see it in real time.
        vectors.Clear();

        Visualise_Examined_Number();
        Show_Axis();
    }

    public void Visualise_Examined_Number()
    {
        if (is_cubed)
        {
            // Calculating evaluation for the analyzed number
            evaluation = CubeRoot((a * Mathf.Pow(number, 3)) + (b * Mathf.Pow(number, 2)) + (c * number) + d);

            // Visualising analyzed number value on Y axis
            if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
            else Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(0.5f, 0f, number), Color.red);

            // Visualising analyzed number value on X axis
            if (number >= 0) Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, -0.5f), Color.blue);
            else Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, 0.5f), Color.blue);

            // Rendering lines that point evaluation on the graph
            Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(CubeRoot(number), 0f, number), Color.green);
            Debug.DrawLine(new Vector3(CubeRoot(number), 0f, number), new Vector3(CubeRoot(number), 0f, 0f), Color.green);
        }
        else
        {
            // Calculating evaluation for the analyzed number
            evaluation = (a * Mathf.Pow(number, 3)) + (b * Mathf.Pow(number, 2)) + (c * number) + d;

            // Visualising analyzed number value on Y axis
            if (number >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
            else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.red);

            // Visualising analyzed number value on X axis
            if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(-0.5f, 0f, evaluation), Color.blue);
            else Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(0.5f, 0f, evaluation), Color.blue);

            // Rendering lines that point evaluation on the graph
            Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, evaluation), Color.green);
            Debug.DrawLine(new Vector3(number, 0f, evaluation), new Vector3(0f, 0f, evaluation), Color.green);
        }
    }

    private void Show_Axis()
    {
        if (show_axis)
        {
            // Plotting X and Y axis
            Debug.DrawLine(new Vector3(-(limit * limit * limit), 0, 0), new Vector3(limit * limit * limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -(limit * limit * limit)), new Vector3(0, 0, limit * limit * limit));
        }
    }
}
