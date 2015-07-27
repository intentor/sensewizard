using UnityEngine;
using System.Collections;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Detects where the player is and make the enemy ready.
	/// </summary>
	[RequireComponent(typeof(Animator))]
	public class DetectPlayer : BaseBehaviour {
		/// <summary>The distance to activate the enemy.</summary>
		public float distanceToActivate = 5.0f;
		
		/// <summary>Projectile launcher.</summary>
		protected DirectedProjectileLauncher projectileLauncher;
		/// <summary>Player's transform.</summary>
		protected Transform player;
		/// <summary>Indicate whether the enemy is ready.</summary>
		protected bool ready;

		protected void Start () {
			this.projectileLauncher = this.GetComponent<DirectedProjectileLauncher>();
			if (this.projectileLauncher != null) {
				this.projectileLauncher.enabled = false;
			}

			this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			this.ready = false;
		}

		protected void Update () {
			if (this.ready) {
				this.transform.LookAt(this.player);
			} else if (Physics.Raycast(this.transform.position, this.player.position - this.transform.position, this.distanceToActivate)) {
				this.GetComponent<Animator>().SetTrigger("Ready");

				if (this.projectileLauncher != null) {
					this.projectileLauncher.enabled = true;
				}

				this.ready = true;
			}

			//Enemy view.
			Debug.DrawRay(this.transform.position, this.player.position - this.transform.position);
		}
	}
}