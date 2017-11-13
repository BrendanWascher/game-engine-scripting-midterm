using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour {

    // must be placed on player game object
    private void Respawn()
    {
        if (Checkpoint.currentlyActivatedCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            transform.position =
                Checkpoint.currentlyActivatedCheckpoint.transform.position;
        }
    }
}
