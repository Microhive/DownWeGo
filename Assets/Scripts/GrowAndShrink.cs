using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GrowAndShrink : MonoBehaviour
{
    // Grow parameters
    public int loops = -1;
    public LoopType loopType = LoopType.Yoyo;
    public float growthBound;
    public float shrinkBound;
    public Transform objectToResize;

    // Use t$$anonymous$$s for initialization
    void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        objectToResize.DOScale(growthBound, shrinkBound).SetLoops(loops, loopType);
    }

    public void StopAnimation()
    {
        DOTween.Kill(transform);
    }
}