using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject leftPoints;
    public GameObject rightPoints;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    public bool goingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoints.transform.position;
        rightPos = rightPoints.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //enemy goes vroom
    private void Move()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
}
