using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FirstPersonMovement: MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float dmgcool = 1.5f;
    public float damagetimer;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (damagetimer < dmgcool)
        {
            damagetimer += Time.deltaTime;
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy" && (damagetimer >= dmgcool))
        {
            MoneyManagement.Instance.Balance -= MoneyManagement.Instance.DamageCost;
            MusicManager.Instance.dmgsound = true;
            damagetimer = 0;
        }
    }
}
