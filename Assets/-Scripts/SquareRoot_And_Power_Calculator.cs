using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRoot_And_Power_Calculator : MonoBehaviour
{
    [Header("Graph Settings")]
    [SerializeField] bool horizontal;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;
    [SerializeField] int power;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool is_power;
    [Space]
    [SerializeField] float evaluation;


    private List<Vector3> vectors = new List<Vector3>();

    public void Update()
    {
        // Added initial [0; 0; 0] vector.
        vectors.Add(Vector3.zero);
        
        // Created the rest of vectors to draw line using them.
        for (float i = 0; i < limit; i += resolution)
        {
            if(horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, power)));
            else vectors.Add(new Vector3(Mathf.Pow(i, power), 0f, i));
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
                Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, 0f), new Vector3(Mathf.Sqrt(number), 0f, -0.5f), Color.blue);

                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Sqrt(number), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Sqrt(number), 0f, number), new Vector3(Mathf.Sqrt(number), 0f, 0f), Color.green);

                evaluation = Mathf.Sqrt(number);
            }
            else
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                Debug.DrawLine(new Vector3(0f, 0f, Mathf.Pow(number, power)), new Vector3(-0.5f, 0f, Mathf.Pow(number, power)), Color.blue);

                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, Mathf.Pow(number, power)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, Mathf.Pow(number, power)), new Vector3(0f, 0f, Mathf.Pow(number, power)), Color.green);

                evaluation = Mathf.Pow(number, power);
            }
        }
        else
        {
            if (is_power)
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
                Debug.DrawLine(new Vector3(0f, 0f, Mathf.Sqrt(number)), new Vector3(-0.5f, 0f, Mathf.Sqrt(number)), Color.blue);

                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, Mathf.Sqrt(number)), Color.green);
                Debug.DrawLine(new Vector3(number, 0f, Mathf.Sqrt(number)), new Vector3(0f, 0f, Mathf.Sqrt(number)), Color.green);

                evaluation = Mathf.Sqrt(number);
            }
            else
            {
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
                Debug.DrawLine(new Vector3(Mathf.Pow(number, power), 0f, 0f), new Vector3(Mathf.Pow(number, power), 0f, -0.5f), Color.blue);

                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(Mathf.Pow(number, power), 0f, number), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Pow(number, power), 0f, number), new Vector3(Mathf.Pow(number, power), 0f, 0f), Color.green);

                evaluation = Mathf.Pow(number, power);
            }
        }
    }
}
