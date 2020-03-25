using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class PlayerPickup : NetworkBehaviour
    {
        private bool isCarrying = false;

        [SerializeField] private GameObject pickup;

        public GameObject sphere;

        private void Start()
        {
            sphere.SetActive(false);
        }

        private void Update()
        {
            if(!isLocalPlayer)
            {
                return;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    if (!isCarrying) //isCarrying == false
                    {
                        CmdCollect();
                    }
                    else
                    {
                        CmdDrop();
                    }
                }
            }
        }

        [Command]
        void CmdCollect()
        {
            if (pickup != null)
            {
                

                isCarrying = true;

                sphere.SetActive(true);//aqui a sphere é a filha do player
                pickup.SetActive(false);
            }
        }

        [Command]
        void CmdDrop()
        {
            if (pickup != null)
            {
                //pickup.transform.parent = null; // aqui em vez disso eu não deveria reativar o pickup?

                pickup.SetActive(true);
                pickup.transform.position = transform.position;
               
                sphere.SetActive(false);


                isCarrying = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectable")
            {
                if (!isCarrying)
                {
                    pickup = other.gameObject;

                }
                    
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Collectable")
            {
                if (pickup != null && pickup == other.gameObject) //Aqui só o pickup != null já não é o suficiente?
                {
                    
                    if (!isCarrying)//este if é necessario?, porque se o isCarrying fosse true no enter, nem averia uma referencia? 
                    {
                        pickup = null;//serve para o player não pegar a esfera de qualquer lugar
                    }
                }
            }
        }
    }
}
