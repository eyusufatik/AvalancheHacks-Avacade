using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasaScript : MonoBehaviour
{

    public GameObject uiPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        uiPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        uiPanel.SetActive(false);
    }

    
}
