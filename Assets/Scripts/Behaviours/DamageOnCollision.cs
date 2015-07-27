using UnityEngine;
using System.Collections;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Deals damage on collision
	/// </summary> 
	public class DamageOnCollision : MonoBehaviour {
		/// <summary>The target tag.</summary>
		public string targetTag = "Player";
		/// <summary>The damage.</summary>
		public int damage = 1;
	
		protected void OnCollisionStay(Collision other) {
			if (other.collider.CompareTag(this.targetTag)) {
				var health = other.collider.GetComponent<Health>();
				health.AddHealth(-this.damage);
			}
		}
	}
}