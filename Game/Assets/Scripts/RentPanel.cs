using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentPanel : MonoBehaviour
{
    public int placeId;
    // Start is called before the first frame update
    public void RentPlace(){
        Web3Mng.RentPlace(placeId, Web3Mng.gameId);
        GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[placeId].isEmpty = false;
        GameObject.Find("GameManager").GetComponent<SlotManager>().arcadeMachineSlots[placeId].url = MintViaChain.inputURL; 
    }

    public void Close(){
        this.gameObject.SetActive(false);
    }
}
