using System;
using UnityEngine;
using System.Collections;
using TDC.TripeAGame.Util;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Makes a game object acts like a ragdoll.
	/// 
	/// The ragdoll is enabled when the script is enabled.
	/// </summary>
	[AddComponentMenu("Framework/Modifiers/Ragdoll")]
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class Ragdoll : MonoBehaviour {
		protected void Start() {
			RagdollUtils.DisableRagdoll(this.gameObject);
		}

		/// <summary>
		/// Enables the ragdoll.
		/// </summary>
		public void EnableRagdoll() {
			RagdollUtils.EnableRagdoll(this.gameObject, true);
		}
		
		/// <summary>
		/// Disables the ragdoll.
		/// </summary>
		public void DisableRagdoll() {
			RagdollUtils.EnableRagdoll(this.gameObject, false);
		}
	}
}
