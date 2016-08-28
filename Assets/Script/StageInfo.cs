using UnityEngine;
using System.Collections;

[System.Serializable]
public class StageInfo
{
    [System.Serializable]
    public struct EntityInfo
    {
        public int id;
        public float x;
        public float y;
        public float z;
        public float charge;
        public void serialize(GameObject gameObject) {
            x = gameObject.transform.position.x;
            y = gameObject.transform.position.y;
            z = gameObject.transform.position.z;
            charge = gameObject.GetComponent<Entity>().charge;
        }
        public void deserialize(GameObject gameObject) {
            gameObject.transform.position = new Vector3(x, y, z);
            gameObject.GetComponent<Entity>().charge = charge;

        }
    };
    public int stageId;
    public EntityInfo[] entityInfo;

    public StageInfo(int size) {
        entityInfo = new EntityInfo[size];
    }
}
