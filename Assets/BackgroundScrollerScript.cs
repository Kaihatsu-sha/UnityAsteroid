using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollerScript : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement;
        movement = Mathf.Repeat(Time.time * speed, 80);

        transform.position = startPosition + (Vector3.back * movement);
    }
}
