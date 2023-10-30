using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Percentage : MonoBehaviour
{
    private int value;

    public int Rand(int percentage ,out bool flag)
    {
        if (Random.Range(0, 100) <= percentage)
        {
            flag = true;
            value = Random.Range(0, 20);
            Debug.Log("´çÃ·");
        }
        else
        {
            flag = false;
        }

        return value;
    }
}
