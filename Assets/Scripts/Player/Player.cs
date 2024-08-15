using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPlayer
{
    public static Player Instance { get; private set; }
    public float Health { get => _health; set => _health = value; }

    [SerializeField] private float moveSpd = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask tableLayerMask;
    [SerializeField] private Transform playerHand;
    public Transform PlayerHand => playerHand;
    private float _health = 100;
    private bool isWalking;

    private void Update()
    {
        HandleMovement();
    }
    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVector();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        float moveDistance = moveSpd * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;


        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirx = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirx, moveDistance);
            if (canMove)
            {
                moveDir = moveDirx;
            }
            else
            {
                Vector3 moveDirz = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirz, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirz;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpd = 15f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpd);
    }

    public void HealPlayer(float amount)
    {
        _health += amount;
    }
}
