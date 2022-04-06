using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    // Dados do personagem
    public Jogador jogador;

    
   
    public void restaurar()
    {
        transform.localScale = new Vector2(0.85f, 0.85f);
        StartCoroutine(EsperaImprime(1.0f));
        transform.localScale = new Vector2(1f, 1f);
        jogador.restaurarDados();
    }

    IEnumerator EsperaImprime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
    }

}
