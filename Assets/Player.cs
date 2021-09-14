using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    Animator Anim;
    public CharacterController Contoroll;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelosity;
    public Transform Cam;
   // Rigidbody PlayerRb;
    float horizontal;
    float Vertical;
    public float TimeToDlay = 3f;
    void Start()
    {
        Anim = GetComponent<Animator>();
       // PlayerRb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 Dirction = new Vector3(horizontal, 0f, Vertical).normalized;
        Dirction = new Vector3(horizontal, 0f, Vertical).normalized;
        if (Dirction.magnitude >= 0.1f)
        {
            float Target = Mathf.Atan2(Dirction.x, Dirction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Target, ref turnSmoothVelosity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 MoveDirection = Quaternion.Euler(0f, Target, 0f) * Vector3.forward;
            Contoroll.Move(MoveDirection * Speed * Time.deltaTime);
        }
        Anim.SetFloat("BlendV", Vertical);
        Anim.SetFloat("BlendH", horizontal);

        if (Input.GetKeyDown(KeyCode.Mouse0) && Dirction.magnitude <= 0.1f)
        {
            Anim.SetBool("Attack", true);
            Anim.SetBool("Attackstyle", true);
            StartCoroutine("CombatDlay");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Attackstyle", false);
            Anim.SetBool("Attack", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Attackstyle", false);
            Anim.SetBool("Attack", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Anim.SetBool("Attackstyle", false);
            Anim.SetBool("Attack", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Anim.SetBool("Attackstyle", false);
            Anim.SetBool("Attack", false);
        }
    }
    public IEnumerator CombatDlay()
    {
        yield return new WaitForSeconds(TimeToDlay);
        Anim.SetBool("Attack", false);
        Anim.SetBool("Attackstyle", false);
    }

}
