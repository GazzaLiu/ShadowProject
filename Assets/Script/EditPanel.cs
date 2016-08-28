using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditPanel : MonoBehaviour {
    public StageEditor stageEditor;
    public InputField posXText;
    public InputField posYText;
    public InputField chargeText;

    void Start()
    {
        posXText.DeactivateInputField();
        posYText.DeactivateInputField();
        chargeText.DeactivateInputField();
        
    }

    public void onSelected()
    {
        GameObject selected = stageEditor.selected;
        if (selected!=null)
        {
            posXText.text = selected.transform.position.x.ToString();
            posYText.text = selected.transform.position.y.ToString();
            posXText.ActivateInputField();
            posYText.ActivateInputField();
            Entity entity = selected.GetComponent<Entity>();
            if(entity){
                chargeText.text = entity.charge.ToString(); 
                chargeText.ActivateInputField();
            }
        }
        else
        {
            posXText.text = "";
            posYText.text = "";
            chargeText.text = "";
            posXText.DeactivateInputField();
            posYText.DeactivateInputField();
            chargeText.DeactivateInputField();
        }

    }

    public void setObject()
    {
        GameObject selected = stageEditor.selected;
        if (selected)
        {
            selected.transform.position = new Vector3(float.Parse(posXText.text), float.Parse(posYText.text), 0f);
            Entity entity = selected.GetComponent<Entity>();
            if (entity) { 
                entity.charge = float.Parse(chargeText.text);
            }
        }
    }

    public void deleteObject()
    {
        GameObject selected = stageEditor.selected;
        if (selected)
        {
            Destroy(selected);
        }
    }

}
