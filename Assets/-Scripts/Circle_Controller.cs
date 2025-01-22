using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
    


    [SerializeField] int subdivisions_count;
    [SerializeField] float radius;
    [SerializeField] Vector3 center;
    
    
    [SerializeField] float area;

    private void Update()
    {
        float angle = 360 / subdivisions_count;

        for (int i = 1; i < subdivisions_count+1; i++)
        {

        }
    }
}
