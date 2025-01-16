using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_1 : MonoBehaviour
{
    private int x_border;
    private int y_border;

    private RaycastHit hit;

    [SerializeField] private Transform head_pos;
    [SerializeField] private float ray_distance;

    private void Update()
    {
        Debug.DrawRay(head_pos.position, head_pos.forward);

        Ray ray = new Ray(head_pos.position, head_pos.forward);
        if (Physics.Raycast(ray, out hit, ray_distance))
        {
            DetectetObject();
        }
    }

    public void DetectetObject()
    {

    }

    public void MakeMove()
    {
        if(transform.position.x == x_border || transform.position.x == -x_border)
        {

        } 
        if(transform.position.z == y_border || transform.position.z == -y_border)
        {

        }
    }
}
