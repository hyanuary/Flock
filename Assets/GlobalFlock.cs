﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject prefabs;
    public GameObject goalPrefabs;
    public static int tankSize = 10;

    static int numBoids = 50;
    public static GameObject[] allBoid = new GameObject[numBoids];

    public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < numBoids; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                    Random.Range(-tankSize, tankSize),
                    Random.Range(-tankSize, tankSize));

            allBoid[i] = (GameObject)Instantiate(prefabs, pos, Quaternion.identity);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0,10000)<50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                    Random.Range(-tankSize, tankSize),
                    Random.Range(-tankSize, tankSize));

            goalPrefabs.transform.position = goalPos;
        }
	}
}
