using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
 
public class ChooseHero : MonoBehaviour {
 
    public GameObject characterSelect;
    public GameObject[] ships;
    private int ID=0;
    private GameObject Actual;
    public Transform pos;

    private void Start() {
        Actual=Instantiate (ships[ID],pos.position,pos.rotation);
    }

    public void Next() { 
        Destroy(Actual);
        if(ID+1>=ships.Length)
            ID=0;
        else
            ID++;
        Actual=Instantiate (ships[ID],pos.position,pos.rotation);
    }

    public void Previous() {
        Destroy(Actual);
        if(ID-1<0)
            ID=ships.Length;
        ID--;
        Actual=Instantiate (ships[ID],pos.position,pos.rotation);
    }
 
    public void PickHero() {
        NetworkManager.singleton.GetComponent<NetworkCustom>().chosenCharacter = ID;
        characterSelect.SetActive(false);
        Destroy(Actual);
    }
}