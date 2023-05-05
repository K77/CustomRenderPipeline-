using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 100)]
	int resolution = 10;

	Transform[] points;
	
	void Awake()
	{
		points = new Transform[resolution];
		float step = 2f / resolution;
		var position = Vector3.zero;
		var scale = Vector3.one * step;
		for (int i = 0; i < resolution; i++)
		{
			Transform point = Instantiate(pointPrefab);
			points[i] = point;
			position.x = (i + 0.5f) * step - 1f;
			// position.y = position.x * position.x;
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
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
			point.localPosition = position;
		}
	}
}

