using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static Checkpoint currentlyActivatedCheckpoint;

    [SerializeField]
    private float activatedScale;

    [SerializeField]
    private float deactivatedScale;

    [SerializeField]
    private Color activatedColor;

    [SerializeField]
    private Color deactivatedColor;

    private bool isActive = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DeactivateCheckpoint();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive != true)
        {
            ActivateCheckpoint();
            
        }
    }

    private void DeactivateCheckpoint()
    {
        isActive = false;
        transform.localScale = Vector3.one * deactivatedScale;
        spriteRenderer.color = deactivatedColor;
    }

    private void ActivateCheckpoint()
    {
        if (currentlyActivatedCheckpoint != null)
        {
            currentlyActivatedCheckpoint.DeactivateCheckpoint();
        }
        isActive = true;
        currentlyActivatedCheckpoint = this;
        transform.localScale = Vector3.one * activatedScale;
        spriteRenderer.color = activatedColor;
    }


}
