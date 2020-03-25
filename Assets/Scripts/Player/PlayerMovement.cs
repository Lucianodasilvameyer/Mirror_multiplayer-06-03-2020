using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour //NetworkBehaviour
{
    private Rigidbody m_Rigigbody;

    public float movementSpeed = 20f;   //Velocidade de movimento
    public float turnSpeed = 5.5f;      //Velocidade de rotação

    private void Awake()
    {
        //Acessa o componente Rigidbody e armazena-o na referência "m_Rigidbody"
        m_Rigigbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if(isLocalPlayer)
        
        //Lê os valores de input dos eixos y e x, respectivamente
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Movement(v);
        Rotation(h);
    }

    void Movement(float input)
    {
        float movement = input * movementSpeed * Time.deltaTime;

        m_Rigigbody.velocity = transform.forward * movement;
    }

    void Rotation(float input)
    {
        float rotationValue = input * turnSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, rotationValue, 0);

        m_Rigigbody.MoveRotation(m_Rigigbody.rotation * rotation);
    }
}
