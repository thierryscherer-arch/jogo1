using UnityEngine;

public class Player : MonoBehaviour
{
    public float forcaMovimento = 10f;
    public float velocidadeMaxima = 8f;

    private Rigidbody2D rb;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        // Segurando o botão direito do mouse
        if (Input.GetMouseButton(1))
        {
            // Pega a posição do mouse
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Calcula a direção até o mouse
            Vector2 direcao = ((Vector2)mousePos - rb.position).normalized;

            // Faz o foguete ir em direção ao mouse
            rb.AddForce(direcao * forcaMovimento);
        }

        // Limita a velocidade máxima
        if (rb.linearVelocity.magnitude > velocidadeMaxima)
        {
            rb.linearVelocity =
                rb.linearVelocity.normalized * velocidadeMaxima;
        }
    }
}