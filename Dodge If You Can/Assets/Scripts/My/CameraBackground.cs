using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour {
	public Texture2D background;

	void OnGUI () {
		GUI.DrawTexture (new Rect (0, 0, background.width, background.height), background);
	}
}
