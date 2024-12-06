using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Animator miAnimador;
    public float velocidadMov;

    public Rigidbody miCuerpo;
    public LayerMask capaPiso;
    public Vector2 fuerzaSalto;
    public bool pisando = true;
    public Transform posicionPies;

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        miAnimador.SetBool("pisando", pisando);

        if (Input.GetButtonDown("Jump") && pisando == true)
        {
            miCuerpo.AddForce(fuerzaSalto, ForceMode.Impulse);
        }

        miAnimador.SetFloat("velY", miCuerpo.velocity.y);

        if (entradaJugador.y != 0)
        {
            miAnimador.SetBool("corriendo", true);
        }
        else
        {
           miAnimador.SetBool("corriendo", false);
        }

        if (entradaJugador.y > 0)
        {
            transform.position += transform.forward * Time.deltaTime * velocidadMov;
        }
        else if (entradaJugador.y < 0)
        {
            transform.position -= transform.forward * Time.deltaTime * velocidadMov;
        }

        if (entradaJugador.x > 0)
        {
            transform.Rotate(0, 1.5f, 0);
        }
        else if (entradaJugador.x < 0)
        {
            transform.Rotate(0, -1.5f, 0);
        }


    }

    private void FixedUpdate()
    {
        //RaycastHit choquePiso;
        if (Physics.Raycast(posicionPies.position, Vector3.down, 0.25f, capaPiso))
        {
            pisando = true;
        }

        else
        {
            pisando = false;
        }
    }
}




