using static UnityEngine.Mathf;
using UnityEngine;

public static class FunctionLibrary
{
    public static float Wave (float x, float t) {
        return Mathf.Sin(Mathf.PI * (x + t));
    }
    public static float MultiWave (float x, float t) {
        float y = Sin(PI * (x + t));
        y += Sin(2f * PI * (x + t)) / 2f;
        return y;
    }
    public static float Ripple (float x, float t) {
        float d = Abs(x);
        return d;
    }
    
    public static float Wave3D (float x, float z,float t) {
        return Sin(PI * (x + z + t));
    }
    public static float MultiWave3D (float x,float z, float t) {
        float y = Sin(PI * (x + 0.5f * t));
        y += 0.5f * Sin(2f * PI * (z + t));
        return y * (2f / 3f);
    }
    public static float Ripple3D (float x,float z, float t) {
        float d = Abs(x);
        return d;
    }
}
