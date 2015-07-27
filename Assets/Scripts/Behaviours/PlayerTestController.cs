using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Player test controller.
	/// </summary>
	public class PlayerTestController : BaseBehaviour {
		/// <summary>The reticule.</summary>
		public RectTransform reticule;
		/// <summary>The projectile launcher.</summary>
		public OnDemandProjectileLauncher launcher;
		
		protected void Start() {

		}

		protected void Update() {
			this.reticule.position = Input.mousePosition;

			var mousePositionClose = Input.mousePosition;
			mousePositionClose.z = 1.0f;
			var reticulePositionClose = Camera.main.ScreenToWorldPoint(mousePositionClose);

			this.launcher.spawnPosition = this.transform.InverseTransformPoint(reticulePositionClose);

			var mousePositionDistant = Input.mousePosition;
			mousePositionDistant.z = 45.0f;
			var reticulePositionDistant = Camera.main.ScreenToWorldPoint(mousePositionDistant);
			Debug.DrawLine(reticulePositionClose, reticulePositionDistant, Color.red);

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				this.transform.Translate(this.transform.forward);
			}

			if (Input.GetKeyDown(KeyCode.Q)) {
				this.launcher.FireFire(reticulePositionDistant);
			} else if (Input.GetKeyDown(KeyCode.W)) {
				this.launcher.FireIce(reticulePositionDistant);
			} else if (Input.GetKeyDown(KeyCode.E)) {
				this.launcher.FireElectricity(reticulePositionDistant);
			} else if (Input.GetKeyDown(KeyCode.R)) {
				this.launcher.FireLight(reticulePositionDistant);
			}
		}
	}
}
