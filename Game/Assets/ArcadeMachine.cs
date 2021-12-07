using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class ArcadeMachine : MonoBehaviour
{
    public string webGLAddress; 
    public OpenLinkProxy openUrlLib;
    SpriteRenderer sr;
    public Color highlightColor;
    public Color defaultColor;

    public VideoClip videoClip;
    public VideoPlayer vp;
    public int gameSceneBuildIndex;
    
    public GameObject playTexture;
    
    public GameObject rentMintPanel;
    
    public bool isEmpty;
    public int slotId;

    public string url;

    public int gameId;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (isEmpty)
        {
            sr.color = Color.red;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Highlight()
    {
        if (!isEmpty)
        {
            playTexture.SetActive(true);
            vp.clip = videoClip;
            vp.Play();
        }
        
        

        sr.color = highlightColor;
    }
    public void UnHighlight()
    {
        playTexture.SetActive(false);
        vp.Stop();
        if (isEmpty)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = defaultColor;
        }
    }

    public void Interaction()
    {
        if (!isEmpty)
        {

            Debug.Log("This is " + gameObject.name);
            Web3Mng.PlayGame(slotId);
            openUrlLib.OpenWebsite(url);

        }
        else
        {
            rentMintPanel.SetActive(true);
            rentMintPanel.GetComponent<RentPanel>().placeId = GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots.IndexOf(this);
        }
    }
}