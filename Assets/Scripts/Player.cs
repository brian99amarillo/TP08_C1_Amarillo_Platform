using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //[SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform Gun;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask ground;
    //[SerializeField] private SettingsPlayerSO settingsPlayer;
    [SerializeField] private GameObject CanvasGameOver;
    [SerializeField] private GameObject CanvasWinner;
    [SerializeField] private Image image;
    [SerializeField] private float fallLimitY = -2f;
    private Vector2 lastGroundPosition;
    private Rigidbody2D rb;
    private float life;
    [SerializeField] private float LongLine = 1f;
    private bool isWalking = false;
    private bool isGrounded = false;
    private Vector2 starPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    //    life = settingsPlayer.Life;
          animator.SetBool("Idle", true);
    //    starPos = settingsPlayer.StartPosition;
    //    transform.position = starPos;
    //    lastGroundPosition = starPos;
    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            isGrounded = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y + (LongLine * -1)), ground); // Verifica si el objeto está tocando el suelo
            //if (isGrounded)
            //{
            //    lastGroundPosition = transform.position;
            //}

            //if (transform.position.y < fallLimitY)
            //{
            //    ReturnToLastGround();
            //}

            //animator.SetBool("Idle", true);
            isWalking = false;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(new Vector2(0, 8/*settingsPlayer.JumpForce*/), ForceMode2D.Impulse);
                //AudioManager.Instance.PlayerJump();
            }
            if (Input.GetKey(KeyCode.A)) // Si la tecla A está presionada el objeto se mueve hacia la izquierda
            {
                rb.linearVelocity = new Vector2(-5f/*-settingsPlayer.Speed*/, rb.linearVelocity.y);
                transform.right = Vector2.left;
                isWalking = true;

            }
            else if (Input.GetKey(KeyCode.D)) // Si la tecla D está presionada el objeto se mueve hacia la derecha
            {
                rb.linearVelocity = new Vector2(5f/*settingsPlayer.Speed*/, rb.linearVelocity.y);
                transform.right = Vector2.right;
                isWalking = true;
            }
            else 
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                
            }
            animator.SetBool("Jump", !isGrounded);
            animator.SetBool("Idle", isGrounded && !isWalking);
            animator.SetBool("Walk", isGrounded && isWalking);
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Bullet bullet = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
            //    bullet.Shoot((int)Mathf.Sign(Gun.right.x));
            //    AudioManager.Instance.PlayerShoot();
            //}
        }
    }




    //private void Damage(Collider2D collision)
    //{

    //    life -= collision.GetComponent<BulletEnemy>().Damage;
    //    AudioManager.Instance.PlayerDamege();
    //    image.fillAmount = life / settingsPlayer.Life;
    //    if (life <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void DamageCollision(Collider2D collision)
    //{
    //    Enemy enemy = collision.GetComponent<Enemy>();
    //    AudioManager.Instance.PlayerDamege();
    //    life -= enemy.Settings.Damage;
    //    image.fillAmount = life / settingsPlayer.Life;
    //    if (life <= 0)
    //    {
    //        Die();
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        DamageCollision(collision.collider);
    //    }
    //    if (collision.gameObject.CompareTag("Finish"))
    //    {
    //        Winner();
    //    }

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("EnemyBullet"))
    //    {
    //        if (PowerUpInvisibility.activedInvincibility) return;
    //        Damage(collision);
    //    }
    //}

    //public void Heal(float amount)
    //{
    //    life = Mathf.Min(life + amount, settingsPlayer.Life);
    //    UIHealtPlayer.Instance.UpdateHealthBar(life, settingsPlayer.Life);
    //}
    //private void ReturnToLastGround()
    //{
    //    life -= settingsPlayer.FallDamage;
    //    AudioManager.Instance.PlayerDamege();
    //    image.fillAmount = life / settingsPlayer.Life;

    //    if (life <= 0)
    //    {
    //        Die();
    //        return;
    //    }

    //    rb.linearVelocity = Vector2.zero;
    //    transform.position = lastGroundPosition;
    //}
    //private void Die()
    //{
    //  CanvasGameOver.SetActive(true);
    //  AudioManager.Instance.PauseMusicGameplay();
    //  AudioManager.Instance.GameOver();
    //  Time.timeScale = 0f;
    //}

    //private void Winner()
    //{
    //    UIWinner.Instance.ScoreWinner();
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 point = new Vector2(transform.position.x, transform.position.y - LongLine);
        Gizmos.DrawWireSphere(point, 0.05f);
    }
}
