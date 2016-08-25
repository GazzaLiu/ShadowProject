using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class StageInfo{
	ObjectInfo[] objInfoes;	
}
public struct ObjectInfo {
	string name;
	Vector3 pos;
}
[System.Serializable]
public struct StagePrefabs {
	public string name;
	public GameObject prfab;
}

public class Manager : MonoBehaviour {
	public StagePrefabs[] dictionary;
	StageInfo[] stageinfoes;
	StageInfo[] stageRecord;
	GameObject player;
	int state;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
