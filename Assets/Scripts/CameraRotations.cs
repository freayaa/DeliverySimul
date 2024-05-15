using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotations : MonoBehaviour
{
    public GameObject Can;

    public Transform CameraAxisTransform;
    public Slider sensivitySlider;

    public float maxSensivity;
    public float minAngle;
    public float maxAngle;
    public float RotationSpeed;

    private void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);

        CursorLOcked();
        Sensivity();
        
    }

    private void CursorLOcked()
    {
        if (Can.gameObject.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Sensivity()
    {
        RotationSpeed = sensivitySlider.value * maxSensivity;
    }
}
