using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public static float ScrollX = 0.5f;
    public static float ScrollY = 0f;

    void Update() {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (OffsetX, OffsetY);
    }
}
