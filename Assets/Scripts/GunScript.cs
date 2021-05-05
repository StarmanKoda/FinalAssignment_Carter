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
    public bool otherweap = false;
    public GameObject CoinDisplay;
    public GameObject MoneyDisplay;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("WeaponSwitch"))
        {
            if (gunSelected == 0)
            { 
              gunSelected = 1;
              otherweap = !otherweap;
            }
            else
            {
                gunSelected = 0;
                otherweap = !otherweap;
            }

            
        }

        if (cooldownTime > coolTimer)
        {
            coolTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (MoneyManagement.Instance.Balance > MoneyManagement.Instance.DollarCost && otherweap == false)
            { 
                Shoot();
                coolTimer = cooldownTime;
                MoneyManagement.Instance.Balance -= MoneyManagement.Instance.DollarCost;
            }
            else if (MoneyManagement.Instance.Balance > MoneyManagement.Instance.CoinCost && otherweap == true)
            {
                Shoot();
                coolTimer = cooldownTime;
                MoneyManagement.Instance.Balance -= MoneyManagement.Instance.CoinCost;
            }
        }
        if (otherweap == true)
        {
            MoneyDisplay.SetActive(false);
            CoinDisplay.SetActive(true);
        }
        else
        {
            MoneyDisplay.SetActive(true);
            CoinDisplay.SetActive(false);
        }
    }

    public void Shoot()
    {
        GameObject temp;

        temp = Instantiate(gun[gunSelected], muzzle.transform.position, muzzle.transform.rotation);
        particle.Play(true);
    }
}
