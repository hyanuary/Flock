using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    void constrain_3d_fixed_dist(ref Vector3 pos1, ref Vector3 pos2,
        float desired_dist, float compensate1, float compensate2 )
    {
        Vector3 delta = pos2 - pos1;
        float deltalength = (float)Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z);
        if (deltalength > 0)
        {
            float diff = (deltalength - desired_dist) / deltalength;
            pos1 += delta * compensate1 * diff;
            pos2 -= delta * compensate2 * diff;
           
            
        }
    }
    void constrain_3d_fixed_dist1(ref Vector3 pos2, ref Vector3 pos3,
        float desired_dist, float compensate1, float compensate2)
    {
        Vector3 delta = pos3 - pos2;
        float deltalength = (float)Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z);
        if (deltalength > 0)
        {
            float diff = (deltalength - desired_dist) / deltalength;
            pos2 += delta * compensate1 * diff;
            pos3 -= delta * compensate2 * diff;


        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 p1 = obj1.transform.position;
        Vector3 p2 = obj2.transform.position;
        Vector3 p3 = obj3.transform.position;
        constrain_3d_fixed_dist(ref p1, ref p2,3.0f, 0.5f, 0.5f);
        constrain_3d_fixed_dist1(ref p2, ref p3, 3.0f, 0.5f, 0.5f);
        obj1.transform.position = p1;
        obj2.transform.position = p2;
        obj3.transform.position = p3;

    }
}
