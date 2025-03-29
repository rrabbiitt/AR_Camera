using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{
    public string themeName;

    public void OnButtonClicked(Btn buttonScript)
    {
        themeName = buttonScript.GetVariableData();
    }
}
