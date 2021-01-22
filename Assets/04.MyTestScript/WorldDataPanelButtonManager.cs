using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldDataPanelButtonManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();

    public int pre_button_index = -1;

    public List<GameObject> data_panels = new List<GameObject>();

    public void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
        }

        for(int i = 1; i < transform.parent.childCount - 1; i++)
        {
            data_panels.Add(transform.parent.GetChild(i).gameObject);
        }
    }

    public void OnButtonClicked(int index)
    {
        if(pre_button_index != -1)
        {
            data_panels[pre_button_index].SetActive(false);

            if (pre_button_index == index)
            {
                InitFlags();
                return;
            }
        }

        data_panels[index].SetActive(true);
        pre_button_index = index;
    }

    private void InitFlags()
    {
        pre_button_index = -1;
    }
}
