using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripte : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;
    public float delay;//Как часто можно стрелять
    private Rigidbody player;
    public int speed;
    private int rotation = 30;

    public GameObject lazerShot;
    public Transform lazerGun;

    private float nextShot;// Когда можно сделать следующий выстрел

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//Left of Right
        float moveVertical = Input.GetAxis("Vertical");
        //int speed = 5;

        player.velocity = new Vector3(moveHorizontal * speed,0,moveVertical * speed);
        player.rotation = Quaternion.Euler(moveVertical * rotation, 0,moveHorizontal * -rotation);


        float pozitionX = Mathf.Clamp(player.position.x, xMin, xMax);
        float pozitionZ = Mathf.Clamp(player.position.z, zMin, zMax);

        player.position = new Vector3(pozitionX, 0, pozitionZ);

        Shot();
        
    }

    private void Shot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity);//Создаем обьект,где
            nextShot = Time.time + delay;
        }
    }
}
