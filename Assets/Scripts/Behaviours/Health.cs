using UnityEngine;
using System.Collections;
using PathologicalGames;
using TDC.TripeAGame.Constants;
using UnityEngine.UI;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Provides health.
	/// </summary>
	public class Health : BaseBehaviour {
		/// <summary>The health.</summary>
		public int health = 1;
		/// <summary>The weakness.</summary>
		public ProjectileType weakness;
		/// <summary>The health slider.</summary>
		public Image healthSlider;
		/// <summary>The shaker.</summary>
		public GameObjectShaker shaker;

		/// <summary>The total health.</summary>
		protected float totalHealth;
		/// <summary>The health slider transform.</summary>
		protected Transform healtSliderTransform;

		protected void Start() {
			this.totalHealth = this.health;
			this.healtSliderTransform = this.healthSlider.GetComponent<Transform>();
		}

		protected void Update() {
			this.healtSliderTransform.localScale = new Vector3(this.health / this.totalHealth, 1.0f, 1.0f);
		}

		/// <summary>
		/// Adds a health value
		/// </summary>
		/// <param name="value">Value.</param>
		public void AddHealth(int value) {
			if (this.health <= 0) return;

			this.health += value;

			if (value < 0 && this.shaker != null) {
				this.shaker.Shake();
			}
			
			if (this.health <= 0) {
				this.healtSliderTransform.parent.gameObject.SetActive(false);

				if (this.CompareTag("Player")) {
					GameObject.Find("DeadView").GetComponent<CanvasGroup>().alpha = 1.0f;
					var rigidbody = this.GetComponent<Rigidbody>();
					rigidbody.useGravity = true;
					rigidbody.isKinematic = false;
				} else {
					this.GetComponent<Animator>().SetTrigger("Die");
					this.Invoke("DestroyThis", 1.5f);
				}
			}
		}

		/// <summary>
		/// Destroies this game object.
		/// </summary>
		protected void DestroyThis() {
			var particles = PoolManager.Pools[PoolName.PARTICLES].Spawn("EnemyDead");
			particles.position = this.transform.position;
			Destroy(this.gameObject);
		}
	}
}