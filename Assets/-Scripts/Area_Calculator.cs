using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Calculator : MonoBehaviour
{
    [SerializeField] private float perimeter;
    [SerializeField] private float x;

    private void Update()
    {
        Debug.Log(CalculateArea(perimeter, x));
        Debug.Log(CalculateBiggestArea(perimeter));
    }

    // This function will return a highest possible area in a rectangle with static perimeter.
    public float CalculateBiggestArea(float perimeter)
    {
        //Drawing our x border
        Debug.DrawLine(new Vector3(0f, 0f, 0f),  new Vector3(perimeter/2, 0f, 0f));
        Debug.DrawLine(new Vector3(0f, 0f, perimeter - (perimeter / 2)), new Vector3(perimeter/2, 0f, perimeter - (perimeter / 2)));

        //Drawing our y border
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, perimeter - (perimeter / 2)));
        Debug.DrawLine(new Vector3(perimeter/2, 0f, 0f), new Vector3(perimeter/2, 0f, perimeter - (perimeter / 2)));

        return (perimeter - (perimeter/2)) * (perimeter/2); 
    }

    // This function will return a  area in a rectangle according to x value.
    public float CalculateArea(float perimeter, float x)
    {
        //Drawing our x border
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(x, 0f, 0f));
        Debug.DrawLine(new Vector3(0f, 0f, perimeter - x), new Vector3(x, 0f, perimeter - x));

        //Drawing our y border
        Debug.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, perimeter - x));
        Debug.DrawLine(new Vector3(x, 0f, 0f), new Vector3(x, 0f, perimeter - x));

        return (perimeter - x) * x;
    }

}
