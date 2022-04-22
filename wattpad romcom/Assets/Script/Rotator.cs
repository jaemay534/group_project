using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    // make the items twril
    void Update()
    {
        
       transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime);
        
    }
}
