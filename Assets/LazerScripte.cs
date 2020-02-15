using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScripte : MonoBehaviour
{
    public int shotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
