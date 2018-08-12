﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos() {
        float verticalHeightSeen = Camera.main.orthographicSize * 2.0f;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3((verticalHeightSeen * Camera.main.aspect), verticalHeightSeen, 0));
    }
}
