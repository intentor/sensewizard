using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Fires a projectile on demand.
	/// </summary>
	public class OnDemandProjectileLauncher : ProjectileLauncher {
		/// <summary>
		/// Fires a Fire projectile.
		/// </summary>
		public void FireFire(Vector3 lookAt) {
			var projectile = PoolManager.Pools[this.poolName].Spawn("Fire");
			this.Fire(projectile, lookAt);
		}

		/// <summary>
		/// Fires an Ice projectile.
		/// </summary>
		public void FireIce(Vector3 lookAt) {
			var projectile = PoolManager.Pools[this.poolName].Spawn("Ice");
			this.Fire(projectile, lookAt);
		}

		/// <summary>
		/// Fires an Electricity projectile.
		/// </summary>
		public void FireElectricity(Vector3 lookAt) {
			var projectile = PoolManager.Pools[this.poolName].Spawn("Electricity");
			this.Fire(projectile, lookAt);
		}

		/// <summary>
		/// Fires an Light projectile.
		/// </summary>
		public void FireLight(Vector3 lookAt) {
			var projectile = PoolManager.Pools[this.poolName].Spawn("Light");
			this.Fire(projectile, lookAt);
		}
	}
}