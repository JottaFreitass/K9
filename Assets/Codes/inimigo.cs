using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class inimigo : MonoBehaviour

{
    [SerializeField]
    private float _velocidade = 7.5f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;

    [SerializeField] bool EExplosao = false;

    void Start()
    {
            if (EExplosao == true)
        {
            StartCoroutine(TempoExplosao());
        }
    }

    IEnumerator TempoExplosao()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);

        if (transform.position.x < -11.5)
            {
            transform.position = new Vector3(12.5f, Random.Range(-3.3f, 3.4f), 0f);

            }
 
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("O objeto " + name + " colidiu com o objeto" + other.name);


        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }
        }

        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
            Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}