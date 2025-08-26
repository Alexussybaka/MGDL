using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadratic_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = ax^2 + bx + c")]
    [SerializeField] float a;
    [SerializeField] float b;
    [SerializeField] float c;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool is_power;
    [Space]
    [SerializeField] float evaluation;


    private List<Vector3> vectors = new List<Vector3>();

    public void Update()
    {
        // Created all negative points to draw line using them.
        for (float i = -limit; i < limit; i += resolution)
        {
            float eval = (a * Mathf.Pow(i, 2)) + (b * i) + c;
            vectors.Add(new Vector3(i, 0f, eval));
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
        

        if (is_power)
        {
            // Calculating evaluation for the analyzed number
            evaluation = Mathf.Sqrt((a * Mathf.Pow(number, 2)) + (b * number) + c);
            
            // Visualising analyzed number value on Y axis
            Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);

            // Visualising analyzed number value on X axis
            if (number >= 0) Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, 0f), new Vector3(Mathf.Sqrt(number), 0f, -0.5f), Color.blue);
            else Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, 0f), new Vector3(Mathf.Sqrt(number), 0f, 0.5f), Color.blue);

            // Rendering lines that point evaluation on the graph
            Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Sqrt(number), 0f, number), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, number), new Vector3(Mathf.Sqrt(number), 0f, 0f), Color.green);
        }
        else
        {
            // Calculating evaluation for the analyzed number
            evaluation = (a * Mathf.Pow(number, 2)) + (b * number) + c;

            // Visualising analyzed number value on Y axis
            Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);

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
            Debug.DrawLine(new Vector3(-(limit * limit), 0, 0), new Vector3(limit * limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -(limit * limit)), new Vector3(0, 0, limit * limit));
        }
    }
}
