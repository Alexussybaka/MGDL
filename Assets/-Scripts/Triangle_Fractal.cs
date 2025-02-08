using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_Fractal : MonoBehaviour
{
    [SerializeField] int stage;
    [SerializeField] float scale;

    private void Update()
    {
        Vector3 high_point = new Vector3(0f, 0f, Mathf.Sqrt(Mathf.Pow(scale, 2) - Mathf.Pow(scale / 2, 2)));

        Debug.DrawLine(new Vector3(-(scale / 2), 0f, 0f), new Vector3(scale / 2, 0f, 0f));
        Debug.DrawLine(new Vector3(-(scale / 2), 0f, 0f), high_point);
        Debug.DrawLine(new Vector3(scale / 2, 0f, 0f), high_point);
    }
}
