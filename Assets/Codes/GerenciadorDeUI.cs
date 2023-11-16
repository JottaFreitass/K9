using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class GerenciadorDeUI : MonoBehaviour
{
    public Sprite[] vidas;
    public int placar = 0;
    public Text textoDoPlacar;
    public Image mostrarImagemDasVidas;
    public GameObject telaInicial;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarVidas(int vidasAtuais)
    {
        mostrarImagemDasVidas.sprite = vidas[vidasAtuais];  
    }

    public void AtualizarPlacar()
    {
        placar = placar + 100;

        textoDoPlacar.text = "PLACAR: " + placar.ToString();
    }

    public void EsconderTelaInicial()
    {
        telaInicial.SetActive(false);
    }

    public void ExibirTelaInicial()
    {
        telaInicial.SetActive(true);
    }
}
