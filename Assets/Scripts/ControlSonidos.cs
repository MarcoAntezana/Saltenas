using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonidos : MonoBehaviour
{
    public static ControlSonidos Instance;
    public List<SonidoNombre> listaSonidos;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        IniciarParlantes();
    }

    public void IniciarParlantes()
    {
        foreach (var sonido in listaSonidos)
        {
            AudioSource nuevoParlante = gameObject.AddComponent<AudioSource>();
            sonido.parlante = nuevoParlante;
            nuevoParlante.clip = sonido.sonido;
        }
    }

    public void ReproducirSonido(string sonidoObjetivo)
    {
        foreach (var sonido in listaSonidos)
        {
            if (sonido.nombreSonido == sonidoObjetivo)
            {
                sonido.parlante.pitch = Random.Range(0.9f, 1.1f);
                sonido.parlante.Play();
                return;
            }
        }
    }

}

[System.Serializable]
public class SonidoNombre
{
    public string nombreSonido;
    public AudioClip sonido;
    public AudioSource parlante;

}

