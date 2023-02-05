using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject startPosition;
    public GameObject endPosition;
    public float ratio = 1f;

    public float depth;

    private void FixedUpdate()
    {
        var difference = startPosition.transform.position - endPosition.transform.position;
        var differenceY = Mathf.Abs(difference.y);
        var final = differenceY * ratio;

        this.depth = final;

        text.text = string.Format("{0:0.0}", final) + "cm";
    }
}
