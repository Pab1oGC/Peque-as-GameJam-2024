using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    public Rigidbody2D rb;
    private Vector2 moveInput;
    private bool invertedControls=false;
    private bool isMoving = false;
    private bool isAttacking;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisMovement();
       
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isAttacking = true;
            animator.SetBool("attacking", isAttacking);
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("AtackAnimation") && stateInfo.normalizedTime >= 1)
        {
            
            isAttacking = false;
            animator.SetBool("attacking", isAttacking); 
        }
        if (!isAttacking)
        {
            Movement();
        }
        
    }
    void GetAxisMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (invertedControls)
        {
            moveX = -moveX;
            moveY = -moveY;
        }
        moveInput = new Vector2(moveX, moveY);
    }
    void InvertControls()
    {
        invertedControls = true;
    }
    void Movement()
    {
        Vector2 vector = speed * Time.fixedDeltaTime * moveInput;
        if (moveInput != Vector2.zero)
        {
            isMoving = true;
            if (moveInput.x < 0)
            {

                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (moveInput.x > 0)
            {

                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
            isMoving = false;

        animator.SetBool("moving", isMoving);
        rb.MovePosition(rb.position + vector);
    }
}
