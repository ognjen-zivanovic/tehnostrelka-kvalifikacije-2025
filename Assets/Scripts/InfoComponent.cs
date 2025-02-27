using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoComponent : MonoBehaviour
{
    public string nameString;
    
    [TextArea(2, 2)]
    public string descriptionString;

    public void SetValues() {
        GameObject uiManager = GameObject.FindGameObjectWithTag("UIManager");
        uiManager.GetComponent<UIManager>().SetValues(nameString, descriptionString);
    }

}
