using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPer : MonoBehaviour
{

    public Transform puntoDisparo;
    public GameObject prefabItem;
    public float fuerzaDisparo = 10f;
    public int contadorItems = 0;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && contadorItems > 0)
        {
            DispararObjeto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            contadorItems++;
            Destroy(other.gameObject); 
        }
    }

    private void DispararObjeto()
    {
        GameObject objetoDisparado = Instantiate(prefabItem, puntoDisparo.position, puntoDisparo.rotation);

        Rigidbody rb = objetoDisparado.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
        }
        contadorItems--;
    }
}


