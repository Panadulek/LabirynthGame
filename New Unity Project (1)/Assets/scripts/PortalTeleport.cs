using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    //[]<->[]
    //[]<->[]
    //[]<->[]
    public Transform m_reciver;
    public Transform m_player;
    private bool m_playerIsOverlaping; 
    void Start()
    {
        m_playerIsOverlaping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_playerIsOverlaping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_playerIsOverlaping = false;
        }
    }
    private void Teleportation()
    {
        if(m_playerIsOverlaping)
        {
            Vector3 portalToPlayer = m_player.position - this.transform.position;
            float dotProduct = Vector3.Dot(this.transform.up, portalToPlayer);
            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(this.transform.rotation, m_reciver.rotation);
                rotationDiff += 180;
                m_player.Rotate(Vector3.up, rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                m_player.position = m_reciver.position;
                m_playerIsOverlaping = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        Teleportation();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
