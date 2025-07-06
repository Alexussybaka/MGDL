using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid_Controller : MonoBehaviour
{
    [Header("Pyramid Settings")]
    [SerializeField] Vector3 pyramid_position;
    [SerializeField] float height;
    [SerializeField] float width;
    [Range(0, 100)]
    [SerializeField] int stairs_count;

    private void Update()
    {
        // Draw initial square
        Debug.DrawLine(
            new Vector3(width / 2 + pyramid_position.x, 0 + pyramid_position.y, width / 2 + pyramid_position.z), 
            new Vector3(width / 2 + pyramid_position.x, 0 + pyramid_position.y, -width / 2 + pyramid_position.z));

        Debug.DrawLine(
            new Vector3(width / 2 + pyramid_position.x, 0 + pyramid_position.y, -width / 2 + pyramid_position.z), 
            new Vector3(-width / 2 + pyramid_position.x, 0 + pyramid_position.y, -width / 2 + pyramid_position.z));
        
        Debug.DrawLine(
            new Vector3(-width / 2 + pyramid_position.x, 0 + pyramid_position.y, -width / 2 + pyramid_position.z), 
            new Vector3(-width / 2 + pyramid_position.x, 0 + pyramid_position.y, width / 2 + pyramid_position.z));
        
        Debug.DrawLine(
            new Vector3(-width / 2 + pyramid_position.x, 0 + pyramid_position.y, width / 2 + pyramid_position.z), 
            new Vector3(width / 2 + pyramid_position.x, 0 + pyramid_position.y, width / 2 + pyramid_position.z));

        // Defining local variables
        float step_height = (height / 2) / stairs_count;
        float width_step = (width / 2) / stairs_count;

        for (int i = 0; i < stairs_count; ++i)
        {
            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z), 
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z), 
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z), 
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z), 
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z));

            //

            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z), 
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * (i + 1) + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z), 
                new Vector3(width / 2 - width_step * i + pyramid_position.x, step_height * (i + 1) + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z), 
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * (i + 1) + pyramid_position.y, -width / 2 + width_step * i + pyramid_position.z));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * i + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z), 
                new Vector3(-width / 2 + width_step * i + pyramid_position.x, step_height * (i + 1) + pyramid_position.y, width / 2 - width_step * i + pyramid_position.z));
            
            //

            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i, step_height * (i + 1), width / 2 - width_step * i), 
                new Vector3(width / 2 - width_step * (i + 1), step_height * (i + 1), width / 2 - width_step * (i + 1)));
            
            Debug.DrawLine(
                new Vector3(width / 2 - width_step * i, step_height * (i + 1), -width / 2 + width_step * i), 
                new Vector3(width / 2 - width_step * (i + 1), step_height * (i + 1), -width / 2 + width_step * (i + 1)));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i, step_height * (i + 1), -width / 2 + width_step * i), 
                new Vector3(-width / 2 + width_step * (i + 1), step_height * (i + 1), -width / 2 + width_step * (i + 1)));
            
            Debug.DrawLine(
                new Vector3(-width / 2 + width_step * i, step_height * (i + 1), width / 2 - width_step * i), 
                new Vector3(-width / 2 + width_step * (i + 1), step_height * (i + 1), width / 2 - width_step * (i + 1)));
        }

        for (int j = 1; j < stairs_count + 1; j++)
        {
            Debug.DrawLine(new Vector3(width / 2 - width_step * (j - 1), step_height * j, width / 2 - width_step * (j - 1)), new Vector3(width / 2 - width_step * (j - 1), step_height * j, -width / 2 + width_step * (j - 1)));
            Debug.DrawLine(new Vector3(width / 2 - width_step * (j - 1), step_height * j, -width / 2 + width_step * (j - 1)), new Vector3(-width / 2 + width_step * (j - 1), step_height * j, -width / 2 + width_step * (j - 1)));
            Debug.DrawLine(new Vector3(-width / 2 + width_step * (j - 1), step_height * j, -width / 2 + width_step * (j - 1)), new Vector3(-width / 2 + width_step * (j - 1), step_height * j, width / 2 - width_step * (j - 1)));
            Debug.DrawLine(new Vector3(-width / 2 + width_step * (j - 1), step_height * j, width / 2 - width_step * (j - 1)), new Vector3(width / 2 - width_step * (j - 1), step_height * j, width / 2 - width_step * (j - 1)));
        }
    }
}
