using UnityEngine;
using UnityEngine.InputSystem;

public class Aviao : MonoBehaviour
{
    public float velocidade = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Pega a posição do mouse
        Vector3 posicaoMouse = Mouse.current.position.ReadValue();

        // Converte para a posição no mundo
        posicaoMouse.z = -Camera.main.transform.position.z;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(posicaoMouse);

        // Calcula a direção até o mouse
        Vector2 direcao = mouseWorld - transform.position;

        // Faz o foguete apontar para o mouse
        if (direcao.sqrMagnitude > 0.01f)
        {
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }

        // Enquanto estiver segurando o botão direito
        if (Mouse.current.rightButton.isPressed)
        {
            // Faz o foguete andar
            transform.position = Vector2.MoveTowards(
                transform.position,
                mouseWorld,
                velocidade * Time.deltaTime
            );

            // Toca a animação
            animator.SetBool("Andando", true);
        }
        else
        {
            // Parou de segurar
            animator.SetBool("Andando", false);
        }
    }
}