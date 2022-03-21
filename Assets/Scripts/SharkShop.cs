using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();

                if(player != null)
                {
                    if(player.hasCoin == true)
                    {
                        player.hasCoin = false;
                        UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if(uIManager != null)
                        {
                            uIManager.RemoveCoin();
                        }

                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapons();
                    }
                    
                }
            }
        }
    }
}
