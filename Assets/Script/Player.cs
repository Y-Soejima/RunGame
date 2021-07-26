using UnityEngine;
using System.Collections;
using System;
using UniRx;
public class Player : MonoBehaviour
{
    private Collider2D m_playerCollider;

    public Rigidbody2D m_playerRigidbody;

    private Animator m_playerAnimator;

    private int m_maxJumpCount = 2;

    private int m_JumpCount = 0;

    public float m_speed = 10.0f;

    [SerializeField] private float m_jumpPower = 10.0f;

    [SerializeField] private float m_deadPosision;

    [SerializeField] private float m_rayDistance;

    [SerializeField] private float m_offset;

    [SerializeField] private GameManager m_gameManager;

   
    void Start()
    {
        m_playerCollider = GetComponent<Collider2D>();

        m_playerRigidbody = GetComponent<Rigidbody2D>();

        m_playerAnimator = GetComponent<Animator>();
        m_gameManager.m_gameStart.Subscribe(_ => StartCoroutine(PlayerRun()));
    }

    
    void Update()
    {


       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_JumpCount < m_maxJumpCount)
            {
                m_playerRigidbody.velocity = Vector2.zero;
                m_playerRigidbody.AddForce(transform.up * m_jumpPower, ForceMode2D.Impulse);
                m_playerAnimator.SetTrigger("Jump");
                m_JumpCount++;
                Debug.Log(m_JumpCount);
            }       
        }
        
        if (transform.position.y <= m_deadPosision)
        {
            Die();
        }
       
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            m_JumpCount = 0;
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            var item = collision.GetComponent<ItemA>();
            item.Item();
        }
    }
   
    
    IEnumerator PlayerRun()
    {
        while (m_gameManager.m_player != null)
        {
            m_playerRigidbody.velocity = new Vector2(m_speed, m_playerRigidbody.velocity.y);
            yield return new WaitForEndOfFrame();
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("Ž€");
        Die();
    }
    void Die()
    {
        Destroy(this.gameObject);
        m_gameManager.m_player = null;
       
    }

}
