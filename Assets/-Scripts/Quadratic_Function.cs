using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadratic_Function : MonoBehaviour
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
    [SerializeField] bool is_power;
    [Space]
    [SerializeField] float evaluation;


    private List<Vector3> vectors = new List<Vector3>();

    public void Update()
    {
        // Created all negative points to draw line using them.
        for (float i = -limit; i < 0; i += resolution)
        {
            if (horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, 2)));
            else vectors.Add(new Vector3(Mathf.Pow(i, 2), 0f, i));
        }

        // Created all positive points to draw line using them.
        for (float i = 0; i < limit; i += resolution)
        {
            if(horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, 2)));
            else vectors.Add(new Vector3(Mathf.Pow(i, 2), 0f, i));
        }
        
        // Drawing all lines
        for (int i = 0; i < vectors.Count - 1; i++)
        {
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        // Reseting the list, so we can change parameter and see it in real time.
        vectors.Clear();

        Visualise_Examined_Number();
        
    }

    public void Visualise_Examined_Number()
    {
        if (horizontal)
        {
            if (is_power)
            {
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
                
                if (number >= 0) Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, 0f), new Vector3(Mathf.Sqrt(number), 0f, -0.5f), Color.blue);
                else Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, 0f), new Vector3(Mathf.Sqrt(number), 0f, 0.5f), Color.blue);

                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Sqrt(number), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, number), new Vector3(Mathf.Sqrt(number), 0f, 0f), Color.green);

                evaluation = Mathf.Sqrt(number);
            }
            else
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, Mathf.Pow(number, 2)), new Vector3(-0.5f, 0f, Mathf.Pow(number, 2)), Color.blue);
                else Debug.DrawLine(new Vector3(0f, 0f, Mathf.Pow(number, 2)), new Vector3(0.5f, 0f, Mathf.Pow(number, 2)), Color.blue);

                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, Mathf.Pow(number, 2)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, Mathf.Pow(number, 2)), new Vector3(0f, 0f, Mathf.Pow(number, 2)), Color.green);

                evaluation = Mathf.Pow(number, 2);
            }
        }
        else
        {
            if (is_power)
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, Mathf.Sqrt(number)), new Vector3(-0.5f, 0f, Mathf.Sqrt(number)), Color.blue);
                else Debug.DrawLine(new Vector3(0f, 0f, Mathf.Sqrt(number)), new Vector3(0.5f, 0f, Mathf.Sqrt(number)), Color.blue);

                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, Mathf.Sqrt(number)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, Mathf.Sqrt(number)), new Vector3(0f, 0f, Mathf.Sqrt(number)), Color.green);

                evaluation = Mathf.Sqrt(number);
            }
            else
            {
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
                if (number >= 0) Debug.DrawLine(new Vector3(Mathf.Pow(number, 2), 0f, 0f), new Vector3(Mathf.Pow(number, 2), 0f, -0.5f), Color.blue);
                else Debug.DrawLine(new Vector3(Mathf.Pow(number, 2), 0f, 0f), new Vector3(Mathf.Pow(number, 2), 0f, 0.5f), Color.blue);

                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Pow(number, 2), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Pow(number, 2), 0f, number), new Vector3(Mathf.Pow(number, 2), 0f, 0f), Color.green);

                evaluation = Mathf.Pow(number, 2);
            }
        }
    }
}
