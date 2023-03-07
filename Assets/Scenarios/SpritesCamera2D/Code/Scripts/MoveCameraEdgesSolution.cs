using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MoveCameraEdgesSolution : MonoBehaviour
{
    private const float AspectRatio = 16f/9f;
    private const float CameraHeight = 2.7f;
    private const float CameraWidth = CameraHeight * AspectRatio;
    [Button]
    public void MoveUp()
    {
        transform.position = Vector3.up * CameraHeight;
    }
    [Button]
    public void MoveDown()
    {
        transform.position = Vector3.down * CameraHeight;
    }

    [Button]
    public void MoveRight()
    {
        transform.position = Vector3.right * CameraWidth;
    }
    [Button]
    public void MoveLeft()
    {
        transform.position = Vector3.left * CameraWidth;
    }
    [Button]
    public void MoveCenter()
    {
        transform.position = Vector3.zero;
    }
}