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
    private int Health = 4;
    public bool bribed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pursuing && bribed == false)
        {
            Ray ray = new Ray(eyes.transform.position, this.transform.forward * visionRange);
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && (hit.transform.tag == "Player"))
            {
                UnityEngine.Debug.Log("I see something");
                pursuing = true;
                target = hit.transform.gameObject;
                animator.SetBool("SeeSomething", true);
            }
        }
        else
        {
            pathFinding.SetDestination(target.transform.position);
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Money" && bribed == false)
        {
            if (collider.gameObject.name == "Money(Clone)")
            {
                animator.SetBool("Bribed", true);
                bribed = true;
                gameObject.tag = "Untagged";
                pathFinding.isStopped = true;
                Instantiate(gits, gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Health -= 1;
                if (Health <= 0)
                {
                    animator.SetBool("Bribed", true);
                    bribed = true;
                    gameObject.tag = "Untagged";
                    pathFinding.isStopped = true;
                    Instantiate(gits, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
    }

}
