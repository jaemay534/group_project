using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrippingAcid : MonoBehaviour
{
    public GameObject acid_drip_prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AcidDrip", 0f, 2f); 
    }
    public void AcidDrip()
    {
        Instantiate(acid_drip_prefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }

}
