using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadClassic : MonoBehaviour
{
    public GameObject lightSaber;
    public GameObject gun;

    GameObject objectselected = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Classic");

    }
}
