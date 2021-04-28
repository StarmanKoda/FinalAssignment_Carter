using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject[] gun;
    public float cooldownTime;
    public int gunSelected = 0;
    protected float coolTimer = 0;
    public ParticleSystem particle;

    // Update is called once per frame
    private void Update()
    {

        if (cooldownTime > coolTimer)
        {
            coolTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
            coolTimer = cooldownTime;
        }
    }

    public void Shoot()
    {
        GameObject temp;

        temp = Instantiate(gun[gunSelected], muzzle.transform.position, muzzle.transform.rotation);
        particle.Play(true);
    }
}
