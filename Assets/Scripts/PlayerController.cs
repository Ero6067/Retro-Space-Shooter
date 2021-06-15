using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    public PlayerInput playerInput;

    public Vector3 _rawInputMovement;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Vector2 moveAxis;
    [SerializeField] private float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 currentPos = rb.position;
        Vector2 adjustedMovement = moveAxis * speed;
        Vector2 newPos = currentPos + adjustedMovement * Time.deltaTime;
        rb.MovePosition(newPos);
    }

    public void onShoot()
    {
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveAxis = context.ReadValue<Vector2>();
        //transform.position += new Vector3(_moveAxis.x * Time.deltaTime * _speed, _moveAxis.y * Time.deltaTime * _speed, 0);
        Debug.Log($"Move axis {moveAxis}");
    }
}