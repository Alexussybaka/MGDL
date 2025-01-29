using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_3 : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private List<Coordinate> coordinates;
    [SerializeField] private int current_destination = 0;
    [SerializeField] private float period;
    
    private float elapsed_time;

    private void Update()
    {
        foreach (var c in coordinates)
        {
            Debug.DrawLine(new Vector3(c.coordinate.x - 1, 0f, c.coordinate.y), new Vector3(c.coordinate.x + 1, 0f, c.coordinate.y));
            Debug.DrawLine(new Vector3(c.coordinate.x, 0f, c.coordinate.y - 1), new Vector3(c.coordinate.x, 0f, c.coordinate.y + 1));
        }

        elapsed_time += Time.deltaTime;
        if (elapsed_time > period)
        {
            MakeMove();
            elapsed_time = 0;
        }
    }
    public void MakeMove()
    {
        if (Vector3.Distance(transform.position, new Vector3(coordinates[current_destination].coordinate.x, 0f, coordinates[current_destination].coordinate.x)) > 0.1f)
        {
            if (transform.position.x < coordinates[current_destination].coordinate.x)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.x > coordinates[current_destination].coordinate.x)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.z < coordinates[current_destination].coordinate.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.z > coordinates[current_destination].coordinate.y)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                transform.position += transform.forward;
            }
        }
        else
        {
            if(current_destination < coordinates.Count - 1)
            {
                current_destination++;
            }
        }

    }
}

[System.Serializable]
public class Coordinate
{
    public Vector2 coordinate;
}
