using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDCA : MonoBehaviour {
	private bool showPDCA;

	void OnGUI() {
		showPDCA = GUI.Toggle(new Rect(10, 10, 200, 30), showPDCA, "PDCA");

		transform.localScale = (showPDCA) ? new Vector3(1.0f, 1.0f, 1.0f) : new Vector3(0.0f, 0.0f, 0.0f);
	}
}
