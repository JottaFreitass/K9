using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Player : MonoBehaviour
{
    public float veloc = 10.0f;
    public float entradaHorizontal;
    public float entradaVertical;
    public GameObject pfLaser;
    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;
    public bool possoDarDisparoTriplo = false; 
    public GameObject disparoTriplo;
    public int vidas = 3;
    private GerenciadorDeUI _uiGerenciador;
    private GerenciadorDoJogo _gerenciadorDoJogo;
    public bool PodeeEncerrar = false;
    [SerializeField] private GameObject _disparoTriploPrefab;
    public float PODEMORRER;



    [SerializeField] private GameObject _explosaoPlayerPrefab;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Método Start de " + this.name);
        veloc = 3.0f;
        transform.position = new Vector3(0, 0, 0);



        _gerenciadorDoJogo = GameObject.Find("GerenciadorDoJogo").GetComponent<GerenciadorDoJogo>();


        _uiGerenciador = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
        if (_uiGerenciador != null)
        {
            _uiGerenciador.AtualizarVidas(vidas);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Movimento();

        Disparo();

        if (vidas < 1)
        {
            Debug.Log("vidas0");
            StartCoroutine("MorteDoK9");
            PODEMORRER += Time.deltaTime;
            if (PODEMORRER >= 1)
            {
                SceneManager.LoadScene("MENU");
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

    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0F);
        possoDarDisparoTriplo = false;
    }

    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo = true;
        StartCoroutine(DisparoTriploRotina());
    }


    public void DanoAoPlayer()
    {
        // vidas = vidas - 1;
        vidas--;

        _uiGerenciador.AtualizarVidas(vidas);

        if (vidas == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(_explosaoPlayerPrefab, transform.position, Quaternion.identity);
        }
    }

    private void Disparo()
    {
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

}
