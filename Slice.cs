using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;
    public GameObject sliced2;
    public GameObject particleSystem;

    [SerializeField] AudioClip audioClip;

    //public Rigidbody fruitRigidBody;
    //public Collider fruitCollider;

    // Start is called before the first frame update
    void Start()
    {
        //fruitRigidBody = GetComponent<Rigidbody>();
        //fruitCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Weapon") && this.gameObject.CompareTag("Bomb"))
        {
            Instantiate(particleSystem, transform.position, transform.rotation);

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
            /*
            Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(10f, transform.position, 10f, 10f, ForceMode.Impulse);
                }
            }
            */
            Destroy(this.gameObject);
            ScoreManager.instance.loseLife();
        }
        if (other.gameObject.CompareTag("Weapon") && this.gameObject.CompareTag("Fruit"))
        {
            UnityEngine.Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
            Instantiate(particleSystem, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);

            //Saber saber = other.GetComponent<Saber>();
            //Sliceee(saber.direction, saber.transform.position, saber.sliceForce);
            GameObject half = Instantiate(sliced, transform.position, transform.rotation);
            GameObject half2 = Instantiate(sliced2, transform.position, transform.rotation);
            half.GetComponent<Rigidbody>().AddForce(Vector3.left * 1, ForceMode.Impulse);
            half2.GetComponent<Rigidbody>().AddForce(Vector3.right * 1, ForceMode.Impulse);
            ScoreManager.instance.AddPoint();
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            UnityEngine.Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
        }
    }

    /*
    private void Sliceee(Vector3 direction, Vector3 position, float force)
    {
        whole.SetActive(false);
        sliced.SetActive(true);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidBody.velocity;
            slice.AddForceAtPosition(force * direction, position, ForceMode.Impulse);
        }
    }
    */
}
