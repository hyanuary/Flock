using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour {

    public GameObject block;
    public float movementSpeed = 10.0f;

    public GameObject[] points;
    Vector3 StartPositions;
    Vector3 currPos;
    public float movementTime;

    double sCurve(double x)
    {
        double y = x * x * (3.0 - 2.0 * x);
        return y;
    }

    float eCurves (float x)
    {
        float y = Mathf.Log(x, x+5);
        return y;
    }

    // Use this for initialization
    void Start()
    {
        StartPositions = block.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 oldpos = points[0].transform.position;
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector3 start = points[i].transform.position;
            Vector3 end = points[i + 1].transform.position;
            for (float j = 0; j <= 1.0; j += 0.01f)
            {
                Vector3 current = new Vector3();
                current.x = Mathf.Lerp(start.x, end.x, j);
                current.z = Mathf.Lerp(start.z, end.z, (float)eCurves(j));

                Debug.DrawLine(oldpos, current, Color.white);
                oldpos = current;
            }

        }





    }
}

