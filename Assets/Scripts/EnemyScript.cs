using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent pathFinding;
    public GameObject eyes;
    public GameObject gits;
    public Animator animator;
    public float visionRange;
    public bool pursuing = false;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pursuing)
        {
            Ray ray = new Ray(eyes.transform.position, this.transform.forward * visionRange);
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && (hit.transform.tag == "Player"))
            {
                UnityEngine.Debug.Log("I see something");
                pursuing = true;
                target = hit.transform.gameObject;
            }
        }
        else
        {
            pathFinding.SetDestination(target.transform.position);
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        //HurtboxScript box;
        //EntityScript.Damage(box);
        //if (EntityScript.HP == 0)
        //{
        //    Die();
        //    animator.SetTrigger("Die");
        //}
    }

}
