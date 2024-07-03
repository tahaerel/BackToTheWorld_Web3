
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_freelook : MonoBehaviour
{
    public float panSpeed = 5f; 
    public float zoomSpeed = 5f; 
    public float zoomMin = 1f;   
    public float zoomMax = 10f;  
    public float panLimitX = 50f; 
    public float panLimitZ = 50f; 

    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 hareket = new Vector3(-dikey, 0f, yatay) * panSpeed * Time.deltaTime;
        transform.Translate(hareket, Space.World);

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -panLimitX, panLimitX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -panLimitZ, panLimitZ)
        );

        transform.position = clampedPosition;

        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(zoomInput);
    }

    void ZoomCamera(float zoomInput)
    {
        float zoomAmount = -zoomInput * zoomSpeed;

        float newZoom = Mathf.Clamp(transform.position.y + zoomAmount, zoomMin, zoomMax);

        transform.position = new Vector3(transform.position.x, newZoom, transform.position.z);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            PanCamera();
        }
    }

    void PanCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 panDirection = new Vector3(mouseY, 0f, -mouseX).normalized;

        transform.Translate(panDirection * panSpeed * Time.deltaTime, Space.World);
    }
}