using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazzard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Coin.coinCount = 0;
            //collision.gameObject.GetComponents<PlayerRespawn>().Respawn() ;
            
            if (Checkpoint.currentlyActivatedCheckpoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                collision.gameObject.transform.position = 
                    Checkpoint.currentlyActivatedCheckpoint.transform.position;
            }
            

        }
    }

}
