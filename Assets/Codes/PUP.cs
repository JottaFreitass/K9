using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUP : MonoBehaviour
{
    [SerializeField] private float _velocidade = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);
        if (transform.position.x < -12f)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PUP FOI PEGO");

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.LigarPUDisparoTriplo();
            }

            Destroy(this.gameObject);

        }
    }
}
