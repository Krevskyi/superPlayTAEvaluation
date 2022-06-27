using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformResetter : MonoBehaviour
{
    private Vector3 positionCache;
    private Vector3 rotationCache;
    private Vector3 scaleCache;

    void Awake()
    {
        positionCache = transform.position;
        rotationCache = transform.eulerAngles;
        scaleCache = transform.localScale;
    }

    public void ResetTransform()
    {
        transform.position = positionCache;
        transform.eulerAngles = rotationCache;
        transform.localScale = scaleCache;
    }
}
