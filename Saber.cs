using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    private Camera m_Camera;
    private Collider bladeCollider;
    private TrailRenderer trailRenderer;
    private bool slicing;

    public Vector3 direction { get; private set; }
    public float speed 
    { 
        get ; 
        private set; 
    }

    public float sliceForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 v3Velocity = rb.velocity;
        speed = v3Velocity.magnitude;
    }
}
