using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

}
