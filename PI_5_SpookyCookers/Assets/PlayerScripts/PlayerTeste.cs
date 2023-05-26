using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeste : MonoBehaviour
{
    public static PlayerTeste Instance { get; private set; }
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;   
        public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BancadaScript bancadaSelecionada;
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask bancadasVaziasLayer;

    private Vector3 lastInteractDir;
    private BancadaScript bancadaSelecionada;

    private void Awake()
    {
        if (Instance!= null)
        {
            Debug.LogError("Há mais de um player.");
        }
        Instance = this;
    }
    private void Start()
    {
       gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (bancadaSelecionada != null)
        {
            bancadaSelecionada.Interact();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();

    }
    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }
            }

        }
        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

    }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, bancadasVaziasLayer))
        {
            if (raycastHit.transform.TryGetComponent(out BancadaScript bancadaVazia))
            {
                //Tem uma bancada.
                if (bancadaVazia != bancadaSelecionada)
                {
                    SetSelectedCounter(bancadaVazia);

                } else
                {
                    SetSelectedCounter(null);
                }
            }
        } else
        {
            SetSelectedCounter(null);
        }
    }

    private void SetSelectedCounter(BancadaScript bancadaSelecionada)
    {
        this.bancadaSelecionada = bancadaSelecionada;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            bancadaSelecionada = bancadaSelecionada
        });
    }
}
