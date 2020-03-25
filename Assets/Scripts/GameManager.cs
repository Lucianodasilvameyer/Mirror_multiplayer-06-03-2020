using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;

    public GameObject m_Player;

    private void Awake()
    {
        m_PlayerMovement = m_Player.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        Debug.Log("Velocidade do jogador: " + m_PlayerMovement.movementSpeed);
    }
}
