using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour { 
	public float health = 150;
	public GameObject projectile; 
	public float projectileSpeed;
	public float shotPerSecond = 0.5f;
	public float fireRate;
	public AudioClip fireSound;
	public AudioClip deathSound;
	public int scoreValue = 150;
	private ScoreKeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper> ();
		}

	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (0,-1,0);
		GameObject missile = Instantiate (projectile,startPosition,Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,projectileSpeed,0);
		AudioSource.PlayClipAtPoint (fireSound,transform.position);
	}


	void Update(){
		float probability = Time.deltaTime * shotPerSecond;

	
		if(Random.value<probability){
			Fire ();
		}

	} 

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile){
			health -= missile.GetDamage ();
			missile.Hit ();
			if(health<=0){
				enemyDie (); 
				scoreKeeper.Score (scoreValue);
			}
		}
	}

	void enemyDie(){
		AudioSource.PlayClipAtPoint (deathSound,transform.position);
		Destroy (gameObject);
	}
}
