using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider otroObjeto)
    {
        if (otroObjeto.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

