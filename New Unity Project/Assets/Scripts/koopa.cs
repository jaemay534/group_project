using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koopa : MonoBehaviour
{
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    public int

    // Start is called before the first frame update
    void Start()
    {
        upPos = upPoint.transform.position;
        downPos = downPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
