using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkProxy : MonoBehaviour
{
    public OpenLinks openL;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OpenWebsite(string inputURL)
    {
        openL.OpenURL($"{inputURL}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
