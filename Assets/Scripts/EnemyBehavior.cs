using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150;

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		Debug.Log (collider);
		if (missile){
			health -= missile.GetDamage ();
			missile.Hit ();
			if(health<=0){
				Destroy (gameObject);
			}
			Debug.Log ("hit by missile");
		}
	}
}
