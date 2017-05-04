using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints2 : MonoBehaviour {

    public int numBox = 5;
    public GameObject[] boxes;

    void constrain_3d_fixed_dist(ref Vector3 pos1, ref Vector3 pos2,
       float desired_dist, float compensate1, float compensate2)
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

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < numBox - 1; i++ )
        {
            Vector3 p1 = boxes[i].transform.position;
            Vector3 p2 = boxes[i + 1].transform.position;

            constrain_3d_fixed_dist(ref p1, ref p2, 2.0f, 1.0f, 0.5f);

            boxes[i].transform.position = p1;
            boxes[i + 1].transform.position = p2;
     
        }
		
	}
}
