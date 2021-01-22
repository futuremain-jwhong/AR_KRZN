using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager image_manager;

    [SerializeField]
    private GameObject[] prefabs;

    private Dictionary<string, GameObject> spawned_prefabs = new Dictionary<string, GameObject>();

    private Vector3 init_position = new Vector3(0, 10000, 0);

    public UserInterfaceManager ui_manager;

    private void Awake()
    {
        image_manager = GetComponent<ARTrackedImageManager>();

        foreach(GameObject prefab in prefabs)
        {
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            obj.transform.position = init_position;
            obj.name = prefab.name;
            spawned_prefabs.Add(obj.name, obj);
        }
    }

    private void Start()
    {
        ui_manager = GameObject.Find("UserInterfaceManager").GetComponent<UserInterfaceManager>(); 
    }

    private void OnEnable()
    {
        if(image_manager != null)
        {
            image_manager.trackedImagesChanged += ImagesChanged;
        }
    }

    private void OnDisable()
    {
        if(image_manager != null)
        {
            image_manager.trackedImagesChanged -= ImagesChanged;
        }
    }

    private void ImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage img in args.added)
        {
            UpdateImage(img);
        }
        foreach (ARTrackedImage img in args.updated)
        {
            UpdateImage(img);
        }
        foreach (ARTrackedImage img in args.removed)
        {
            spawned_prefabs[img.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage img)
    {
        string name = img.referenceImage.name;
        Vector3 position = img.transform.position;

        GameObject prefab = spawned_prefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        if(name == "google")
        {
            ui_manager.LoadPointDataPanel(0, prefab.transform);
        }

        //foreach(GameObject obj in spawned_prefabs.Values)
        //{
        //    if(obj.name != name)
        //    {
        //        obj.SetActive(false);
        //    }
        //}
    }
}
