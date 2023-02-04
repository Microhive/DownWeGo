using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollowHead : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float transitionDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
    }

    void moveCamera()
    {
        Vector3 position = transform.position;
        position.y = (player.position + offset).y;
        transform.position = position;

        this.GetComponent<Camera>().transform.DOMoveY(position.y, transitionDuration);
    }
}
