using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificadorVitoria : MonoBehaviour
{
    [Header("Configurações")]
    public int metaColisoes = 25;
    public string nomeCenaVitoria = "vitoriacena"; 

    private bool jaCarregou = false;

    void Update()
    {
        if (jaCarregou) return;
        if (ContadorColisoes.instancia == null) return;

        int numeroAtual = ContadorColisoes.instancia.ContagemAtual;

        if (numeroAtual >= metaColisoes)
        {
            jaCarregou = true;
            CarregarTelaVitoria();
        }
    }

    void CarregarTelaVitoria()
    {
        Debug.Log("🎉 CHEGOU A " + metaColisoes + " COLISÕES! Carregando: " + nomeCenaVitoria);
        SceneManager.LoadScene(nomeCenaVitoria);
    }
}