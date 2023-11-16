using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDoJogo : MonoBehaviour
{
    public GameObject player;

    public bool fimDeJogo = true;

    private GerenciadorDeUI _gerenciadorDeUI;



    void Start()
    {
        _gerenciadorDeUI = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
    }

    void Update()
    {
        if (fimDeJogo == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                fimDeJogo = false;
                _gerenciadorDeUI.EsconderTelaInicial();
            }
        }
    }
}
