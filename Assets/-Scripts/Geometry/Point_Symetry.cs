using System.Collections.Generic;
using UnityEngine;

public class Point_Symetry : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform point;
    [SerializeField] private List<Vector2> vertexes;
    [SerializeField] private bool bridge_shape;

    private void Update()
    {
        //Rendering original shape
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3(vertexes[i].x, 0f, vertexes[i].y), new Vector3(vertexes[i + 1].x, 0f, vertexes[i + 1].y));
        }

        //Rendering symetric shape using: new vector = 2 * symetric point - original
        for (int i = 0; i < vertexes.Count - 1; i++)
        {
            Debug.DrawLine(new Vector3((2 * point.position.x) - vertexes[i].x, 0f, (2 * point.position.z) - vertexes[i].y), new Vector3((2 * point.position.x) - vertexes[i+1].x, 0f, (2 * point.position.z) - vertexes[i+1].y));
        }

        // Connecting first and last vertex in order to make a loop
        if (bridge_shape)
        {
            Debug.DrawLine(new Vector3(vertexes[0].x, 0f, vertexes[0].y), new Vector3(vertexes[vertexes.Count - 1].x, 0f, vertexes[vertexes.Count - 1].y));

            Debug.DrawLine(new Vector3((2 * point.position.x) - vertexes[0].x, 0f, (2 * point.position.z) - vertexes[0].y), new Vector3((2 * point.position.x) - vertexes[vertexes.Count - 1].x, 0f, (2 * point.position.z) - vertexes[vertexes.Count - 1].y));
        }
    }
}
