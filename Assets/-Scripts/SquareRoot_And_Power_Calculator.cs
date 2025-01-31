using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRoot_And_Power_Calculator : MonoBehaviour
{
    [SerializeField] bool horizontal;
    [SerializeField] float limit;
    [SerializeField] int power;

    private List<Vector3> vectors;

    public void Update()
    {
        // Added initial [0; 0; 0] vector.
        vectors.Add(Vector3.zero);
        
        // Created the rest of vectors to draw line using them.
        for (int i = 0; i < limit; i++)
        {
            if(horizontal) vectors.Add(new Vector3(i, 0f, Mathf.Pow(i, power)));
            else vectors.Add(new Vector3(Mathf.Pow(i, power), 0f, i));
        }


    }
}
