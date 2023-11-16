using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    private float _velocidade = 6.0f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;

    private GerenciadorDeUI _gerenciadorDeUI;

    void Start()
    {
        _gerenciadorDeUI = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);

        if (transform.position.x < -13f)
        {
            transform.position = new Vector3(12.0f, Random.Range(3.3f , -3.3f), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);

        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);

            _gerenciadorDeUI.AtualizarPlacar();

        }

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }
        }

        Destroy(this.gameObject);

        Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);
    }
}
