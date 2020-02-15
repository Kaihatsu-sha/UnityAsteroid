using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotation;
    public float minSpeed;
    public float maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.angularVelocity = Random.insideUnitSphere * rotation;
        body.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Вызывается при столкновении коллаидеров
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Asteroid")
            return;

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);

            GameScript.instance.isLost = true;
        }
        else
        {
            GameScript.instance.IncreaseScore(1);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
