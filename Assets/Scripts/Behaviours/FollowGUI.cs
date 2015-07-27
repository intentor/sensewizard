using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Makes a GUI follows a game object on the screen.
	/// </summary>
	public class FollowGUI : BaseBehaviour {
		/// <summary>Target.</summary>
		public Transform target;

		protected void LateUpdate() {
			this.transform.position = Camera.main.WorldToScreenPoint(this.target.position);
		}
	}
}