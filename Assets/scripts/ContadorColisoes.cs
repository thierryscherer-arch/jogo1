using UnityEngine;
using TMPro;

public class ContadorColisoes : MonoBehaviour
{
    public static ContadorColisoes instancia;

    public TextMeshProUGUI textoContador;
    private int contagem = 0;
    
    public int ContagemAtual { get { return contagem; } }

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AtualizarTexto();
    }

    public void AdicionarColisao()
    {
        contagem++;
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        textoContador.text = "Colisões: " + contagem;
    }
}