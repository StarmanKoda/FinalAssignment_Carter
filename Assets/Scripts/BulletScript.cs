using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float despawnTime;
    public GameObject collisionEffect;
    float timeAlive = 0;

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        timeAlive += Time.deltaTime;

        if (timeAlive > despawnTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
        }
    }
}
