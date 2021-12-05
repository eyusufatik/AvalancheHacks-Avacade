using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection.Normalize();
        anim.SetFloat("Horizontal", -movementDirection.x);
        anim.SetFloat("Vertical", -movementDirection.y);
        anim.SetFloat("Speed", movementDirection.magnitude);

    }

    private void FixedUpdate()
    {
        rb.velocity =  (movementDirection * movementSpeed);
    }






}
