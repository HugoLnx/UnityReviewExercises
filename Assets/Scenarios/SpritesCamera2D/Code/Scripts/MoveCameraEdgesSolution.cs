using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MoveCameraEdgesSolution : MonoBehaviour
{
    private const float AspectRatio = 16f/9f;
    private const float ScreenHeight = 5.4f;
    private const float ScreenWidth = ScreenHeight * AspectRatio;
    private Vector2 ScreenSize => new(ScreenWidth, ScreenHeight);

    private void Update()
    {
        Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position = input * ScreenSize / 2f;
    }
}