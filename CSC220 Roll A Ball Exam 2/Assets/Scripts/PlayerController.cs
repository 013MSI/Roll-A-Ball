using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text pocketText;
    public Text gameOverText;

    private Rigidbody rb;
    private int count;
     
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        pocketText.text = "";
        gameOverText.text = "";
    }
         
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag ("Pocket"))
        {
            // Destroy(other.gameObject);
            gameObject.SetActive(false);
            SetPocketText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 8)
        {
            winText.text = "You Win!";
            gameObject.SetActive(false);
        }
    }

    void SetPocketText ()
    {
        pocketText.text = "You Fell In A Pocket";
        if (gameObject != gameObject.activeInHierarchy)
        {
            gameOverText.text = "Game Over!";
        }
        
    }
}
