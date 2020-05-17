using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public float mouseSens = 100f;

    public Transform playerBody;

    private float xRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var realMouseSens = mouseSens * Time.deltaTime;
        var mouseX = Input.GetAxis("Mouse X") * realMouseSens;
        var mouseY = Input.GetAxis("Mouse Y") * realMouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    void OnApplicationFocus(bool hasFocus)
    {
        xRotation = 0;
        transform.localRotation = Quaternion.Euler(0, 0f, 0f);
        playerBody.transform.localRotation = Quaternion.Euler(0, 0f, 0f);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        xRotation = 0;
        transform.localRotation = Quaternion.Euler(0, 0f, 0f);
        playerBody.transform.localRotation = Quaternion.Euler(0, 0f, 0f);
    }
}
