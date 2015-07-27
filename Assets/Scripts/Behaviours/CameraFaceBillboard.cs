using UnityEngine;
using System.Collections;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Makes the object which it is attached to align itself with the camera.
	/// </summary
	/// <remarks>
	/// Original script from http://wiki.unity3d.com/index.php?title=CameraFacingBillboard.
	/// </remarks>
	[AddComponentMenu("Framework/Modifiers/Camera face billboard")]
	public class CameraFaceBillboard : BaseBehaviour {
		/// <summary>he camera.</summary>
		public new Camera camera;

		/// <summary>The camera transform./summary>
		protected Transform cameraTransform;

		protected override void Awake() {
			base.Awake();

			if (this.camera == null) {
				this.cameraTransform = Camera.main.GetComponent<Transform>();
			} else {
				this.cameraTransform = this.camera.GetComponent<Transform>();
			}
		}
		
		protected void Update() {
			this.transform.LookAt(transform.position + this.cameraTransform.rotation * Vector3.forward,
          		this.cameraTransform.rotation * Vector3.up);
		}
	}
}