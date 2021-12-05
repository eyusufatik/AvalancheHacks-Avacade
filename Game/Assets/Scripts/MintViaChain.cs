using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MintViaChain : MonoBehaviour
{
    public GameObject inputFieldText;
    public static string inputURL;
    public GameObject mintPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CallContract()
    {
        
        inputURL = inputFieldText.GetComponent<TMP_Text>().text;
        Debug.Log(inputURL);
        Web3Mng.MintGame(inputURL);
        //inputUrl
        /////???????
    }

    public void CloseTab()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
