using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 12f;
    Vector3 m_velocity;
    CharacterController m_characterController;
    public Transform groundCheck;
    public LayerMask groudMask;
    RaycastHit hit;

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        m_characterController.Move(move * m_speed * Time.deltaTime);
    }
    void updateSpeed()
    {
         
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
            out hit, 2f, groudMask))
        {
            string terrainType = "";
            terrainType = hit.collider.gameObject.tag;
            switch(terrainType)
            {
                case "SlowerPlane":
                    m_speed = 12f / 2f;
                    break;
                case "FasterPlane":
                        m_speed = 12f * 1.5f;
                    break;
                default:
                    m_speed = 12f;
                    break;
            }
        }
    }
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_speed = 12f;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        updateSpeed();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag ==  "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }


}
