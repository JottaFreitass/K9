using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour

{
    [SerializeField]

    private float _velocidade = 7.5f;

    [SerializeField]
    private float _explosaoDoInimigo;
    // Start is called before the first frame update
    void Start()
    {
            
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

        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
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
    }
}