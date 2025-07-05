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
        float basic_triangle_offset = Mathf.Cos(Mathf.PI / 3) * basic_triangle_length;
        
        for (int j = 0; j < Mathf.Pow(2, stage - 1); j++)
        {
            for (int i = 0; i < (Mathf.Pow(2, stage - 1) - j); i++)
            {
                Debug.DrawLine(
                    new Vector3(i * basic_triangle_length + j * basic_triangle_offset, 0, j * basic_triangle_height), 
                    new Vector3((i + 1) * basic_triangle_length + j * basic_triangle_offset, 0, j * basic_triangle_height));
                
                Debug.DrawLine(
                    new Vector3(i * basic_triangle_length + j * basic_triangle_offset, 0, j * basic_triangle_height), 
                    new Vector3((i * basic_triangle_length) + (basic_triangle_length / 2) + j * basic_triangle_offset, 0, (j + 1) * basic_triangle_height));
                
                Debug.DrawLine(
                    new Vector3((i + 1) * basic_triangle_length + j * basic_triangle_offset, 0, j * basic_triangle_height), 
                    new Vector3((i * basic_triangle_length) + (basic_triangle_length / 2) + j * basic_triangle_offset, 0, (j + 1) * basic_triangle_height));
            }
        }
    }
}
