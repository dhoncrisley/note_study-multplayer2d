using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class NetworkManager : MonoBehaviour
{
    public SocketIOComponent socket;
    // Use this for initialization
    void Start(){
        StartCoroutine(connectToServer());
        socket.On("PLAYER_CONNECTED", onPlayerConnected);
        socket.On("PLAY", onPlayerPlay);

    }

    IEnumerator connectToServer(){
        yield return new WaitForSeconds(.5f);
        socket.Emit("PLAYER_CONNECTED");
        yield return new WaitForSeconds(1f);

        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = "Dhoncrisley";
        Vector3 position = new Vector3(0, 0, 0);
        data["position"] = position.x +","+ position.y + "," + position.z;

        socket.Emit("PLAY", new JSONObject(data));
    }
    private void onPlayerConnected(SocketIOEvent evt)
    {
        Debug.Log("get message from server"+ evt.data);
    }
    private void onPlayerPlay(SocketIOEvent evt)
    {
        Debug.Log("get message from server" + evt.data);
    }
}
