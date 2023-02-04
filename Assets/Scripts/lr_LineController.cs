using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<Transform> points;
    public GameObject headRoot;
    public GameObject tailRoot;
    public GameObject rootPrefab;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        points = new List<Transform>
        {
            tailRoot.transform,
            headRoot.transform
        };
    }

    //public void SetUpLine(Transform[] points)
    //{
    //    lr.positionCount = points.Length;
    //    this.points = points.;
    //}

    void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    public void AddPointToLine()
    {
        GameObject gameObject1 = GameObject.Instantiate(rootPrefab, lr.GetPosition(points.Count - 1), Quaternion.identity);

        this.points.Insert(this.points.Count - 1, gameObject1.transform);
        lr.positionCount = points.Count;
    }
}