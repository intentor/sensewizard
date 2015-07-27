using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Base behaviour.
	/// </summary>
	public class BaseBehaviour : MonoBehaviour {
		/// <summary>The transform.</summary>
		protected new Transform transform;
		
		protected virtual void Awake() {
			this.transform = this.GetComponent<Transform>();
		}
	}
}
