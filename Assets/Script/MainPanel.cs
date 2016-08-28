using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainPanel : MonoBehaviour
{
    public StageEditor stageEditor;

    public GameObject selectPanel;
    public GameObject stagePanel;
    public GameObject entityPanel;

    public GameObject mainButton;
    public GameObject button;

    public void Start() {
        initStagePanel();
        initEntityPanel();
    }

    public void showPanel(string name) { 
        foreach(Transform child in transform)
        {
            if (child.gameObject.name == name)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    void initStagePanel() {
        int stageNum = stageEditor.stagePrefabs.Length;
        for (int i = 0; i < stageNum; i++)
        {
            int id = i;
            GameObject newButton = (GameObject)Instantiate(button, stagePanel.transform);
            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(5 + i * 100, 0);
            Button b = newButton.GetComponent<Button>();
            b.onClick.AddListener(() =>
                stageEditor.setStage(id)
            );
            setButtonText(newButton, stageEditor.stagePrefabs[i].name);

        }
    }

    void initEntityPanel()
    {
        int entityNum = stageEditor.entityPrefabs.Length;
        for (int i = 0; i < entityNum; i++)
        {
            int id = i;
            GameObject newButton = (GameObject)Instantiate(button, entityPanel.transform);
            RectTransform btnRect = newButton.GetComponent<RectTransform>();
            btnRect.anchoredPosition = new Vector2(5 + i * 100, 0);

            Button btn = newButton.GetComponent<Button>();
            btn.onClick.AddListener(() =>
                stageEditor.addEntity(id)
            );
            setButtonText(newButton, stageEditor.entityPrefabs[i].name);
        }
    }

    void setButtonText(GameObject btn, string text) {
        btn.transform.GetChild(0).GetComponent<Text>().text = text;
    }

}
