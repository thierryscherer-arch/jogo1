using UnityEngine;

public class SpawnadorMeteoros : MonoBehaviour
{
    [Header("Configurações do Spawnador")]
    public GameObject prefabMeteoro;       
    public int quantidadePorVez = 5;       
    public float intervaloSegundos = 5f;  

    [Header("Área de Geração")]
    public float larguraArea = 15f;        
    public float alturaMinima = 6f;        
    public float alturaMaxima = 8f;        

    void Start()
    {
       
        InvokeRepeating(nameof(GerarMeteoros), 0f, intervaloSegundos);
    }

    void GerarMeteoros()
    {
        
        for (int i = 0; i < quantidadePorVez; i++)
        {
       
            float posX = Random.Range(-larguraArea / 2f, larguraArea / 2f);
            float posY = Random.Range(alturaMinima, alturaMaxima);

            Vector3 posicaoAleatoria = new Vector3(posX, posY, 0f);

            
            Instantiate(prefabMeteoro, posicaoAleatoria, Quaternion.identity);
        }

        Debug.Log("Gerados " + quantidadePorVez + " meteoros!");
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 centro = new Vector3(0, (alturaMinima + alturaMaxima) / 2f, 0);
        Vector3 tamanho = new Vector3(larguraArea, alturaMaxima - alturaMinima, 0);

        Gizmos.DrawWireCube(centro, tamanho);
    }
}