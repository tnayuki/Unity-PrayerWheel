﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour {
	public bool down = false;
	public float limit = 10.0f;
	public TMPro.TextMeshProUGUI text;

	private float _inertia = 0.0f;
	private float _prevX;
	private float _prevY;
	private Vector2 _delta = new Vector2(0.0f, 0.0f);

	private float rotatedAngles = 0.0f;
	
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			_delta.x = 0.0f;
			_delta.y = 0.0f;

			_prevX = Input.mousePosition.x;

			down = true;
		}
		
		if (Input.GetMouseButtonUp(0)) {
			down = false;
			
			if (_delta.magnitude > 8.0f) {
				float v = Mathf.Clamp(_delta.sqrMagnitude, 0.0f, limit);
				_delta.Normalize();
				_delta *= v;
				_inertia = 1.0f;
			}
		}
		
		if (down) {
			_delta.x = _prevX - Input.mousePosition.x;
			_prevX = Input.mousePosition.x;

			transform.Rotate(new Vector3(0.0f, _delta.x, 0.0f), Space.World);

			if (_delta.x > 0.0f) {
				rotatedAngles += _delta.x;
			}
		} else if(_inertia >= 0.0f) {
			_inertia *= 0.97f;
			
			if (_inertia > 0.05f) {
				transform.Rotate(new Vector3(0.0f, _delta.x * _inertia, 0.0f), Space.World);

				if (_delta.x > 0.0f) {
					rotatedAngles += _delta.x * _inertia;
				}
			} else {
				_inertia = 0.0f;
			}
		}

		text.text = Mathf.Round(rotatedAngles / 360.0f) + " Toku";
	}
}
