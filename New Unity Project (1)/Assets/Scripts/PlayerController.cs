using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Author:[Isabella Stacy]
//Date[02/21/2022]
//Description[Get Ufo to collect the items]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "Winner!";
        }
    }
    //I see that there is an error in line 43 but i am not sure as to why it's doing that but the player moves and picks up the items.
    //also couldn't figure out why the text/counting isnt working


}
