using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaders : MonoBehaviour
{
    static readonly int
        positionsId = Shader.PropertyToID("_Positions"),
        resolutionId = Shader.PropertyToID("_Resolution"),
        stepId = Shader.PropertyToID("_Step"),
        timeId = Shader.PropertyToID("_Time");
    
    
    
    [SerializeField]
    ComputeShader computeShader;
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;
    ComputeBuffer positionsBuffer;
	
    
    void OnEnable () {
        positionsBuffer = new ComputeBuffer(resolution * resolution, 3 * 4);
    }
    void OnDisable () {
        positionsBuffer.Release();
        positionsBuffer = null;
    }
    void Awake()
    {
        OnEnable();
        
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
    
    void UpdateFunctionOnGPU () {
        float step = 2f / resolution;
        computeShader.SetInt(resolutionId, resolution);
        computeShader.SetFloat(stepId, step);
        computeShader.SetFloat(timeId, Time.time);
    }

    private void Update()
    {
        UpdateFunctionOnGPU();
        // Graphics.DrawMeshInstancedProcedural(mesh, 0, material);
    }
}

