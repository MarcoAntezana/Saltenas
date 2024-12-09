using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje2 : MonoBehaviour
{
    public bool saltando;
    public Animator miAnimador;
    public Rigidbody miCuerpo;
    public Transform posicionPies;
    public Vector2 fuerzaSalto;
    public LayerMask capaPiso;
    public bool pisando = true;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            miCuerpo.AddForce(fuerzaSalto, ForceMode.Impulse);
        }

        miAnimador.SetBool("saltando", saltando);
        miAnimador.SetFloat("VelY", miCuerpo.velocity.y);
    }

    private void OnTriggerEnter(Collider otroObjeto)
    {
        if (otroObjeto.CompareTag("piso"))
        {
            Destroy(gameObject);
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




