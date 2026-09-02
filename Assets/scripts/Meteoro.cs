using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.left * velocidade;
    }
}