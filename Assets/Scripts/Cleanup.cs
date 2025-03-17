using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snowman" || other.tag == "slidingPlatform")
            Destroy(other.gameObject);
    }
}
