using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SmoothPositionSync : NetworkBehaviour {

    [SyncVar]
    public Vector3 networkPosition;

    public int smoothFactor = 8;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isServer) {
            networkPosition = transform.position;
            return;
        }
        transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * smoothFactor);
    }
}
