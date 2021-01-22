using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDiagnoseContents : MonoBehaviour
{
    public GameObject basic_ui;
    public GameObject content_ui;

    public int pre_button = -1;

    public void OnContentsButtonClicked(int index)
    {
        if(pre_button == index)
        {
            content_ui.SetActive(false);
            basic_ui.GetComponent<Transform>().position = Vector3.zero;
            InitFlags();
            Debug.Log("pre_button == index, " + index);
        }

        content_ui.SetActive(true);
        basic_ui.GetComponent<Transform>().position = Vector3.up;
        pre_button = index;
    }

    public void InitFlags()
    {
        pre_button = -1;
    }
}
