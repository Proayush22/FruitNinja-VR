using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject apple;
    public GameObject pear;
    public GameObject banana;
    public GameObject orange;
    public GameObject watermelon;
    public GameObject strawberry;
    public GameObject bomb;

    [SerializeField] AudioClip audioClip;

    public Transform[] spawnPoints;
    public int lastSpawn1;
    public int lastSpawn2;

    [SerializeField] float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnFruit", 2.0f, 1f);
    }

    public void Startgame()
    {
        InvokeRepeating("SpawnFruit", 2.0f, 1f);
        ScoreManager.instance.startGame();
    }

    // Update is called once per frame

    public void SpawnFruit()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        while (spawnPointIndex == lastSpawn1) 
        { 
            spawnPointIndex = Random.Range(0, spawnPoints.Length); 
        }
        int fruitIndex = Random.Range(0, 7);
        Quaternion rotation = Quaternion.Euler(Random.Range(-15, 0), 0, Random.Range(-15, 15));

        UnityEngine.Debug.Log("Rotation: " + rotation);

        switch (fruitIndex)
        {
            case 0:
                
                GameObject fruitApple = Instantiate(apple, spawnPoints[spawnPointIndex].position, rotation);
                fruitApple.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 1:
                GameObject fruitPear = Instantiate(pear, spawnPoints[spawnPointIndex].position, rotation);
                fruitPear.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 2:
                
                GameObject fruitBanana = Instantiate(banana, spawnPoints[spawnPointIndex].position, rotation);
                fruitBanana.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 3:
                GameObject fruitOrange = Instantiate(orange, spawnPoints[spawnPointIndex].position, rotation);
                fruitOrange.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 4:
                GameObject gameObject = Instantiate(bomb, spawnPoints[spawnPointIndex].position, rotation);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 5:
                GameObject fruitWatermelon = Instantiate(watermelon, spawnPoints[spawnPointIndex].position, rotation);
                fruitWatermelon.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
            case 6:
                GameObject fruitStrawberry = Instantiate(strawberry, spawnPoints[spawnPointIndex].position, rotation);
                fruitStrawberry.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
                lastSpawn1 = spawnPointIndex;
                break;
        }
        //new Vector3(Random.Range(-1.5f, 1.5f),0, Random.Range(-1.5f, 1.5f))

        AudioSource.PlayClipAtPoint(audioClip, spawnPoints[spawnPointIndex].position, 1f);
    }

    
}
