using UnityEngine;
using System.Collections;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Despawns a particle system when it's not alive.
	/// </summary>
	[RequireComponent(typeof(Renderer))]
	public class DespawnOnInvisible : MonoBehaviour {
		/// <summary>The object to despawn.</summary>
		public Transform objectToDespawn;
		/// <summary>The name of the pool.</summary>
		public string poolName;
		
		protected void Start() {
			if (this.objectToDespawn == null) {
				this.objectToDespawn = this.transform;
			}
		}

		protected void OnBecameInvisible() {
			if (!this.enabled) return;
			
			PoolManager.Pools[this.poolName].Despawn(this.objectToDespawn);
		}
	}
}