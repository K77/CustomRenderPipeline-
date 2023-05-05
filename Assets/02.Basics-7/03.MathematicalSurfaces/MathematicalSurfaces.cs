using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalSurfaces : MonoBehaviour
{

	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 100)]
	int resolution = 10;

	Transform[] points;
	
	void Awake()
	{
		points = new Transform[resolution * resolution];
		float step = 2f / resolution;
		var position = Vector3.zero;
		var scale = Vector3.one * step;
		for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
			if (x == resolution) {
				x = 0;
				z += 1;
			}
			Transform point = points[i] = Instantiate(pointPrefab);
			position.x = (x + 0.5f) * step - 1f;
			position.z = (z + 0.5f) * step - 1f;

			point.localPosition = position;
			point.localScale = scale;
		}
	}

	private void Update()
	{
		for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			// position.y = position.x * position.x * position.x;
			position.y = FunctionLibrary.MultiWave3D(position.x,position.z, Time.time);
			point.localPosition = position;
		}
	}
}

