using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDoJogo : MonoBehaviour
{
    

    public bool fimDeJogo = true;

    private GerenciadorDeUI _gerenciadorDeUI;



    void Start()
    {
        _gerenciadorDeUI = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
    }

    void Update()
    {
        
    }
}
