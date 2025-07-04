using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triangle_Fractal : MonoBehaviour
{
    [SerializeField] int stage;
    [SerializeField] float size;

    private void Update()
    {
        float basic_triangle_length = size / Mathf.Pow(2, stage - 1);
        float basic_triangle_height = Mathf.Sin(Mathf.PI / 3) * basic_triangle_length;

        for (int i = 0; i < Mathf.Pow(2, stage - 1); i++)
        {
            Debug.DrawLine(new Vector3(i * basic_triangle_length, 0, 0), new Vector3((i + 1) * basic_triangle_length, 0, 0));
            
        }
    }
}
