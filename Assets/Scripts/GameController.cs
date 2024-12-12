using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    void Update()
    {
        CheckGameOverOrWinner();
    }

    void CheckGameOverOrWinner()
    {
        // Buscamos todos los jugadores en la escena
        PlayerMuerte[] players = FindObjectsOfType<PlayerMuerte>();

        // Verificamos cu�ntos jugadores est�n vivos
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
            EndGame();
        }
        else if (alivePlayersCount == 1)
        {
            DeclareWinner(lastAlivePlayer);
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over");
        // Aqu� podr�as implementar l�gica adicional para finalizar el juego, como mostrar una pantalla de fin de juego o reiniciar la escena
        Time.timeScale = 0; // Pausa el juego
    }

    void DeclareWinner(PlayerMuerte winner)
    {
        Debug.Log($"Winner: {winner.name}");
        // Mostrar el canvas del jugador ganador
        if (winner.playerWinCanvas != null)
        {
            winner.playerWinCanvas.gameObject.SetActive(true);
        }
        Time.timeScale = 0; // Pausa el juego
    }
}


