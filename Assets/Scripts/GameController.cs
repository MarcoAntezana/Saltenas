using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Update()
    {
        VerificarGanador();
    }

    void VerificarGanador() 
    {
        //buscar jugadores
        PlayerMuerte[] players = FindObjectsOfType<PlayerMuerte>();

        //cuantos jugadores vivos
        int alivePlayersCount = 0;
        PlayerMuerte lastAlivePlayer = null;

        foreach (PlayerMuerte player in players)
        {
            if (player.isAlive)
            {
                alivePlayersCount++;
                lastAlivePlayer = player;
            }
        }

        if (alivePlayersCount == 0)
        {
            FinJuego();
        }
        else if (alivePlayersCount == 1)
        {
            Ganador(lastAlivePlayer);
        }
    }

    void FinJuego()
    {
        Time.timeScale = 1;
    }

    void Ganador(PlayerMuerte ganador)
    {
        if (ganador.playerWinCanvas != null)
        {
            ganador.playerWinCanvas.gameObject.SetActive(true);
        }
        Time.timeScale = 1;
    }
}


