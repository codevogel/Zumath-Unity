using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBall : MonoBehaviour
{

    private int value;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMesh>().text = formatValue();
    }

    private string formatValue()
    {
        if (value < 10)
        {
            return " "+ value;
        }
        return value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<TextMesh>().text = formatValue();
        if (Time.frameCount % 30 == 0)
        {
            value++;
        }
    }
}
