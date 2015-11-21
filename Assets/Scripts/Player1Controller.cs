using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	public float alpha = 5;
	public float beta = 5;

	public float speed = 5;					//a
	public float attackFrequency = .5f;		//a
	public float attackDuration = 1;		//b
	public float attackRange = 2;			//b
	public float moveTowards = 5;			//a

	public MonoBehaviour PlayerBehavior;

	private float nextInput;
	private float inputCooldown = 5;

	private float nextAttack;
	private bool isAttacking;

	private float nextMoveDecision;
	private float moveDecisionFrequency = .3f;
	private bool moveTowardsPlayer;

	/* ATTRIBUTES
	 * rage towards opponent +a
	 * chance of attack landing +a
	 * availability of actions +b
	 * choice of actions
	 */
	
	/* ACTIONS
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
	 * whiffle ball bat 
	 * pillow
	 */
	
	void Start () {
	}

	void BeginAttack () {
		nextAttack = Time.time + attackFrequency;
		isAttacking = true;
	}
	
	void EndAttack () {
		isAttacking = false;
	}

	void makeMoveDecision () {
		nextMoveDecision = Time.time + moveDecisionFrequency;
		float moveChance = Random.Range (moveTowards, 11);
		
		if (moveChance > 7) {
			moveTowardsPlayer = true;
		} else {
			moveTowardsPlayer = false;
		}
	}

	void handlePlayerInput () {
		if (Input.GetButton ("Fire3")) {
			nextInput = Time.time + inputCooldown;
			print ("speed up");
			speed += 1;
		}
	}

	void Update () {
		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");
		
		if (!player2) {
			return;
		}
		
		Transform player2Transform = player2.transform;

		if (moveTowardsPlayer) {
			transform.position = Vector2.MoveTowards (transform.position, player2Transform.position, speed * Time.deltaTime);
		} else {
			Vector2 player2Position = player2Transform.position;
			player2Position.x = -player2Position.x;
			transform.position = Vector2.MoveTowards (transform.position, player2Position, speed * Time.deltaTime);
		}
		
		if (isAttacking) {
			float playerDistance = Vector2.Distance (player2Transform.position, transform.position);
			if (playerDistance <= attackRange) {
				GameObject.Destroy(player2);
				print ("hit!");
			}
		}

		if (Time.time > nextMoveDecision) {
			makeMoveDecision ();
		}
		
		if (Time.time > nextAttack) {
			BeginAttack ();
		} else if (Time.time > nextAttack - attackDuration * Time.time) {
			EndAttack ();
		}

		if (Time.time > nextInput && Input.anyKey) {
			handlePlayerInput ();
		}
	}
}
