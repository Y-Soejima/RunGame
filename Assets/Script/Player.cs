using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D m_playerCollider;

    private Rigidbody2D m_playerRigidbody;

    private Animator m_playerAnimator;

    [SerializeField] private float m_speed = 10.0f;

    [SerializeField] private float m_jumpPower = 10.0f;

    [SerializeField] private float m_deadPosision;
    void Start()
    {
        m_playerCollider = GetComponent<Collider2D>();

        m_playerRigidbody = GetComponent<Rigidbody2D>();

        m_playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

        Run();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_playerRigidbody.AddForce(transform.up * m_jumpPower,ForceMode2D.Impulse);
            m_playerAnimator.SetTrigger("Jump");
        }
        if (transform.position.y <= m_deadPosision)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_playerAnimator.SetTrigger("Die");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            m_playerAnimator.SetTrigger("Die");
        }
    }
    void Run()
    {
        m_playerRigidbody.AddForce(transform.right * m_speed);
    }
}
