using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject item;

    public float fuerzaDisparo = 5f;

    public float intervaloMin = 6f;
    public float intervaloMax = 12f;

    private void Start()
    {
        // Inicia la Coroutine para disparar objetos en intervalos aleatorios.
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float tiempoEspera = Random.Range(intervaloMin, intervaloMax);
            yield return new WaitForSeconds(tiempoEspera);

            GameObject objetoInstanciado = Instantiate(item, transform.position, Quaternion.identity);

            Rigidbody2D rb2D = objetoInstanciado.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.AddForce(Vector2.down * fuerzaDisparo, ForceMode2D.Impulse);
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
