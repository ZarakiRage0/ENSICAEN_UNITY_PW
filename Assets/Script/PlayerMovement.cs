using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float m_JumpForce = 200;

    [SerializeField]
    private float m_Speed = 5;

    [SerializeField]
    private int m_JumpsInTotal = 2;

    [SerializeField]
    private KeyCode m_JumpKey = KeyCode.Space;


    private Rigidbody m_Rigidbody;

    private bool m_IsGrounded;

    private int m_JumpsLeft;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_IsGrounded = true;
        m_JumpsLeft = m_JumpsInTotal;
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        JumpOnInput();
    }


    private void Movement()
    {
        float horizental = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(horizental, 0, vertical);
        transform.Translate(input * Time.fixedDeltaTime * m_Speed);
    }

    private void JumpOnInput()
    {
        if (Input.GetKeyDown(m_JumpKey))
        {
            if(m_IsGrounded)
            {
                Vector3 jumpForce = transform.up * m_JumpForce;
                m_Rigidbody.AddForce(jumpForce);
                m_IsGrounded = false;
                m_JumpsLeft--;
            } 
            else if ( CanJumpAgain())
            {
                m_Rigidbody.velocity.Set(0, 0, 0);
                Vector3 jumpForce = transform.up * m_JumpForce;
                m_Rigidbody.AddForce(jumpForce);
                m_IsGrounded = false;
                m_JumpsLeft--;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Ground"))
        {
            m_IsGrounded = true;
            m_JumpsLeft = m_JumpsInTotal;
            Debug.Log(m_JumpsLeft);
        }*/
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
        foreach(ContactPoint contactPoint in collision.contacts)
        {
            if (Vector3.Distance(contactPoint.normal, up) < 0.001)
            {
                m_IsGrounded = true;
                m_JumpsLeft = m_JumpsInTotal;
                break;
            }
        }
    }

    private bool CanJumpAgain()
    {
        return m_JumpsLeft > 0 ;
    }
}
