using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
 
public class NetworkCustom : NetworkManager
{
 
    public int chosenCharacter = 0;
    public GameObject[] characters;
    public HangarManager HM;

    //subclass for sending network messages
    public class NetworkMessage : MessageBase {
        public int chosenClass;
    }
 
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader) {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);
 
        GameObject player;
        Transform startPos = GetStartPosition();
 
        if(startPos != null) {
            player = Instantiate(characters[selectedClass], startPos.position,startPos.rotation) as GameObject;
        }
        else {
            player = Instantiate(characters[selectedClass], Vector3.zero, Quaternion.identity) as GameObject;
 
        }
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        HM.ResetGame();
        
    }
 
    public override void OnClientConnect(NetworkConnection conn) {
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;

        ClientScene.AddPlayer(conn, 0, test);
    }
 
 
    public override void OnClientSceneChanged(NetworkConnection conn) {
        //base.OnClientSceneChanged(conn);
    }
 
    public void btn1() {
        chosenCharacter = 0;
    }
 
    public void btn2() {
        chosenCharacter = 1;
    }
}