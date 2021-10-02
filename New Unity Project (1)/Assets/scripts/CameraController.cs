using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float m_mouseSensitivity = 0f;
    float m_xRotation = 0f;
    Transform m_parent;
    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;
        m_xRotation = Mathf.Clamp(m_xRotation, -90f, 80f);
        transform.localRotation = Quaternion.Euler(m_xRotation, 0, 0);
        m_parent.Rotate(Vector3.up * mouseX);
          
    }
    void Start()
    {
        m_parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
}
