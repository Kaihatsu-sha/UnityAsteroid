using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmiterAsteroin : MonoBehaviour
{

    public GameObject asteroid;
    public float minDelay;
    public float maxDelay;
    private float nextLaunch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunch)
        {
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            float pozitionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Instantiate(asteroid, new Vector3(pozitionX, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
