using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject wapon;
    float fireRate;
    float nextFire;
    public int health ;
    public GameObject deadEffect;
    public float speed = 1f;
    public float upAndDown = 10f;
    void Start()
    {
        fireRate = 15f;
        nextFire = Time.time;
        health = 5;

    }

    // Update is called once per frame
    void Update()
    {
        

        CheckTimeToFire();
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.y + 1 < -upAndDown)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.y - 3 > upAndDown)
        {
            speed = -Mathf.Abs(speed);
        }


    }

    void CheckTimeToFire()
    {

        if (Time.time > nextFire)
        {

            Instantiate(wapon, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate / 3;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Rocket"))
        {
            if (health <= 0) { Destroy(gameObject); }
            health --;
            // Destroy(gameObject);
            Debug.Log("strzal");
        }

    }
}