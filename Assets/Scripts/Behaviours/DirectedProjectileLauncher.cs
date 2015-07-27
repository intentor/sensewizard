using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Makes a game object fires directed projectiles.
	/// </summary>
	[RequireComponent(typeof(Animator))]
	public class DirectedProjectileLauncher : ProjectileLauncher {
		/// <summary>Projectile prefab.</summary>
		public List<Transform> projectiles;
		/// <summary>The fire interval.</summary>
		public float fireInterval = 2.0f;
		/// <summary>The wait interval between calling the animation and firing.</summary>
		public float waitInterval = 1.5f;
		/// <summary>Indicates whether the fire should be continuous.</summary>
		public bool continuousFire = true;
		
		/// <summary>The continuous fire coroutine.</summary>
		protected Coroutine fireCoroutine;
		/// <summary>The target transform.</summary>
		protected Transform target;
		/// <summary>The current.</summary>
		protected Animator animator;
		
		/// <summary>
		/// The index of the projectile to be fired.
		/// </summary>
		protected int projectileIndex;
		
		public void Start() {
			this.projectileIndex = 0;
			this.target = GameObject.FindGameObjectWithTag(this.targetTag).GetComponent<Transform>().FindChild("Camera");
			this.animator = this.GetComponent<Animator>();
		}

		protected void OnEnable() {
			this.fireCoroutine = this.StartCoroutine(this.ContinuousFire());
		}
		
		protected void OnDisable() {
			if (this.fireCoroutine != null) {
				this.StopCoroutine(this.fireCoroutine);
			}
		}
		
		/// <summary>
		/// Continuous fire.
		/// </summary>
		/// <returns>The fire.</returns>
		protected IEnumerator ContinuousFire() {
			while (true) {
				yield return new WaitForSeconds(this.fireInterval);

				if (this.projectiles == null || this.projectiles.Count == 0) break;
				if (this.projectileIndex >= this.projectiles.Count) this.projectileIndex = 0;

				this.animator.SetTrigger("Attack");

				yield return new WaitForSeconds(this.waitInterval);

				var projectile = PoolManager.Pools[this.poolName].Spawn(this.projectiles[this.projectileIndex++]);
				this.Fire(projectile, this.target.position);
			}
		}
	}
}