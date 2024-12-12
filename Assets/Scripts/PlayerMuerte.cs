using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuerte : MonoBehaviour
{
    public bool isAlive = true; // Indica si el jugador est� vivo
    public Collider specificCollider; // El collider espec�fico que causa la "muerte"
    public Canvas playerWinCanvas; // Canvas �nico que se mostrar� si este jugador gana

    void Update()
    {
        // Aqu� podr�as manejar la l�gica de "muerte" del jugador (ejemplo, si cae por un precipicio o pierde toda su vida)
        if (transform.position.y < -10) // Ejemplo: Si cae por debajo de un umbral
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si el jugador choca con el collider espec�fico, desaparece
        if (collision.collider == specificCollider)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false); // Desactivamos el jugador cuando muere
    }
}


