using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Head : MonoBehaviour
{
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;
    private Vector3 targetPos;
    [SerializeField] private lr_LineController line;
    private bool hasClicked = false;
    public float maxTravelDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Head face click
        if (Input.GetMouseButtonDown(0) && !hasClicked)
        {
            hasClicked = true;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            //this.targetPos = mousePosition;

            var difference = transform.position - mousePosition;
            var direction = difference.normalized;
            var distance = Mathf.Min(maxTravelDistance, difference.magnitude);

            var endPosition = transform.position + -direction * distance;

            this.targetPos = endPosition;

            line.AddPointToLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            hasClicked = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, movespeed * Time.deltaTime);


        // Move head
        //transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
