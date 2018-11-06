using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private Text countText;

    [SerializeField]
    private Text winText;


    private Rigidbody2D rb2d;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    private void SetCountText()
    {
       countText.text = "Count: " + count.ToString();
      if (count >= 12)
      { 
       
          winText.text = "You Win!";
      }
    }
}
