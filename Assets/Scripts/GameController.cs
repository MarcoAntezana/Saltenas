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
<<<<<<< Updated upstream
        Time.timeScale = 0;
=======
        Debug.Log("Game Over");
        // Aquí podrías implementar lógica adicional para finalizar el juego, como mostrar una pantalla de fin de juego o reiniciar la escena
        //Time.timeScale = 0; // Pausa el juego
>>>>>>> Stashed changes
    }

    void Ganador(PlayerMuerte ganador)
    {
        if (ganador.playerWinCanvas != null)
        {
            ganador.playerWinCanvas.gameObject.SetActive(true);
        }
        Time.timeScale = 0;
    }
}


