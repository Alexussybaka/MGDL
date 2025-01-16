using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_1 : MonoBehaviour
{
    [SerializeField] private int possible_outcomes;

    [SerializeField] private int x_border;
    [SerializeField] private int y_border;

    private RaycastHit hit;

    [SerializeField] private Transform head_pos;
    [SerializeField] private float ray_distance;

    private void Update()
    {
        Debug.DrawLine(head_pos.position, head_pos.forward);

        //Drawing our x border
        Debug.DrawLine(new Vector3(x_border, 0f, -y_border), new Vector3(x_border, 0f, y_border));
        Debug.DrawLine(new Vector3(-x_border, 0f, -y_border), new Vector3(-x_border, 0f, y_border));

        //Drawing our y border
        Debug.DrawLine(new Vector3(-x_border, 0f, y_border), new Vector3(x_border, 0f, y_border));
        Debug.DrawLine(new Vector3(-x_border, 0f, -y_border), new Vector3(x_border, 0f, -y_border));

        //Ray instancing
        Ray ray = new Ray(head_pos.position, head_pos.forward);
        if (Physics.Raycast(ray, out hit, ray_distance))
        {
            DetectetObject();
        }

        possible_outcomes = (x_border * y_border) * 4;
    }

    public void DetectetObject()
    {

    }

    public void MakeMove()
    {
        if(transform.position.x == x_border)
        {
            transform.rotation = Quaternion.Euler(0f, -180, 0f);
            transform.position += new Vector3(-1f, 0f, 0f);
        } 
        else if(transform.position.x == -x_border)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
            transform.position += new Vector3(1f, 0f, 0f);
        }
        else if(transform.position.z == y_border)
        {
            transform.rotation = Quaternion.Euler(0f, -90, 0f);
            transform.position += new Vector3(-1f, 0f, 0f);
        }
        else if(transform.position.z == -y_border)
        {
            transform.rotation = Quaternion.Euler(0f, 90, 0f);
            transform.position += new Vector3(-1f, 0f, 0f);
        }
        else
        {
            int random_rotation = Random.Range(0, 4) * 90;
            transform.rotation = Quaternion.Euler(0f, random_rotation, 0f);
            //transform.position = transform.forward += 1;
        }
    }
}
