using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isTapped = false;
    public float waterAmount = 20f;

    public SpriteRenderer targetSpriteRenderer;
    public Color targetColor = Color.cyan;
    public float tweenDuration = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isTapped)
        {
            isTapped = true;
            targetSpriteRenderer.DOColor(targetColor, tweenDuration);
            collision.gameObject.GetComponent<Head>().AddHealth(waterAmount);
        }
    }
}
