using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_2 : MonoBehaviour
{
    [SerializeField] private int x_coordinates;
    [SerializeField] private int y_coordinates;

    private float elapsed_time;
    [SerializeField] private float period;

    private void Update()
    {
        //Drawing target coordinates
        Debug.DrawLine(new Vector3(x_coordinates, 0f, 0f), new Vector3(-x_coordinates, 0f, 0f));
        Debug.DrawLine(new Vector3(0f, 0f, -y_coordinates), new Vector3(-0f, 0f, y_coordinates));

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
            if(transform.position.x > x_coordinates)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                transform.position += transform.forward;
            }
        }
        
    }
}
