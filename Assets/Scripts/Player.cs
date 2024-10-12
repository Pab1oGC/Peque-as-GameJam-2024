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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisMovement();
       
    }

    private void FixedUpdate()
    {
        Vector2 vector = speed * Time.fixedDeltaTime * moveInput;
        rb.MovePosition(rb.position + vector);
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
}
