using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrip : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.y < -2f)
        {
            Destroy(this.gameObject);
        }
    }
}
