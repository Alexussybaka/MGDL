using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic_Function : MonoBehaviour
{
    [Header("Graph Settings")]
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
        // Created all negative points to draw line using them.
        for (float i = -limit; i < 0; i += resolution)
        {
            if (horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, 3)));
            else vectors.Add(new Vector3(Mathf.Pow(i, 3), 0f, i));
        }

        // Created all positive points to draw line using them.
        for (float i = 0; i < limit; i += resolution)
        {
            if (horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, 3)));
            else vectors.Add(new Vector3(Mathf.Pow(i, 3), 0f, i));
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
        if (horizontal)
        {
            if (is_cubed)
            {
                // Visualising analyzed number value on Y axis
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
                else Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(0.5f, 0f, number), Color.red);

                // Visualising analyzed number value on X axis
                if (number >= 0) Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, -0.5f), Color.blue);
                else Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, 0.5f), Color.blue);

                // Rendering lines that point evaluation on the graph
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(CubeRoot(number), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(CubeRoot(number), 0f, number), new Vector3(CubeRoot(number), 0f, 0f), Color.green);

                // Calculating evaluation for the analyzed number
                evaluation = CubeRoot(number);
            }
            else
            {
                // Visualising analyzed number value on Y axis
                if (number >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.red);

                // Visualising analyzed number value on X axis
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, Mathf.Pow(number, 3)), new Vector3(-0.5f, 0f, Mathf.Pow(number, 3)), Color.blue);
                else Debug.DrawLine(new Vector3(0f, 0f, Mathf.Pow(number, 3)), new Vector3(0.5f, 0f, Mathf.Pow(number, 3)), Color.blue);

                // Rendering lines that point evaluation on the graph
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, Mathf.Pow(number, 3)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, Mathf.Pow(number, 3)), new Vector3(0f, 0f, Mathf.Pow(number, 3)), Color.green);

                // Calculating evaluation for the analyzed number
                evaluation = Mathf.Pow(number, 3);
            }
        }
        else
        {
            if (is_cubed)
            {
                // Visualising analyzed number value on Y axis
                if (number >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.red);

                // Visualising analyzed number value on X axis
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, CubeRoot(number)), new Vector3(-0.5f, 0f, CubeRoot(number)), Color.blue);
                else Debug.DrawLine(new Vector3(0f, 0f, CubeRoot(number)), new Vector3(0.5f, 0f, CubeRoot(number)), Color.blue);

                // Rendering lines that point evaluation on the graph
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, CubeRoot(number)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, CubeRoot(number)), new Vector3(0f, 0f, CubeRoot(number)), Color.green);

                // Calculating evaluation for the analyzed number
                evaluation = CubeRoot(number);
            }
            else
            {
                // Visualising analyzed number value on Y axis
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
                else Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(0.5f, 0f, number), Color.red);

                // Visualising analyzed number value on X axis
                if (number >= 0) Debug.DrawLine(new Vector3(Mathf.Pow(number, 3), 0f, 0f), new Vector3(Mathf.Pow(number, 3), 0f, -0.5f), Color.blue);
                else Debug.DrawLine(new Vector3(Mathf.Pow(number, 3), 0f, 0f), new Vector3(Mathf.Pow(number, 3), 0f, 0.5f), Color.blue);

                // Rendering lines that point evaluation on the graph
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Pow(number, 3), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Pow(number, 3), 0f, number), new Vector3(Mathf.Pow(number, 3), 0f, 0f), Color.green);

                // Calculating evaluation for the analyzed number
                evaluation = Mathf.Pow(number, 3);
            }
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
