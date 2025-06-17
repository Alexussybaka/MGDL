using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid_Controller : MonoBehaviour
{
    [Header("Pyramid Settings")]
    [SerializeField] float height;
    [SerializeField] float width;
    [SerializeField] int stairs_count;

    private void Update()
    {
        //Draw initial square
        Debug.DrawLine(new Vector3(width / 2, 0, width / 2), new Vector3(width / 2, 0, -width / 2));
        Debug.DrawLine(new Vector3(width / 2, 0, -width / 2), new Vector3(-width / 2, 0, -width / 2));
        Debug.DrawLine(new Vector3(-width / 2, 0, -width / 2), new Vector3(-width / 2, 0, width / 2));
        Debug.DrawLine(new Vector3(-width / 2, 0, width / 2), new Vector3(width / 2, 0, width / 2));

        //
        float step_height = (height / 2) / stairs_count;
        float width_step = (width / 2) / stairs_count;

        for (int i = 0; i < stairs_count; ++i)
        {
            Debug.DrawLine(new Vector3(width / 2 - width_step * i, step_height * i, width / 2 - width_step * i), new Vector3(width / 2 - width_step * i, step_height * i, -width / 2 + width_step * i));
            Debug.DrawLine(new Vector3(width / 2 - width_step * i, step_height * i, -width / 2 + width_step * i), new Vector3(-width / 2 + width_step * i, step_height * i, -width / 2 + width_step * i));
            Debug.DrawLine(new Vector3(-width / 2 + width_step * i, step_height * i, -width / 2 + width_step * i), new Vector3(-width / 2 + width_step * i, step_height * i, width / 2 - width_step * i));
            Debug.DrawLine(new Vector3(-width / 2 + width_step * i, step_height * i, width / 2 - width_step * i), new Vector3(width / 2 - width_step * i, step_height * i, width / 2 - width_step * i));
        }
    }
}
