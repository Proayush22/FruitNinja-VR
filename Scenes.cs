using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    public GameObject lightSaber;
    public GameObject gun;

    public Transform parent;

    GameObject objectselected = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneClassic()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Classic");

    }

    public void LoadSceneSurvival()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Survival");
    }

    public void LoadSceneHub()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FN Hub");
    }
    public void objectSelectedLightSaber() 
    { 
        objectselected = lightSaber;
    }
    public void objectSelectedGun()
    {
        objectselected = gun;
    }
    public void objectDeselected()
    {
        objectselected = null;
    }
    public void getSelectedObject()
    {
        if (objectselected != null)
        {
            Instantiate(objectselected);
            objectselected.transform.SetParent(parent.transform);
        }
    }
}
