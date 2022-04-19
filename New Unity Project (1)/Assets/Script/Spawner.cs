using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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
        InvokeRepeating("SpawnerProjectile", startDelay, timeBetweenShots);
    }

    // Update is called once per frame
    public void SpawnerProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if (projectile.GetComponent<PewPew>())
        {
            projectile.GetComponent<PewPew>().goingLeft = goingLeft;
        }
    }
}
