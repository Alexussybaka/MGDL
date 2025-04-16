using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Point_Symetry : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private List<Vector2> vertexes;

    private void Update()
    {
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3((2* point.position.x) - vertexes[i].x, 0f, (2 * point.position.y) - vertexes[i].y), new Vector3((2 * point.position.x) - vertexes[i+1].x, 0f, (2 * point.position.y) - vertexes[i+1].y));
        }
    }
}
