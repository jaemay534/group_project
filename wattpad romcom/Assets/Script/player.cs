using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid_body;
    private Vector3 startPosition;

    // ints for keys and Gifts

    public int gift_weight_count = 0;
    public int gift_necklace_count = 0;
    public int gift_bread_count = 0;
    public int keys_count = 0;


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

        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey("s"))
        {
            add_position += Vector3.back * Time.deltaTime * speed;
        }

        GetComponent<Transform>().position += add_position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //for keys and Gifts
        /*
        if(other.gameObject.tag == "Keys")
        {
            keys++;
            print("Keys: " + keys);
            other.gameObject.SetActive(false);
        }
        */
        /*
        if(other.gameObject.tag == "Treat")
        {
            gift_bread_count++;
            print("Treat: " + Treat);
            other.gameObject.SetActive(false);
        }

         if(other.gameObject.tag == "Weight")
        {
            gift_weight_count++;
            print("Weight: " + Treat);
            other.gameObject.SetActive(false);
        }
        */
        /*
        // for necklace - not made yet
          if(other.gameObject.tag == "Weight")
        {
            gift_weight_count++;
            print("Weight: " + Treat);
            other.gameObject.SetActive(false);
        }
        */

        // for npcs and final door

        if(other.gameObject.tag == "final door")
        {
            print("I can't let you pass without the keys");
        }

    }
}
