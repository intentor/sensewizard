using UnityEngine;
using System.Collections;
using TDC.TripeAGame.Constants;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Projectile.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(DespawnWhenNotAlive))]
	public class Projectile : BaseBehaviour {
		/// <summary>The type of the projectile.</summary>
		public ProjectileType projectileType;
		/// <summary>The target tag.</summary>
		public string targetTag;
		/// <summary>The target position.</summary>
		public Vector3 targetPosition;
		/// <summary>The speed.</summary>
		public float speed = 2.0f;
		/// <summary>The damage.</summary>
		public int damage = 1;
		/// <summary>The pool name.</summary>
		public string poolName = "Projectiles";
		/// <summary>Projectile lifetime (seconds).</summary>
		public int lifetime = 5;

		/// <summary>The despawn counter coroutine.</summary>
		protected float counter;
		/// <summary>The despawn counter coroutine.</summary>
		protected Coroutine despawn;
		/// <summary>Indicates the projectile has been used.</summary>
		protected bool used;
		/// <summary>The direction of the movement.</summary>
		protected Vector3 direction;

		protected void Start() {
			this.GetComponent<DespawnWhenNotAlive>().poolName = this.poolName;
		}

		public void OnSpawned() {
			this.direction = Vector3.zero;
			this.used = false;
			this.despawn = this.StartCoroutine(this.CheckLifetime());
		}

		public void OnDespawned() {
			if (this.despawn != null) {
				this.StopCoroutine(this.despawn);
			}
		}
		
		protected void OnCollisionEnter(Collision collision) {
			Debug.Log(collision);
		}

		protected void OnTriggerEnter(Collider other) {
			if (this.used) return;

			this.used = true;

			if (other.CompareTag(this.targetTag)) {
				var health = other.GetComponent<Health>();

				if (health != null) {
					if (health.weakness == this.projectileType) {
						//Critical.
						var particles = PoolManager.Pools[PoolName.PARTICLES].Spawn("Critical");
						particles.position = this.transform.position;
						health.AddHealth(-health.health);
					} else {
						//Regular.
						health.AddHealth(-this.damage);
					}
				}
			}

			//Spawn a hit particle.
			var hit = PoolManager.Pools["Particles"].Spawn("Hit");
			hit.position = this.transform.position;

			//Stops the particle system. It'll be despawned through another script.
			this.GetComponent<ParticleSystem>().Stop(true);
		}

		protected void Update() {
			Debug.DrawRay(this.transform.position, this.transform.forward * 5.0f, Color.blue);

			if (this.used) return;

			if (this.direction == Vector3.zero) {
				this.direction = this.targetPosition - this.transform.position;
				this.direction.Normalize();
			}

			this.transform.Translate(this.direction * this.speed * Time.deltaTime, Space.World);
		}

		protected IEnumerator CheckLifetime() {
			this.counter = 0;

			while (true) {
				yield return new WaitForSeconds(1.0f);
				this.counter += 1;

				if (counter >= this.lifetime) {
					//Stops the particle system. It'll be despawned through another script.
					this.GetComponent<ParticleSystem>().Stop(true);
					break;
				}
			}
		}
	}
}