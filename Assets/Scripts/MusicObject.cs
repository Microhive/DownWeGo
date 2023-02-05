using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    public static string MusicTag = "Music";

    // Update is called once per frame
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(MusicTag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
