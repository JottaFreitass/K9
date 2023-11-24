using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buton : MonoBehaviour
{

    public GameObject player;
    public bool fimDeJogo = true;

    [SerializeField] private Button BotaoJogar;

    GameObject MenuGameUI;

    private void Awake()
    {
        BotaoJogar.onClick.AddListener(OnButtonPlayClickJogar);
    }

    private void OnButtonPlayClickJogar()
    {
        Debug.Log("JOGAR");        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}



