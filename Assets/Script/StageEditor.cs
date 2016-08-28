using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class StageEditor : MonoBehaviour {
    public GameObject[] stagePrefabs;
    public GameObject[] entityPrefabs;
    public GameObject editPanel;
    public GameObject buttonObject;
    public GameObject selected;
    public float zoomRate;
    int stageId;
    GameObject stageInLevel;
    List<int> entityId;
    List<GameObject> entityInLevel;

	void Start () {
        entityInLevel = new List<GameObject>();
        entityId = new List<int>();
        Time.timeScale = 0f;
        zoomRate = 5f;
	}

	void Update () {
        moveCamera();
        selectObject();
	}

    void moveCamera() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomRate = Mathf.Clamp(zoomRate - scroll, 1f, 10f);
        Camera.main.orthographicSize = zoomRate;
    }

    void selectObject() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                selected = hit.transform.gameObject;
            }
            else if (!EventSystem.current.IsPointerOverGameObject())
            {
                selected = null;
            }
            editPanel.GetComponent<EditPanel>().onSelected();
        }
    }

    public void setStage(int id)
    {
        if(stageInLevel!=null)Destroy(stageInLevel);
        stageInLevel = (GameObject)Instantiate(stagePrefabs[id]);
        stageId = id;
    }

    public void addEntity(int id)
    {
        entityInLevel.Add((GameObject)Instantiate(entityPrefabs[id]));
        entityId.Add(id);
    }

    public void save() {
        StageInfo stageInfo = new StageInfo(entityInLevel.Count);
        stageInfo.stageId = stageId;
        for (int i = 0; i < entityInLevel.Count ;i++)
        {
            stageInfo.entityInfo[i].id = entityId[i];
            stageInfo.entityInfo[i].serialize(entityInLevel[i]);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/stageInfo.dat");
        formatter.Serialize(file, stageInfo);
        file.Close();
    }
    public void load()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/stageInfo.dat", FileMode.Open);
        StageInfo stageInfo = (StageInfo)formatter.Deserialize(file);
        file.Close();
        //destroy old objects
        if(stageInLevel)Destroy(stageInLevel);
        foreach(GameObject entity in entityInLevel){
            Destroy(entity);
        }
        entityId.Clear();
        entityInLevel.Clear();
        //create loaded stage
        stageId = stageInfo.stageId;
        stageInLevel = (GameObject)Instantiate(stagePrefabs[stageInfo.stageId], transform);
        for (int i = 0; i < stageInfo.entityInfo.Length; i++) {
            int id = stageInfo.entityInfo[i].id;
            entityId.Add(id);
            GameObject newEntity = (GameObject)Instantiate(entityPrefabs[id], transform);
            stageInfo.entityInfo[i].deserialize(newEntity);
            entityInLevel.Add(newEntity);
        }

    }
}
