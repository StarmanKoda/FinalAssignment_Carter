using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag=="Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
