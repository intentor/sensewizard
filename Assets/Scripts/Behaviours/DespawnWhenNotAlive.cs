using UnityEngine;
using System.Collections;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Despawns a particle system when it's not alive.
	/// </summary>
	[RequireComponent(typeof(ParticleSystem))]
	public class DespawnWhenNotAlive : MonoBehaviour {
		/// <summary>The name of the pool.</summary>
		public string poolName;

		/// <summary>The particle system.</summary>
		protected ParticleSystem particles;

		protected void Awake() {
			this.particles = this.GetComponent<ParticleSystem>();
		}

		public void OnSpawned() {
			this.particles.Clear(true);
			this.particles.Play(true);
			this.StartCoroutine("CheckIfAlive");
		}

		/// <summary>
		/// Checks whether the particle system is alive.
		/// </summary>
		protected IEnumerator CheckIfAlive() {
			while(true) {
				yield return new WaitForSeconds(0.5f);

				if (!this.particles.IsAlive(true)) {
					PoolManager.Pools[this.poolName].Despawn(this.GetComponent<Transform>());
					break;
				}
			}
		}
	}
}