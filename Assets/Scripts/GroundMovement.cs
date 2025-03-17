using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour {

    public AnimationCurve movement;
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update () {
        float temp = movement.Evaluate(0.05f * Time.time);
        //Debug.Log(temp);
        Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y, temp, 1);
        transform.rotation = rot;
	}
}
