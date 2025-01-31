using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRoot_And_Power_Calculator : MonoBehaviour
{
    [Header("Graph Settings")]
    [SerializeField] bool horizontal;
    [SerializeField] float limit;
    [SerializeField] float resolution;
    [SerializeField] int power;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [SerializeField] bool is_power;
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


        if (horizontal)
        {
            if (is_power)
            {
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
            }
            else
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
            }
        }
        else
        {
            if (is_power)
            {
                Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.red);
            }
            else
            {
                Debug.DrawLine(new Vector3(0f, 0f, number), new Vector3(-0.5f, 0f, number), Color.red);
            }
        }
    }
}
