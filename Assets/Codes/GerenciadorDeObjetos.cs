using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{

    [SerializeField] private GameObject _inimigoPrefab;

    [SerializeField] private GameObject[] _powerUps;



    void Start()
    {
        StartCoroutine(RotinaInimigo());

        StartCoroutine(RotinaGeracaoPowerUp());
    }
        

    IEnumerator RotinaInimigo()
    {
        while (1 == 1)
        {
            Instantiate(_inimigoPrefab, new Vector3(16.9F, Random.Range(-3.3f, 3.3f), 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }

    IEnumerator RotinaGeracaoPowerUp()
    {
        while (1 == 1)
        {
            int powerUpsAleatorio = Random.Range(0, 3);
            Instantiate(_powerUps[powerUpsAleatorio], new Vector3(16.9f, Random.Range(-3.3f, 3.3f), 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
}
