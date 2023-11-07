using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // component movement
    private CharacterController controller;
    private Animator animator;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    PlayerInteraction playerInteraction;

    private float moveSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // get movement components
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // function yang mengatur semua gerakan
        Move();

        Interact();
    }

    public void Interact()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            playerInteraction.Interact();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        if(Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        if(dir.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(dir);

            controller.Move(velocity);
        }

        animator.SetFloat("Speed", velocity.magnitude);
    }
}
