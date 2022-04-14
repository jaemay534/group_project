using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid_body;
    private Vector3 startPosition;

    // ints for keys and Gifts

    public int coins = 0;
    public int gift_weight_count = 0;
    public int gift_necklace_count = 0;
    public int gift_bread_count = 0;
    public int keys_count = 0;

    public int currentPlayerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
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

        // moving forward
        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }

        //moving backward
        if (Input.GetKey("s"))
        {
            add_position += Vector3.back * Time.deltaTime * speed;
        }

        GetComponent<Transform>().position += add_position;
    }

    void OnTriggerEnter(Collider other)
    {   
        //create if for coins 

        // for key items
        if(other.gameObject.tag == "Treat")
        {
            gift_bread_count++;
            print("Treat: " + gift_bread_count);
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "Weights")
        {
            gift_weight_count++;
            print("Weight: " + gift_weight_count);
            other.gameObject.SetActive(false);
        } 
        
        if(other.gameObject.tag == "Necklace")
        {
            gift_necklace_count++;
            print("Necklace: " + gift_necklace_count);
            other.gameObject.SetActive(false);
        }  

        // for switching scenes and final door

        if (other.gameObject.tag == "final door")
        {
            print("I can't let you pass without the keys");
        }

        if (other.tag == "exit")
        {
            switch_scene.instance.loadNextScene();
        }

        // colliding with any enemies

        if (other.tag == "DrippingAcid")
        {
            StartCoroutine(Blink());
        }

        if (other.tag == "Enemy")
        {
            StartCoroutine(Blink());
        }

        if (other.tag == "PewPew")
        {
            StartCoroutine(Blink());
        }

        if (other.tag == "Ouchies")
        {
            StartCoroutine(Blink());
        }

        if (other.tag == "Back&ForthEnemy")
        {
            StartCoroutine(Blink());
        }

        // interacting with NPC

        if (other.tag == "NPCone")
        {
            if(gift_necklace_count >= other.gameObject.GetComponent<NPCs>().necklace_lock)
            {
                print(" OH ho ho, look at you go.");
                gift_necklace_count -= other.gameObject.GetComponent<NPCs>().necklace_lock;
                keys_count++;
            }
            else
            {
                print("Oh you want the key? Then a necklace of gold you need to retrieve.");
            }
        }

        if (other.tag == "NPCtwo")
        {
            if(gift_bread_count >= other.gameObject.GetComponent<NPCs>().bread_lock)
            {
                print(" OH ho ho, look at you go.");
                gift_bread_count -= other.gameObject.GetComponent<NPCs>().bread_lock;
                keys_count++;
            }
            else
            {
                print("Unless you carry a tasty treat, forever out of reach my key will be.");
            }
        }

        if (other.tag == "NPCthree")
        {         
            if(gift_weight_count >= other.gameObject.GetComponent<NPCs>().weight_lock)
            {
                print(" OH ho ho, look at you go.");
                gift_weight_count -= other.gameObject.GetComponent<NPCs>().weight_lock;
                keys_count++;
            }
            else
            {
                 print("I'm looking for a weight, a key waits for you until you find something great.");
            }
        }

        if (other.tag == "NPCfour")
        {
            if(keys_count >= other.gameObject.GetComponent<NPCs>().key)
            {
                      
                print("I was supposed to be an artist, off in a little cottage in the woods. How did I even get here?");
                print("They do this every day too, do they meet every morning to discuss rhymes...without me?");
                print("I mean, I don't want to be here right? I don't care about them...");
                print("...I wanna be a part of the rhyme meetings...");
                print("Well, thanks for listening to my worries, here's a key to continue your journey.");
                keys_count++;
            }  
            else
            {
                print("What're you looking at? You expected a rhyme? I don't get paid enough to deal with this.");
            }
        }
    }

    public IEnumerator Blink()
    {
        for (int index = 0; index < 30; index++)
        {
            float currentPlayerSpeed = speed;
            speed = 0;
            if (index % 2 == 0)
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
        speed = currentPlayerSpeed;
    }
}
