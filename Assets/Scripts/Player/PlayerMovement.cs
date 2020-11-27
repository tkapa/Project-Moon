using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    public float playerSpeed = 6f;

    private Vector2 _movementVector;

    //Validates this component before play
    private void OnValidate()
    {
        if (_controller == null)
            _controller = GetComponent<CharacterController>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Call jump
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementVector = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_movementVector.magnitude > 0.4f)
            Move(_movementVector);
    }

    /// <summary>
    /// Moves the <see cref="CharacterController"/> in the specified direction
    /// </summary>
    /// <param name="vector">The Movement Vector of this object</param>
    private void Move(Vector2 vector)
    {
        var move = transform.right * vector.x + transform.forward * vector.y;
        _controller.Move((move * playerSpeed) * Time.deltaTime);
    }

    private void Jump()
    {
        //Do jumpy things here
    }
}