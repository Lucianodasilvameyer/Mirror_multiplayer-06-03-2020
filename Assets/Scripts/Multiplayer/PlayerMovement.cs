using UnityEngine;
using Mirror;   //Biblioteca da solução Mirror

namespace Prototipo.Multiplayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : NetworkBehaviour //Componentes utilizados na rede devem herdar de NetworkBehaviour, onde se encontrar as variáveis e CallBacks
    {
        private Rigidbody m_Rigigbody;

        public float movementSpeed = 15.5f;   //Velocidade de movimento
        public float turnSpeed = 5.5f;        //Velocidade de rotação

        private void Awake()
        {
            //Acessa o componente Rigidbody e armazena-o na referência "m_Rigidbody"
            m_Rigigbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Verifica se este script está sendo executado no player do mesmo cliente
            if (isLocalPlayer)
            {
                //Lê os valores de input dos eixos y e x, respectivamente
                float v = Input.GetAxis("Vertical");
                float h = Input.GetAxis("Horizontal");

                Movement(v);
                Rotation(h);
            }
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
}