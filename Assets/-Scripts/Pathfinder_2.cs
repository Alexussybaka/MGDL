using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_2 : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private int x_coordinates;
    [SerializeField] private int y_coordinates;
    [SerializeField] private float period;

    private float elapsed_time;

    private void Update()
    {
        //Drawing target coordinates
        Debug.DrawLine(new Vector3(x_coordinates - 1, 0f, y_coordinates), new Vector3(x_coordinates + 1, 0f, y_coordinates));
        Debug.DrawLine(new Vector3(x_coordinates, 0f, y_coordinates - 1), new Vector3(x_coordinates, 0f, y_coordinates + 1));

        //Making move each time elapsed time variable hits period timing
        elapsed_time += Time.deltaTime;
        if (elapsed_time > period)
        {
            MakeMove();
            elapsed_time = 0;
        }
    }
    public void MakeMove()
    {
        if (!(Vector3.Distance(transform.position, new Vector3(x_coordinates, 0f, y_coordinates)) <= 2f))
        {
            if(transform.position.x < x_coordinates)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                transform.position += transform.forward;
            }
            if(transform.position.x > x_coordinates)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                transform.position += transform.forward;
            }
            if(transform.position.z < y_coordinates)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position += transform.forward;
            }
            if(transform.position.z > y_coordinates)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                transform.position += transform.forward;
            }
        }
        
    }
}
