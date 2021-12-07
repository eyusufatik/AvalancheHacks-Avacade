// GetWalletAddress.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// use web3.jslib
using System.Runtime.InteropServices;

public class Web3Mng : MonoBehaviour
{
    // text in the button
    // public Text ButtonText;
    // use WalletAddress function from web3.jslib
    [DllImport("__Internal")] private static extern string WalletAddress();
    [DllImport("__Internal")] public static extern void MintGame(string tokenURI);
    [DllImport("__Internal")] public static extern void RentPlace(int placeId, int gameId);
    [DllImport("__Internal")] public static extern void BuyToken(int tokenAmount);
    [DllImport("__Internal")] public static extern void CheckTokenAmount();
    [DllImport("__Internal")] public static extern void PlayGame(int placeId);
    [DllImport("__Internal")] public static extern void GetGameURI(int gameId);
    [DllImport("__Internal")] public static extern void CheckPlace(int placeId);


    // public GameObject input;
    public static int gameId;
    public string gameURL;
    void Start(){
        for(int i = 0; i < 6; i++){
            CheckPlace(i);
        }
        // for(int i = 0; i < 6; i++){
        //     CheckURLS(i);
        // }

    }
    private IEnumerator CheckURLS(int x){
        yield return new WaitForSeconds(0.1f);
        GetGameURI(x);
    }
    void Update(){
        // if(Input.GetKeyUp(KeyCode.A)){
        //      MintGame("google.com");
        // }

        // if(Input.GetKeyUp(KeyCode.S)){
        //     int placeId = int.Parse(input.GetComponent<InputField>().text);
        //     Debug.Log(placeId);
        //     RentPlace(placeId, gameId);
        // }

        // if(Input.GetKeyUp(KeyCode.D)){
        //      BuyToken(10);
        // }

        // if(Input.GetKeyUp(KeyCode.F)){
        //      PlayGame(int.Parse(input.GetComponent<InputField>().text));
        // }

    }
    // public void OnClick()
    // {
    //     // get wallet address and display it on the button
    //     ButtonText.text = WalletAddress();
    //     MintGame("ads");
    //     RentPlace(0, 1);
    //     BuyToken(1);
    // }

    public void GetMintReturn(string str){
        //shitty solution.
        string[] datas = str.Split("~");
        Debug.Log(datas[0] + " " + datas[1]);
        gameId = int.Parse(datas[0]);
    }

    public void GetRentPlaceReturn(string str){
        string[] datas = str.Split("~");
        Debug.Log(datas[0] + " " + datas[1] + " " + datas[1]);
        // pop up window + game koyma
    }

    public void GetBuyTokenReturn(string st){
        CheckTokenAmount();
    }

    public void GetCheckTokenAmountReturn(string str){
        // SET TOKEN TEXT
        Debug.Log(str);
    }

    public void GetPlayGameReturn(string str){
        bool check = bool.Parse(str);
        if(check){
            Debug.Log("you can play");
            CheckTokenAmount();
            GetGameURI(gameId);
        }else{
            Debug.Log("you cant play");
        }
    }  

    public void GetGameURIReturn(string ret){
        string[] datas = ret.Split("~");
        int gameId = int.Parse(datas[0]);
        string url = datas[1];
        for(int i = 0; i < 6; i++){
            if(GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[i].gameId == gameId){
                Debug.Log(url + " " + gameId);
                GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[i].url = url;
            }
        }
    }

    public void GetCheckPlaceReturn(string ret){
        string[] datas = ret.Split("~");
        int placeId = int.Parse(datas[0]);
        bool isFull = bool.Parse(datas[1]);
        int gameId = int.Parse(datas[2]);
        Debug.Log(placeId + " " + isFull + " " + gameId);
        if(isFull){
            GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[placeId].isEmpty = false;
            GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[placeId].gameId = gameId;
            GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[placeId].UnHighlight();
            GetGameURI(gameId);
        }
    }
}