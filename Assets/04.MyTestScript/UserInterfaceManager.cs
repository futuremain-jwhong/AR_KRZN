using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    public List<Canvas> canvas;

    public List<List<GameObject>> data_set_in_canvas = new List<List<GameObject>>();

    private enum DataPanelType { temp, vib, speed };

    private void Start()
    {
        foreach(Canvas c in canvas)
        {
            string name = c.gameObject.name;
            List<GameObject> data_set = new List<GameObject>();

            if(c.transform.childCount < 2)
            {
                data_set.Add(null);
                continue;
            }

            for(int i = 0; i < c.transform.childCount - 1; i++)
            {
                data_set.Add(c.transform.GetChild(i).gameObject);
            }

            data_set_in_canvas.Add(data_set);
        }
    }

    public void LoadPointDataPanel(int index, Transform tr)
    {
        canvas[index].gameObject.SetActive(true);
        canvas[index].transform.position = tr.position + Vector3.up * 1.05f;
        //data_set_in_canvas[index][(int)DataPanelType.temp].SetActive(true);
    }
}
