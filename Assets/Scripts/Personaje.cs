using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    //public Animator miAnimador;
    public float velocidadMov;

    public bool saltando;

    public Rigidbody miCuerpo;

    public Vector2 fuerzaSalto;

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    miAnimador.SetTrigger("atacar");
        //}

        if (Input.GetButtonDown("Jump"))
        {
            miCuerpo.AddForce(fuerzaSalto, ForceMode.Impulse);
        }

        //miAnimador.SetBool("saltando", saltando);
        //miAnimador.SetFloat("velY", miCuerpo.velocity.y);

        //if (entradaJugador.y != 0)
        //{
        //    miAnimador.SetBool("caminando", true);
        //}
        //else
        //{
        //    miAnimador.SetBool("caminando", false);
        //}

        if (entradaJugador.y > 0)
        {
            transform.position += transform.forward * Time.deltaTime * velocidadMov;
        }
        else if (entradaJugador.y < 0)
        {
            transform.position -= transform.forward * Time.deltaTime * velocidadMov;
        }

        //if (entradaJugador.x > 0)
        //{
        //    if (entradaJugador.y == 0)
        //    {
        //        miAnimador.SetBool("rotando", true);
        //    }
        //    transform.Rotate(0, 1.5f, 0);
        //}
        //else if (entradaJugador.x < 0)
        //{
        //    if (entradaJugador.y == 0)
        //    {
        //        miAnimador.SetBool("rotando", true);
        //    }
        //    transform.Rotate(0, -1.5f, 0);
        //}
        //else
        //{
        //    miAnimador.SetBool("rotando", false);
        //}
        // if(Input.GetKeyDown(KeyCode.Space))
        // {

        // }
    }


    public void OnCollisionEnter(Collision otro)
    {
        if (otro.gameObject.tag.Equals("piso"))
        {
            saltando = false;
        }
    }

    public void OnCollisionExit(Collision otro)
    {
        if (otro.gameObject.tag.Equals("piso"))
        {
            saltando = true;
        }
    }
}

//{
//    public float miVel = 5f;
//    public float rotacionVel = 10f;
//    public Rigidbody miCuerpo;

//    void Start()
//    {
//        miCuerpo = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        // Obtener la entrada del teclado (WASD o flechas)
//        float horizontal = Input.GetAxis("Horizontal");
//        float vertical = Input.GetAxis("Vertical");

//        // Crear un vector de dirección en base a la entrada
//        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

//        // Mover al personaje
//        Vector3 movement = moveDirection.normalized * miVel * Time.fixedDeltaTime;
//        miCuerpo.MovePosition(miCuerpo.position + movement);

//        // Rotar al personaje hacia la dirección del movimiento
//        if (moveDirection.magnitude > 0.1f)
//        {
//            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
//            miCuerpo.rotation = Quaternion.Slerp(miCuerpo.rotation, targetRotation, rotacionVel * Time.fixedDeltaTime);
//        }
//    }
//}




