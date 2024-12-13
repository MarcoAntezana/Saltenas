using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSapito : MonoBehaviour
{
    public float pushForce = 50f; // Fuerza del empuje.
    public float pushRadius = 2f; // Radio de alcance del empuje.

    public float velocidadMovimiento;
    public float velocidadRotacion;
    public float velocidadSalto;

    public Rigidbody cuerpoSapo;
    public Animator animadorSapo;

    public bool pisando = true;
    public Transform posicionPies;
    public LayerMask capaPiso;

    public float multiplicadorCorrer = 0.35f;

    void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (entradaJugador.magnitude > 0.1f) // Usa magnitude para evitar falsos positivos con valores mínimos.
        {
            animadorSapo.SetBool("correr", true); // Activa la animación de correr
        }
        else
        {
            animadorSapo.SetBool("correr", false); // Detiene la animación de correr
        }

        //animadorSapo.SetFloat("VelZ", cuerpoSapo.velocity.sqrMagnitude * velocidadMovimiento);
        //animadorSapo.SetBool("pisando", pisando);
        //animadorSapo.SetFloat("VelY", cuerpoSapo.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Corriendo");
            multiplicadorCorrer = 1;
        }
        else
        {
            multiplicadorCorrer = 0.35f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //animadorSapo.SetTrigger("atacar");
            animadorSapo.SetTrigger("empujar");
            ApplyPush();

        }

        cuerpoSapo.velocity = new Vector3(entradaJugador.x * velocidadMovimiento * multiplicadorCorrer,
                                           cuerpoSapo.velocity.y,
                                           entradaJugador.y * velocidadMovimiento * multiplicadorCorrer);

        

        if (Input.GetButtonDown("Jump") && pisando)
        {
            cuerpoSapo.AddForce(Vector2.up * velocidadSalto, ForceMode.Impulse);
        }

        if (entradaJugador.magnitude == 0) return;

        Vector3 direccionObjetivo = new Vector3(entradaJugador.x, 0f, entradaJugador.y);

        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        RaycastHit choquePiso;

        if (Physics.Raycast(posicionPies.position, Vector3.down, 0.15f, capaPiso))
        {
            pisando = true;
        }
        else
        {
            pisando = false;
        }
    }

    private void ApplyPush()
    {
        // Encuentra todos los colliders en el radio del empuje.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            Rigidbody otherRb = hitCollider.attachedRigidbody;
            if (otherRb != null && otherRb != cuerpoSapo)
            {
                Vector3 pushDirection = hitCollider.transform.position - transform.position;
                pushDirection.y = 0; // Evita que el empuje afecte el eje Y.
                pushDirection.Normalize();

                // Aplica la fuerza con ForceMode.VelocityChange.
                otherRb.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);
            }
        }
    }

}
