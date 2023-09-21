using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc ;
    public float entradaHorizontal;
    public float entradaVertical;
    public GameObject pfLaser;
    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;
    public bool possoDarDisparoTriplo = false;
    public GameObject disparoTriplo;
    public int vidas = 3;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Método Start de "+this.name);
        veloc = 3.0f ;
        transform.position = new Vector3 (0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > podeDisparar)
            {
                if (possoDarDisparoTriplo == true)
                {
                    Instantiate(disparoTriplo, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(pfLaser, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
                }
                podeDisparar = Time.time + tempoDeDisparo;
            }
        }
    }

private void Movimento()
    {
        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * entradaHorizontal * Time.deltaTime * veloc);
        if (transform.position.x > 2.52f)
        {
            transform.position = new Vector3(2.52f, transform.position.y, 0);
        }
        else if (transform.position.x < -6.50f)
        {
            transform.position = new Vector3(-6.50f, transform.position.y, 0);
        }



        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime * veloc);
        if (transform.position.y > 6.8f)
        {
            transform.position = new Vector3(transform.position.x, -6.8f, 0);
        }
        else if (transform.position.y < -6.8f)
        {
            transform.position = new Vector3(transform.position.x, 6.8f, 0);
        }
    }
    private void Disparo()
    {
        if (Time.time > podeDisparar)
        {
            if (possoDarDisparoTriplo == true)
            {
                Instantiate(disparoTriplo, transform.position + new Vector3(65f, -5.1f, 0), Quaternion.identity);

            }
            else
            {
                Instantiate(pfLaser, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
            }

            podeDisparar = Time.time + tempoDeDisparo;

        }
    }

    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0F);
        possoDarDisparoTriplo = false;
    }

    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo |= true;
        StartCoroutine(DisparoTriploRotina());
        }

    public void DanoAoPlayer()
        {
        vidas--;
        if (vidas < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
