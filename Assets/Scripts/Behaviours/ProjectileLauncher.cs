using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Makes a game object fires projectiles.
	/// </summary>
	public class ProjectileLauncher : MonoBehaviour {
		/// <summary>Projectile's spawn local position.</summary>
		public Vector3 spawnPosition = new Vector3(1.0f, 0, 0);
		/// <summary>The name of the pool.</summary>
		public string poolName = "Projectiles";
		/// <summary>The target tag for the projectiles.</summary>
		public string targetTag = "Enemy";

		/// <summary>
		/// Fire a specified projectile.
		/// </summary>
		/// <param name="projectile">Projectile.</param>
		/// <param name="lookAt">Look at direction.</param>
		protected void Fire(Transform projectile, Vector3 lookAt) {
			projectile.position = this.transform.TransformPoint(this.spawnPosition);
			var component = projectile.GetComponent<Projectile>();
			component.targetTag = this.targetTag;
			component.targetPosition = lookAt;

			var particles = projectile.GetComponent<ParticleSystem>();
			particles.Clear(true);
			particles.Play(true);
		}
	}
}