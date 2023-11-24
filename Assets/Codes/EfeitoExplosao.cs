using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoExplosao : MonoBehaviour
{
    
    public bool PodeeEncerrar = false;
    private GerenciadorDeUI _uiGerenciador;
    private GerenciadorDoJogo _gerenciadorDoJogo;
    

    void Start()
    {
        Destroy(gameObject, 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
