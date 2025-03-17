using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float jumpHieght;
    Rigidbody2D rb;
    public Animator anim;
    bool isOnGround = true;
    private BoxCollider2D headCollider;

    public float minSwipeDistance;
    Vector2 startSwipe;
    Vector2 endSwipe;

    public Text text;
    public string level;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        headCollider = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
        GlobalVar.score += 1;
        if(GlobalVar.score > GlobalVar.highScore)
        {
            GlobalVar.highScore = GlobalVar.score;
        }
        text.text = "Score: " + GlobalVar.score;
        if (Input.GetMouseButtonDown(0))
        {
            startSwipe = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButtonUp(0))
        {
            endSwipe = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(endSwipe.y - startSwipe.y > minSwipeDistance && isOnGround)
            {
                isOnGround = false;
                rb.AddForce(Vector2.up * jumpHieght, ForceMode2D.Impulse);
                anim.SetBool("Jumping", true);
                Invoke("ResetBooleans", .2f);
            }
            else if (endSwipe.y - startSwipe.y < -minSwipeDistance && isOnGround)
            {
                anim.SetBool("Sliding", true);
                headCollider.enabled = false;
                //Invoke("ResetBooleans", .2f);
            }
        }
	}

    void ResetBooleans()
    {
        anim.SetBool("Jumping", false);
        anim.SetBool("Sliding", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "slidingPlatform" || other.gameObject.tag == "Snowman")
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "slidingPlatform")
        {
            ResetBooleans();
            headCollider.enabled = true;
        }
    }
}
