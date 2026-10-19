using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float moveTime = 0.2f;
    private Vector2 moveInput;

    private Vector3 lookDirection;
    private int attack;

    public bool isPaused = false;
    private GameObject menuManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        menuManager = GameObject.FindGameObjectWithTag("MenuManager");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove called");
        if(!context.performed || isMoving || isPaused) return;
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
        Vector3 direction = Vector3.zero;
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            direction = Vector3.right * Mathf.Sign(moveInput.x);
        }
        else if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
        {
            direction = Vector3.up * Mathf.Sign(moveInput.y);
        }

        if (direction != Vector3.zero)
        {
            StartCoroutine(MovePlayer(direction));
        }
        lookDirection = direction;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("OnPause called");
        if (context.performed)
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                menuManager.GetComponent<MenuManager>().OnGameplayPause();
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                menuManager.GetComponent<MenuManager>().OnResumeClick();
                isPaused = false;
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("OnAttack called");
        if (context.performed)
        {
            // Implement attack logic here
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0f;
        originalPosition = transform.position;
        targetPosition = originalPosition + direction;
        while(elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
}
