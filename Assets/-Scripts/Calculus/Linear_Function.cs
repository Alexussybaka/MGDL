using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = a * x + b")]
    [SerializeField] float a;
    [SerializeField] float b;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private void Update()
    {
        // Calculating this function with it's limit
        Vector3 first = new Vector3(-limit, 0, a * (-limit) + b);
        Vector3 second = new Vector3(limit, 0, a * limit + b);

        // Plotting the function
        Debug.DrawLine(first, second);

        // Additional features
        Visualise_Examined_Number();
        Show_Axis();
    }

    public void Visualise_Examined_Number()
    {
        // Calculating evaluation for the analyzed number
        evaluation = a * number + b;

        // Visualising analyzed number value on Y axis
        if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(-0.5f, 0f, evaluation), Color.red);
        else Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(0.5f, 0f, evaluation), Color.red);

        // Visualising analyzed number value on X axis
        if (evaluation >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.blue);
        else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.blue);

        // Rendering lines that point evaluation on the graph
        Debug.DrawLine(new Vector3(number, 0, 0), new Vector3(number, 0, evaluation), Color.green);
        Debug.DrawLine(new Vector3(0, 0, evaluation), new Vector3(number, 0, evaluation), Color.green); 
    }

    private void Show_Axis()
    {
        if (show_axis)
        {
            // Plotting X and Y axis
            Debug.DrawLine(new Vector3(-limit, 0, 0), new Vector3(limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -limit), new Vector3(0, 0, limit));
        }
    }
}
