using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thwamp_drop : MonoBehaviour
{
    public float pause;
    public GameObject thwamp_prefab;


    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator Move()
    {
        if (GetComponent<Transform>().position.y < -2f)
        {
            Instantiate(thwamp_prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            yield return new WaitForSeconds(pause);
        }
       

    }
    
}
