using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRodillo : MonoBehaviour
{
    public GameObject rodillo;
    public Transform puntaMano;
    public float fuerzaDisparo = 5f;

    public float intervaloMin = 6f;
    public float intervaloMax = 12f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float tiempoEspera = Random.Range(intervaloMin, intervaloMax);
            yield return new WaitForSeconds(tiempoEspera);

            GameObject objetoInstanciado = Instantiate(rodillo, transform.position, Quaternion.identity);
            objetoInstanciado.transform.rotation = Quaternion.Euler(90, 0, 0);

            Rigidbody2D rb2D = objetoInstanciado.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.AddForce(puntaMano.forward * fuerzaDisparo, ForceMode2D.Impulse);
            }
            else
            {
                Rigidbody rb = objetoInstanciado.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(Vector3.down * fuerzaDisparo, ForceMode.Impulse);
                }
            }
        }
    }
}

