using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform m_playerCamera;
    public Transform m_portal;
    public Transform m_otherPortal;
    float m_angle;
    void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = m_playerCamera.position - m_otherPortal.position;
        transform.position = m_portal.position + playerOffsetFromPortal;
        float angularDiff = Quaternion.Angle(m_portal.rotation, m_otherPortal.rotation);
        if(m_angle == 90 || m_angle == 270)
        {
            angularDiff -= 90;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
