using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	public int alpha = 5;
	public int beta = 5;

	public float speed = 5;
	public float attackFrequency = 1;
	private float nextAttack;

	/* ATTRIBUTES
	 * 
	 * movement speed +a
	 * action frequency +a
	 * action speed (duration until attack lands) +b
	 * action range +b
	 * fear of opponent +b
	 * rage towards opponent +a
	 * chance of attack landing +a
	 * availability of actions +b
	 * choice of actions
	 */
	
	/* ACTIONS
	 * 
	 * Attack
	 * Intimidate +a (lowers attack frequency)
	 * Taunt +b (lowers defense)
	 * Defend +b (raises defense)
	 * Bully +a (lowers defense)
	 * Appreciate +b (lowers attack)
	 * Cheat +a (affects environment)
	 * Run +b (runs from opponent)
	 */

	/* WEAPONS
	 * 
	 * whiffle ball bat 
	 * pillow
	 */

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");
		Transform player2Transform = player2.transform;
		transform.position = Vector2.MoveTowards (transform.position, player2Transform.position, speed * Time.deltaTime);

		float nextAttack = Time.time + attackFrequency;
	}
}
