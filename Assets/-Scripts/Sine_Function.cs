using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine_Function : MonoBehaviour
{
    [Range(1, 90)]
    [SerializeField] int subdivision_count;
    [SerializeField] float radius;
    [Range(1, 10)]
    [SerializeField] int frequention;

    public List<Vector2> posititons;

    private void Update()
    {
        float angle = 360 / subdivision_count;

        float circuit = (2 * Mathf.PI) * radius;

        float step = circuit / (subdivision_count / frequention);

        for (int f = 0; f < frequention; f++)
        {
            for (int i = 0; i < subdivision_count; i++)
            {
                posititons.Add(new Vector2(i * step, Mathf.Sin((angle * i) * (Mathf.PI / 180f)) * radius));
            }
        }
        
        for (int i = 0; i < posititons.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(posititons[i].x, 0f, posititons[i].y), new Vector3(posititons[i+1].x, 0f, posititons[i+1].y));
        }

        posititons.Clear();
    }
}

