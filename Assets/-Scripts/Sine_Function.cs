using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine_Function : MonoBehaviour
{
    [Range(1, 360)]
    [SerializeField] int subdivision_count;
    [SerializeField] float radius;

    public List<Vector2> posititons;

    private void Update()
    {
        float angle = 360 / subdivision_count;

        float circuit = (2 * Mathf.PI) * radius;

        float step = circuit / subdivision_count;

        for (int i = 0; i < subdivision_count; i++)
        {
            posititons.Add(new Vector2(i * step, Mathf.Sin(angle*i*Mathf.Deg2Rad)));
        }

        for (int i = 0; i < posititons.Count - 1; i++)
        {
            Debug.DrawLine(posititons[i], posititons[i + 1]);
        }

        posititons.Clear();
    }
}
