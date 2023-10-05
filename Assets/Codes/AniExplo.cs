using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniExplo : MonoBehaviour
{
    [SerializeField]
    bool Explosao = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Explosao == true)
        {
            StartCoroutine(TempoExplosao());
        }
    }

    IEnumerator TempoExplosao()
        {
        yield return new WaitForSeconds(0.20f);
        Destroy(this.gameObject);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
