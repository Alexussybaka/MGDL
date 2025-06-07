using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incircle_And_Circumcircle : MonoBehaviour
{
    [SerializeField] Vector2 A;
    [SerializeField] Vector2 B;
    [SerializeField] Vector2 C;
    
    [SerializeField] Vector3 in_center;
    [SerializeField] float in_radius;
    
    [SerializeField] Vector3 ci_center;
    [SerializeField] float ci_radius;

    private void Update()
    {
        //Drawing the triangle
        Debug.DrawLine(new Vector3(A.x, 0f, A.y), new Vector3(B.x, 0f, B.y));
        Debug.DrawLine(new Vector3(A.x, 0f, A.y), new Vector3(C.x, 0f, C.y));
        Debug.DrawLine(new Vector3(C.x, 0f, C.y), new Vector3(B.x, 0f, B.y));

        Debug.DrawLine(new Vector3(A.x, 0f, A.y), new Vector3((B.x + C.x) / 2, 0f, (B.y + C.y) / 2));
        Debug.DrawLine(new Vector3(B.x, 0f, B.y), new Vector3((A.x + C.x) / 2, 0f, (A.y + C.y) / 2));
        Debug.DrawLine(new Vector3(C.x, 0f, C.y), new Vector3((B.x + A.x) / 2, 0f, (B.y + A.y) / 2));
    }
}
