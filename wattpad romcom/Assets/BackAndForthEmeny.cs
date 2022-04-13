using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthEmeny : MonoBehaviour
{
    public GameObject backPoints;
    public GameObject forwardPoints;
    private Vector3 backPos;
    private Vector3 forwardPos;
    public int speed;
    public bool goingBack = true;

    // Start is called before the first frame update
    void Start()
    {
        backPos = backPoints.transform.position;
        forwardPos = forwardPoints.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //enemy goes vroom
    private void Move()
    {
        if (goingBack)
        {
            if (transform.position.z <= forwardPos.z)
            {
                goingBack = false;
            }
            else
            {
                transform.position += Vector3.back * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.z >= backPos.z)
            {
                goingBack = true;
            }
            else
            {
                transform.position += Vector3.forward * Time.deltaTime * speed;
            }
        }
    }
}
