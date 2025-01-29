using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Controller : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] List<Vector2> vertexes;
    [SerializeField] bool bridge_ends;
    [SerializeField] bool fill;

    [Space]
    [Header("Other Info : Read Only")]
    [SerializeField] float area;
    [SerializeField] float perimeter;

    private void Update()
    {
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        if (bridge_ends) Debug.DrawLine(vertexes[0], vertexes[vertexes.Count - 1]);

        if (fill)
        {
            for (int i = 0; i < vertexes.Count; i++)
            {
                for (int j = 0; j < vertexes.Count; j++)
                {
                    Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[j].x, 0f, vertexes[j].y));
                }
            }
        }

        area = calculating_area();
    }

    public float calculating_area()
    {
        int n = vertexes.Count;
        if (n < 3) return 0; 

        float area = 0;

        for (int i = 0; i < n; i++)
        {
            Vector2 current = vertexes[i];
            Vector2 next = vertexes[(i + 1) % n]; 
            area += (current.x * next.y) - (next.x * current.y);
        }

        return Mathf.Abs(area) * 0.5f;
    }
}
