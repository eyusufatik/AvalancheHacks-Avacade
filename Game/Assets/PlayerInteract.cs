using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject interactedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedObject != null)
        {

            

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(interactedObject.GetComponent<ArcadeMachine>()!=null)
                interactedObject.GetComponent<ArcadeMachine>().Interaction();
                else if (interactedObject.GetComponent<MasaScript>() != null)
                interactedObject.GetComponent<MasaScript>().Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ArcadeMachine"))
        {
            interactedObject = collision.gameObject;
            interactedObject.GetComponent<ArcadeMachine>().Highlight();
        }
        else if (collision.gameObject.CompareTag("Masa"))
        {
            interactedObject = collision.gameObject;
         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(interactedObject== collision.gameObject)
        {
            if (interactedObject.GetComponent<ArcadeMachine>() != null)
                interactedObject.GetComponent<ArcadeMachine>().UnHighlight();
            else if (interactedObject.GetComponent<MasaScript>() != null)
                interactedObject.GetComponent<MasaScript>().ClosePanel();

            interactedObject = null;

        }
    }
}
