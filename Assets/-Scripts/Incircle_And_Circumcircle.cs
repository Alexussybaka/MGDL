using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incircle_And_Circumcircle : MonoBehaviour
{
    [SerializeField] Vector2 A;
    [SerializeField] Vector2 B;
    [SerializeField] Vector2 C;

    [Space]
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

        //Debug.DrawLine(new Vector3(A.x, 0f, A.y), new Vector3((B.x + C.x) / 2, 0f, (B.y + C.y) / 2));
        //Debug.DrawLine(new Vector3(B.x, 0f, B.y), new Vector3((A.x + C.x) / 2, 0f, (A.y + C.y) / 2));
        //Debug.DrawLine(new Vector3(C.x, 0f, C.y), new Vector3((B.x + A.x) / 2, 0f, (B.y + A.y) / 2));


        //Circumcircle : Calculation
        float d = 2 * ((A.x * (B.y - C.y)) + (B.x * (C.y - A.y)) + (C.x * (A.y - B.y)));

        ci_center.x = (1 / d) * ((((A.x * A.x) + (A.y * A.y)) * (B.y - C.y)) + (((B.x * B.x) + (B.y * B.y)) * (C.y - A.y)) + (((C.x * C.x) + (C.y * C.y)) * (A.y - B.y)));
        ci_center.y = (1 / d) * ((((A.x * A.x) + (A.y * A.y)) * (C.x - B.x)) + (((B.x * B.x) + (B.y * B.y)) * (A.x - C.x)) + (((C.x * C.x) + (C.y * C.y)) * (B.x - A.x)));

        ci_radius = Vector3.Distance(ci_center, A);

        //Circumcircle : Rendering

    }
}
