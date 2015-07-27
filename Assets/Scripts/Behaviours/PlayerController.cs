using System;
using UnityEngine;
using UnityEngine.UI;
using TDC.TripeAGame.Constants;
using System.Collections;
using RSUnityToolkit;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Player controller.
	/// </summary>
	public class PlayerController : BaseBehaviour {
		/// <summary>The reticule.</summary>
		public RectTransform reticule;
		/// <summary>The projectile launcher.</summary>
		public OnDemandProjectileLauncher launcher;
		/// <summary>The transform follow.</summary>
		public Transform follow;
		/// <summary>The transform follow.</summary>
		public float fireDistance = 0.5f;
		/// <summary>Fire interval.</summary>
		public float fireInterval = 1.0f;
		/// <summary>The spawn distance.</summary>
		public float spawnDistance = 5.0f;
		/// <summary>The current projectile type.</summary>
		public ProjectileType currentProjectile;
		/// <summary>The wheel element.</summary>
		public Animator wheel;

		/// <summary>
		/// The start follow.
		/// </summary>
		protected float startFollow;

		protected Coroutine fire;

		public void HandDetected(Trigger value) {
			this.fire = this.StartCoroutine(this.CheckFire());
			this.reticule.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			this.startFollow = this.follow.position.z;
		}

		public void HandLost(Trigger value) {
			this.StopCoroutine (this.fire);
			this.reticule.localScale = Vector3.zero;
		}
		
		public void SelectFire(Trigger value) {
			this.currentProjectile = ProjectileType.Fire;
			this.wheel.SetTrigger ("Fire");
			Debug.Log("Change element: " + this.currentProjectile.ToString());
		}
		
		public void SelectIce(Trigger value) {
			this.currentProjectile = ProjectileType.Ice;
			this.wheel.SetTrigger ("Ice");
			Debug.Log("Change element: " + this.currentProjectile.ToString());
		}
		
		public void SelectElectricity(Trigger value) {
			this.currentProjectile = ProjectileType.Electricity;
			this.wheel.SetTrigger ("Energy");
			Debug.Log("Change element: " + this.currentProjectile.ToString());
		}
		
		public void SelectLight(Trigger value) {
			this.currentProjectile = ProjectileType.Light;
			this.wheel.SetTrigger ("Light");
			Debug.Log("Change element: " + this.currentProjectile.ToString());
		}

		protected void Start() {
			this.reticule.localScale = Vector3.zero;
		}

		protected IEnumerator CheckFire() {
			while (true) {
				var mousePositionClose = this.reticule.position;
				mousePositionClose.z = this.spawnDistance;
				var reticulePositionClose = Camera.main.ScreenToWorldPoint (mousePositionClose);
				
				this.launcher.spawnPosition = this.transform.InverseTransformPoint(reticulePositionClose);
				
				var mousePositionDistant = this.reticule.position;
				mousePositionDistant.z = 45.0f;
				var reticulePositionDistant = Camera.main.ScreenToWorldPoint (mousePositionDistant);
				Debug.DrawLine (reticulePositionClose, reticulePositionDistant, Color.red);

				if (this.reticule.localScale != Vector3.zero &&
				    //this.follow.position.z - this.startFollow  > this.fireDistance) {
				    Mathf.Abs(this.follow.position.z - this.transform.position.z) < this.fireDistance) {
					switch (this.currentProjectile) {
						case ProjectileType.Fire:
							this.launcher.FireFire (reticulePositionDistant);
							break;
						case ProjectileType.Ice:
							this.launcher.FireIce (reticulePositionDistant);
							break;
						case ProjectileType.Electricity:
							this.launcher.FireElectricity (reticulePositionDistant);
							break;
						case ProjectileType.Light:
							this.launcher.FireLight (reticulePositionDistant);
							break;
					}

					yield return new WaitForSeconds(this.fireInterval);
				}

				yield return null;
			}
		}

		protected void Update() {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				this.transform.Translate (this.transform.forward);
			}
		}
	}
}