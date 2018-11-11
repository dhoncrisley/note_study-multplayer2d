using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public SocketIOComponent socket;
    float xAxis;
    float yAxis;
    bool isWalking;
    float angle;
    public float vel;
    public Vector3 mousePos, mouse;
	// Use this for initialization
	void Start () {
        StartCoroutine(connectToServer());
        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    IEnumerator connectToServer()
    

    {
        yield return new WaitForSeconds(.5f);
        socket.Emit("PlayerConnected");
    }
	// Update is called once per frame
	void Update () {

        moves();
	}
    void moves()
    {
        mouse = Input.mousePosition;
        mousePos = Camera.main.WorldToScreenPoint(transform.position);
        var target = new Vector2((mouse.x) - (mousePos.x), (mouse.y) - (mousePos.y));
        angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);


        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");


        isWalking = Mathf.Abs(xAxis) != 0f || Mathf.Abs(yAxis) != 0f;
        Vector2 movement = new Vector2(xAxis, yAxis) * vel * Time.deltaTime;
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement);
    }
}
