using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: [Peterson, Jaela]
 * Date: [03/22/2022]
 * [Make a platformer]
 */

public class PlayerMovement : MonoBehaviour
{
    // for player respawn and deaths
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;

    // for player movement and jumping
    public float speed;
    private Rigidbody rigid_body;
    public float jump_force = 100;
    public bool isGrounded;

    // for counting coins and UI text
    private int count;
    public int coins;
    public Text countText;
    public Text livesText;
    public Text gameOverText;
    public Text winText;

    public float stunTimer;
    public int currentPlayerSpeed;
    public int index;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();

        // for count text
        winText.text = "";
        SetCountText();

    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        move();
        jump();
   

    }

    void move()
    {
        Vector3 add_position = Vector3.zero;

        // moving left
        if (Input.GetKey("a"))
            {
                add_position += Vector3.left * Time.deltaTime * speed;
            }

        // moving right
        if (Input.GetKey("d"))
            {
                add_position += Vector3.right * Time.deltaTime * speed;
            }
        GetComponent<Transform>().position += add_position;

        if (transform.position.y < fallDepth)
        {
            respawn();
        }
    }

    void jump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.15f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey("space") && isGrounded)
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }
    }

    private void respawn()
    {
        transform.position = startPosition;
        StartCoroutine(Blink());
        lives--;
        SetCountText();

        if (lives <= 0)
        {
            this.enabled = false;
        }
    }

    // interacting with other objects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            coins++;
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.tag == "enemy")
        {
            respawn();
        }
        if (other.gameObject.tag == "bigpokes")
        {
            respawn();
        }
        if (other.gameObject.tag == "DrippingLava")
        {
            respawn();
        }

        if (other.tag == "exit")
        {
            scene_switch.instance.loadNextScene(); 
        }

       
        if (other.tag == "laser")
        {
            StartCoroutine(Stun());
        }
       
    }

    // count text functions
    void SetCountText()
    {
        countText.text = "Coins: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            gameOverText.text = "Big Oof Yikes";
        }

        if (count >= 15)
        {
            winText.text = "You Win!";
        }
    }

    // couroutine for player blinking
    public IEnumerator Blink()
    {
        for (int index = 0; index < 30; index++)
        {
            if(index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator Stun()
    {
        float currentPlayerSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;
    }
}
