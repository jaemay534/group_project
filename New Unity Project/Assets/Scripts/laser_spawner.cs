using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingLeft;
    [Header("Spawner Variables")]
    public GameObject projectilePrefab;
    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

   public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if(projectile.GetComponent<laser>())
        {
            projectile.GetComponent<laser>().goingLeft = goingLeft;
        }
    }
}
