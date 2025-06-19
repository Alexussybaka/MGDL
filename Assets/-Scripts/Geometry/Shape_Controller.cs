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

    // Note that this script is still in development,
    // so some features of this code might not work properly.

    private void Update()
    {
        // Drawing the shape
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        // Connecting first and last vertex in order to make a loop
        if (bridge_ends) Debug.DrawLine(new Vector3(vertexes[0].x, 0f, vertexes[0].y), new Vector3(vertexes[vertexes.Count - 1].x, 0f, vertexes[vertexes.Count - 1].y));

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

        area = CalculateArea();
        perimeter = CalculatePerimeter();
    }

    // Using "Shoelace" formula to calculate area of not self-intersecting shape.
    public float CalculateArea()
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

    // Calculating perimeter of a shape
    public float CalculatePerimeter()
    {
        float perimeter = 0f;

        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            perimeter += Vector2.Distance(vertexes[i], vertexes[i + 1]);
        }

        return perimeter;
    }
}
