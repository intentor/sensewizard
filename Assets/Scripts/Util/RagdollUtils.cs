using UnityEngine;

namespace TDC.TripeAGame.Util {
	/// <summary>
	/// Ragdoll utils.
	/// </summary>
	public static class RagdollUtils {
		/// <summary>
		/// Enables the ragdool.
		/// </summary>
		/// <remarks>
		/// The GameObject must have a Collider and a Rigidbody.
		/// </remarks>
		/// <param name="enable">If set to <c>true</c> enable.</param>
		public static void EnableRagdoll(GameObject gameObject, bool enable) {
			var bones = gameObject.GetComponentsInChildren<Rigidbody>();
			
			for (var boneIndex = 0; boneIndex < bones.Length; boneIndex++) {
				var bone = bones[boneIndex];
				var collider = bone.GetComponent<Collider>();
				if (collider != null) {
					collider.enabled = enable;
				}
				bone.isKinematic = !enable;
				bone.mass = (enable ? 0.1f : 0.01f);
			}
			gameObject.GetComponent<Collider>().enabled = !enable;
			
			var rigidbody = gameObject.GetComponent<Rigidbody>();
			if (enable) {
				rigidbody.useGravity = false;
				rigidbody.isKinematic = true;
			} else {
				rigidbody.mass = 1.0f;
				rigidbody.useGravity = true;
				rigidbody.isKinematic = false;
			}

			var animators = gameObject.GetComponentsInChildren<Animator>();
			for (var animatorIndex = 0; animatorIndex < animators.Length; animatorIndex++) {
				animators[animatorIndex].enabled = !enable;
			}
		}

		/// <summary>
		/// Disables the ragdoll structure in a game object.
		/// </summary>
		/// <remarks>
		/// The GameObject must have a Collider and a Rigidbody.
		/// It's used to prevent unwanted movement in rigged characters.
		/// </remarks>
		public static void DisableRagdoll(GameObject gameObject) {
			var collider = gameObject.GetComponent<Collider>();
			var bones = gameObject.GetComponentsInChildren<Rigidbody>();
			foreach (var ragdoll in bones) {
				if (ragdoll.GetComponent<Collider>() && ragdoll.GetComponent<Collider>() != collider){
					ragdoll.GetComponent<Collider>().enabled = false;
					ragdoll.isKinematic = true;
					ragdoll.mass = 0.01f;
				}
			}

			//Enable the collider in the game object.
			collider.enabled = true;
		}
	}
}