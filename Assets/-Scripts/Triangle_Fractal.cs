using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triangle_Fractal : MonoBehaviour
{
    [SerializeField] int stage;
    [SerializeField] float scale;

    private void Update()
    {
        int function_cycle = stage;

        Vector3 high_point = new Vector3(0f, 0f, Mathf.Sqrt(Mathf.Pow(scale, 2) - Mathf.Pow(scale / 2, 2)));
        //Vector3 left_pivot = new Vector3(scale / 2, 0f, Mathf.Sqrt(Mathf.Pow(scale, 2) - Mathf.Pow(scale / 2, 2)));
        Vector3 high_pivot = new Vector3(scale / 2, 0f, high_point.z);

        Debug.DrawLine(new Vector3(-(scale / 2), 0f, 0f), new Vector3(scale / 2, 0f, 0f));
        Debug.DrawLine(new Vector3(-(scale / 2), 0f, 0f), high_point);
        Debug.DrawLine(new Vector3(scale / 2, 0f, 0f), high_point);

        Fractal_Construction(high_pivot, function_cycle);

        //for (int i = 1; i <= stage; i++)
        //{
        //    float mid_x = left_pivot.x / Mathf.Pow(2, i);
        //    float mid_z = left_pivot.z / Mathf.Pow(2, i);

        //    Debug.DrawLine(new Vector3(mid_x, 0f, mid_z), new Vector3(-mid_x, 0f, mid_z));
        //}
    }

    private void Fractal_Construction(Vector3 high_pivot, int function_cycle)
    {
        Debug.DrawLine(new Vector3(high_pivot.x / 2, 0f, high_pivot.z / 2), new Vector3(-high_pivot.x / 2, 0f, high_pivot.z / 2));
        Debug.DrawLine(new Vector3(high_pivot.x / 2, 0f, high_pivot.z/ 2), new Vector3(scale - scale / Mathf.Pow(2, stage), 0f, 0f));
        Debug.DrawLine(new Vector3(-high_pivot.x / 2, 0f, high_pivot.z/ 2), new Vector3(scale - scale / Mathf.Pow(2, stage), 0f, 0f));

        //high_pivot = new Vector3(scale / 2, 0f, scale / Mathf.Pow(2, stage - function_cycle));
        high_pivot = new Vector3(scale / 2, 0f, high_pivot.z / 2);

        if (function_cycle > 0) Fractal_Construction(high_pivot, function_cycle - 1);
    }
}
