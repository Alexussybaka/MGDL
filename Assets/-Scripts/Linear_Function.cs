using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = a * x + b")]
    [SerializeField] float a;
    [SerializeField] float b;

    [SerializeField] bool show_axis;
    [SerializeField] float limit;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private void Update()
    {
        Vector3 first = new Vector3(-1, 0, -a + b);
        Vector3 second = new Vector3(1, 0, a + b);

        //first *= (limit / 2);
        //second *= (limit / 2);

        Debug.DrawLine(first, second);

        Visualise_Examined_Number();
        Show_Axis();
    }

    public void Visualise_Examined_Number()
    {
        evaluation = a * number + b;

        //if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
        //else Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(0.5f, 0f, number), Color.red);

        //if (number >= 0) Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, -0.5f), Color.blue);
        //else Debug.DrawLine(new Vector3(CubeRoot(number), 0f, 0f), new Vector3(CubeRoot(number), 0f, 0.5f), Color.blue);
        
        Debug.DrawLine(new Vector3(number, 0, 0), new Vector3(number, 0, evaluation), Color.green);
        Debug.DrawLine(new Vector3(0, 0, evaluation), new Vector3(number, 0, evaluation), Color.green);
        
    }

    public void Show_Axis()
    {
        if (show_axis)
        {
            Debug.DrawLine(new Vector3(-limit, 0, 0), new Vector3(limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -limit), new Vector3(0, 0, limit));
        }
    }
}
