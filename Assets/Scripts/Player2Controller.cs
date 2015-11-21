using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour {

	public int alpha = 5;
	public int beta = 5;

	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player1 = GameObject.FindGameObjectWithTag ("Player1");
		Transform player1Transform = player1.transform;
//		transform.position = Vector2.MoveTowards (transform.position, player1Transform.position, speed * Time.deltaTime);
	}
}
