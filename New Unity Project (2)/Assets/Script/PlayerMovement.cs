using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Author[Isabella Stacy]
    //Date[03/22/2022]
    //Description[Platformer 1]

    public float speed = 10;
    private Rigidbody rigid_body;
    public float jump_force = 100;
    public bool isGrounded;
    private int count;
    public Text count_Text;
    public Text lives_Text;
    public Text gameOver_Text;
    public Text win_Text;
    public int Coins;
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        move();
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
            /*
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.transformDircection(Vector3.down), out hit, Mathf.Infinity);
            Debug.DrawRay(transform.position, transform.transformDircection(Vector3.down) * hit.distance, color.red);
            Debug.Log(hit.distance);
            if (hit.distance <= 1.15f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            */
        }
    }
    void move()
    {
        Vector3 add_position = Vector3.zero;

        if (Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }
        GetComponent<Transform>().position += add_position;
        if(transform.position.y < fallDepth)
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
        SetCountText();
        if(lives <= 0)
        {
            this.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gold_Coin")
        {
            Coins++;
            print(" Gold_Coin " + Coins);
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if(other.gameObject.tag == "Enemy")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Ouchies")
        {
            Respawn();
        }
    }
    void SetCountText()
    {
        count_Text.text = "Coins" + count.ToString();
        lives_Text.text = "Lives" + lives.ToString();
        if(lives <= 0)
        {
            gameOver_Text.text = "You Dead...Oopsies";
        }
        if (Coins >= 13)
        {
            win_Text.text = "Success!";
        }
    }
    
}