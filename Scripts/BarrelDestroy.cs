using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag=="Money")
        {
            Destroy(this.gameObject);
            MoneyManagement.Instance.Balance += 50;
            MusicManager.Instance.moneyget = true;
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
