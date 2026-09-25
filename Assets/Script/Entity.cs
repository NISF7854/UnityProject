using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Entity : MonoBehaviour
{
    [Header("Collision Check")]
    [SerializeField] protected float playerToGroundDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] public GameObject groundCheck;
    [SerializeField] public bool isGrounded;

    [Space]
    [SerializeField] protected float playerToWallDistance;
    [SerializeField] protected LayerMask whatIsWall;
    [SerializeField] protected GameObject wallCheck;
    [SerializeField] public bool isWallDetected;
    [Space]
    [SerializeField] public GameObject attackCheck;
    [SerializeField] public float attackRadius;
    [SerializeField] public float attackDamageValue;

    public Canvas ca;
    public Rigidbody2D rb;
    public Animator ani;
    public EntityFX fx;
    public SpriteRenderer sr;
    public bool isFacingRight = true;
    public int facingDir = 1;


    protected virtual void Awake()
    {
        ca = GetComponentInChildren<Canvas>();
        rb = GetComponentInChildren<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        fx = GetComponentInChildren<EntityFX>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //¼ì²â³¡¾°Åö×²
        CollisionCheck();;
    }
    public void SetVelocity(float x,float y)
    {
        rb.velocity = new Vector2 (x,y);
        FilpController();
    }
    public void SetZoreVelocity()
    {
        rb.velocity = Vector2.zero;
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.transform.position, new Vector3(groundCheck.transform.position.x, groundCheck.transform.position.y - playerToGroundDistance));
        Gizmos.DrawLine(wallCheck.transform.position, new Vector3(wallCheck.transform.position.x + playerToWallDistance * facingDir, wallCheck.transform.position.y));

        Gizmos.DrawWireSphere(attackCheck.transform.position, attackRadius);
    }
    //¿ØÖÆ½ÇÉ«·´×ª
    protected virtual void FilpController()
    {
        if (rb.velocity.x > 0 && !isFacingRight)
        {
            Filp();
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            Filp();
        }
    }
    public virtual void Filp()
    {
        facingDir *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
        ca.transform.Rotate(0,180,0);
        
    }
    //ÊÜ»÷
    public virtual void DamageFXEffect()
    {
        fx.StartCoroutine("FlashFX");
        Debug.Log(gameObject.name);
    }


    //¼ì²â³¡¾°Åö×²
    protected virtual void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, playerToGroundDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.transform.position, Vector2.right, playerToWallDistance * facingDir, whatIsWall);
    }
}
