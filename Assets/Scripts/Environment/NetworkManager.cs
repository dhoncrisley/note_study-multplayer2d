using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class NetworkManager : MonoBehaviour {
    public SocketIOComponent socket;
    // Use this for initialization
    void Start () {
        StartCoroutine(connectToServer());
    }
    IEnumerator connectToServer()


    {
        yield return new WaitForSeconds(.5f);
        socket.Emit("PlayerConnected");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
