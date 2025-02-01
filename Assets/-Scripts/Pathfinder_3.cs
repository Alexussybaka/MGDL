using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_3 : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private List<Vector2> coordinates;
    [SerializeField] private bool create_random_points;
    [Space]
    [SerializeField] private int current_destination = 0;
    [SerializeField] private float period;

    private float elapsed_time;

    private void Start()
    {
        if (create_random_points)
        {
            for (int i = 0; i < 20; i++)
            {
                coordinates.Add(new Vector2(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-20, 20)));
            }
        }
    }

    private void Update()
    {
        foreach (Vector2 coordinate in coordinates)
        {
            Debug.DrawLine(new Vector3(coordinate.x - 1, 0f, coordinate.y), new Vector3(coordinate.x + 1, 0f, coordinate.y));
            Debug.DrawLine(new Vector3(coordinate.x, 0f, coordinate.y - 1), new Vector3(coordinate.x, 0f, coordinate.y + 1));
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
        if (Vector3.Distance(transform.position, new Vector3(coordinates[current_destination].x, 0f, coordinates[current_destination].y)) > 1f)
        {
            if (transform.position.x < coordinates[current_destination].x)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.x > coordinates[current_destination].x)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.z < coordinates[current_destination].y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position += transform.forward;
            }
            if (transform.position.z > coordinates[current_destination].y)
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