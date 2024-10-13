using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    public Rigidbody2D rb;
    private Vector2 moveInput;
    public bool invertedControls=false;
    private bool isMoving = false;
    private bool isAttacking;
    public Animator animator;
    public static Player Instance;
    public bool isBeingCarried;
    public float life;
    private float maxLife = 3;

    
    public bool isInDestinationRange = false; // Si el jugador está dentro del área de un destino
    public GameObject carriedObject;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        isBeingCarried = false;
        life = maxLife;
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisMovement();
        CheckLives();
    }

    private void FixedUpdate()
    {
        if (!isBeingCarried && Input.GetKey(KeyCode.Mouse0))
        {
            isAttacking = true;
            animator.SetBool("attacking", isAttacking);
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("AtackAnimation") && stateInfo.normalizedTime >= 1)
        {
            isAttacking = false;
            animator.SetBool("attacking", isAttacking);
            if (GameModeManager.currentMode == GameModeManager.GameMode.SelfDamage)
                TakeDamage(1);
        }

        if (!isAttacking)
        {
            Movement();
        }

        if (GameModeManager.currentMode == GameModeManager.GameMode.InvertedControls)
        {
            invertedControls = true;
        }
        else
        {
            invertedControls = false;
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

    private void TakeDamage(float amount)
    {
        life -= amount;
    }
    void CheckLives()
    {
        if (life <= 0)
        {
            // El jugador ha perdido todas las vidas
            Debug.Log("Game Over");
            // Aquí puedes agregar lógica para terminar el juego, como desactivar el movimiento, mostrar una pantalla de fin de juego, etc.
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    

}
