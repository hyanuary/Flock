using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour {

    public float speed;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    public float neighbourDistance = 10.0f;

    bool turning = false;
    

	// Use this for initialization
	void Start () {

        //randomizing speed of the boids
        speed = Random.Range(1, 10);
	}
	
	// Update is called once per frame
	void Update () {


        // limiting the movement of the boids
        if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else
            turning = false;

        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                rotationSpeed * Time.deltaTime);
        }

        else
        {
            if (Random.Range(0, 5) < 2)
            ApplyRules();
        }

        //moving the boids forward
        transform.Translate(0, 0, Time.deltaTime * speed);
		
	}

    void ApplyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allBoid;

        Vector3 vCenter = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist<= neighbourDistance)
                {
                    vCenter += go.transform.position;
                    groupSize++;

                    if(dist<1.0f)
                    {
                        vAvoid = vAvoid + (this.transform.position = go.transform.position);
                    }

                    FlockMovement flock2 = go.GetComponent<FlockMovement>();
                    gSpeed = gSpeed + flock2.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vCenter = vCenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                    Quaternion.LookRotation(direction), 
                    rotationSpeed * Time.deltaTime);
           
        }
        speed = 10.0f;
    }


}
