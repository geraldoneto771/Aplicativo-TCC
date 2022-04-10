using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    // Dados do personagem
    public Jogador jogador;

    
   
    public void Restaurar()
    {
       
        jogador.restaurarDados();
    }

    

}
