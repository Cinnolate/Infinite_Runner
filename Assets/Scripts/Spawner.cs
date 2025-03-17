using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacle;
    public Transform parent;
    public float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 1 * Time.deltaTime;
        if(timer < 0)
        {
            int r = Random.Range(0, obstacle.Length);
            GameObject newSnowman = Instantiate(obstacle[r], transform.position, transform.rotation) as GameObject;
            newSnowman.transform.parent = parent;
            float random = Random.value * 3;
            if (random < 1)
                random = 1;
            timer = random;
        }
	}
}
