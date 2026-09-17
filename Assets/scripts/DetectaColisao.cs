using UnityEngine;

public class DetectaColisao : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D colisao)
    {
        
        if (colisao.gameObject.CompareTag("Meteoro"))
        {
            Debug.Log("Colidiu com o meteoro!");

            
            if (ContadorColisoes.instancia != null)
            {
                ContadorColisoes.instancia.AdicionarColisao();
            }

            
            Destroy(colisao.gameObject);
        }
    }
}