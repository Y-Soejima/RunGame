using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D m_playerCollider;

    private Rigidbody2D m_playerRigidbody;

    private Animator m_playerAnimator;

    private int m_maxJumpCount = 2;

    private int m_JumpCount = 0;

    [SerializeField] private float m_speed = 10.0f;

    [SerializeField] private float m_jumpPower = 10.0f;

    [SerializeField] private float m_deadPosision;

    [SerializeField] private float m_rayDistance;

    [SerializeField] private float m_offset;

   
    void Start()
    {
        m_playerCollider = GetComponent<Collider2D>();

        m_playerRigidbody = GetComponent<Rigidbody2D>();

        m_playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

        Run();

        Ray2D ray = new Ray2D(new Vector2(transform.position.x, transform.position.y + m_offset), -transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,m_rayDistance);
        if (hit.collider)
        {
            m_JumpCount = 0;
            Debug.DrawRay(ray.origin, ray.direction * m_rayDistance, Color.green);
            Debug.Log(m_JumpCount);
        }

      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_JumpCount <= m_maxJumpCount)
            {
                m_playerRigidbody.AddForce(transform.up * m_jumpPower, ForceMode2D.Impulse);
                m_playerAnimator.SetTrigger("Jump");
                m_JumpCount++;
            }       
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
