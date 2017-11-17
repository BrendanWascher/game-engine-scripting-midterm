using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    [SerializeField]
    string sceneToLoad;

    [SerializeField]
    Text MessageBox;

    string pressEtoEnter = "Press 'E' to enter";

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MessageBox.text = pressEtoEnter.ToString();
            if(Input.GetButtonDown("Action"))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
