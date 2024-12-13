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

    public Collider normalCollider; // Collider normal del personaje.
    public Collider empujarCollider; // Collider usado al empujar.

    private bool empujando = false;


    [SerializeField]
    private int playerIndex = 0;

    private Vector2 inputVector = Vector2.zero;
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
            ControlSonidos.Instance.ReproducirSonido("caminar");
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            empujando = !empujando; 
            CambiarCollider(empujando);
        }
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
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
    private void CambiarCollider(bool activandoEmpujar)
    {
        // Activar el collider de empujar.
        empujarCollider.enabled = activandoEmpujar;

        // Actualizar animación.
        miAnimador.SetBool("empujando", activandoEmpujar);
    }

    private void OnCollisionStay(Collision collision)
    {
        // Si está empujando, aplicar fuerza al objeto que colisione.
        if (empujando && collision.gameObject.CompareTag("Empujable"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 fuerzaEmpuje = transform.forward * velocidadMov;
                rb.AddForce(fuerzaEmpuje, ForceMode.Force);
            }
        }
    }
}




