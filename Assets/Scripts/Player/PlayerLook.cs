using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _cameraTransform;

    public float lookSensitivity = 0.5f;

    private Vector2 _lookVector;
    private float xRotation;

    private void OnValidate()
    {
        if (_controller == null)
            _controller = GetComponent<CharacterController>();

        if (_cameraTransform == null)
        {
            var camera = GetComponentInChildren<Camera>();

            if(camera != null)
            {
                _cameraTransform = camera.transform;
            }
            else
            {
                Debug.LogError($"{gameObject.name} does not have a camera.");
            }
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookVector = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lookVector.magnitude > 0.4f)
            Look(_lookVector);
    }

    /// <summary>
    /// Looks in the direction of the vector
    /// </summary>
    /// <param name="vector">The look delta vector</param>
    private void Look(Vector2 vector)
    {
        float xLook = vector.x * lookSensitivity;

        transform.Rotate(Vector3.up * xLook);

        xRotation -= vector.y * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        _cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

