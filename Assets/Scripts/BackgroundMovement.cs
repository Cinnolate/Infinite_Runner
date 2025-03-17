using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public AnimationCurve movement;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float temp = movement.Evaluate(0.05f * Time.time);
        //Debug.Log(temp);
        Vector2 pos = new Vector2(transform.position.x, temp);
        transform.position = pos;
    }
}
