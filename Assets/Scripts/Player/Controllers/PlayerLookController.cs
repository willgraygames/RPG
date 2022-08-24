using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] float mouseLookSensitivity = 100f;
    [SerializeField] Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
    }

    void MouseLook () {
        float mouseX = Input.GetAxis("Mouse X") * mouseLookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseLookSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
