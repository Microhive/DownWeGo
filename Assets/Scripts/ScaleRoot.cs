using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRoot : MonoBehaviour
{
    public Transform target;
    public Vector3 newScale = new Vector3(0.2f, 0.2f, 1f);
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed * Time.deltaTime);
    }
}
