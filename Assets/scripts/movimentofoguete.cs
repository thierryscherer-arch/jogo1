using UnityEngine;

public class movimentofoguete : MonoBehaviour
{
    public float forcaMovimento = 10f;
    public float velocidadeMaxima = 8f;

    private Rigidbody2D rb;
    private Camera cam;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        anim = GetComponent<Animator>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = (Vector2)mousePos - rb.position;

        bool botaoPressionado = Input.GetMouseButton(0);

        if (botaoPressionado)
        {
            if (direcao.magnitude > 0.1f)
            {
                rb.AddForce(direcao.normalized * forcaMovimento);
            }
        }

        if (anim != null)
        {
            anim.SetBool("estaLigado", botaoPressionado);
        }

        if (rb.linearVelocity.magnitude > velocidadeMaxima)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadeMaxima;
        }

        if (direcao.magnitude > 0.1f)
        {
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo - 90f);
        }
    }
}