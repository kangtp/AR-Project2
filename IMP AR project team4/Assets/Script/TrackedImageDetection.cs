using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageDetection : MonoBehaviour
{
    private ARTrackedImageManager _trackedImgManager;
    public PlaceablePrefab[] placeablePrefabs;
    public Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        _trackedImgManager = GetComponent<ARTrackedImageManager>();

        //move the placeablePrefabs in spawnedObjects, and instantiate.
        foreach (PlaceablePrefab pp in placeablePrefabs)
        {
            GameObject go = Instantiate(pp.prefab, Vector3.zero, Quaternion.identity);
            go.name = pp.name;
            spawnedObjects.Add(go.name, go);
            go.SetActive(false);
        }
    }
    public void OnEnable()
    {
        _trackedImgManager.trackedImagesChanged += OnImageChanged; // subscribe
    }
    public void OnDisable()
    {
        _trackedImgManager.trackedImagesChanged -= OnImageChanged; // unsubscribe
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // instantiate the prefab at the position of the tracked image when it is detected
        foreach (ARTrackedImage trackedImg in args.added)
        {
            Debug.Log(trackedImg.referenceImage.name);
            UpdatePrefab(trackedImg);
        }
        // update the prefab position when the tracked image is updated (e.g. position is changed)
        foreach (ARTrackedImage trackedImg in args.updated)
        {
            UpdatePrefab(trackedImg);
        }
        // disable spawned objects when the tracked image is not tracked anymore
        foreach (ARTrackedImage trackedImg in args.removed)
        {
            spawnedObjects[trackedImg.referenceImage.name].SetActive(false);
        }
        
    }

    private void UpdatePrefab(ARTrackedImage trackedImg)
    {
        GameObject obj = spawnedObjects[trackedImg.referenceImage.name];

        // tracking works well, so we can show the object at the tracked image's position
        if (trackedImg.trackingState == TrackingState.Tracking)
        {
            obj.transform.position = trackedImg.transform.position;
            obj.transform.rotation = trackedImg.transform.rotation;
            obj.SetActive(true);
        }
        // limited tracking information is available. The tracking works somehow but may be poor quality.
        // we will disable the spawned object then.
        else
        {
            // trackingState == None, so we can disable the object
            obj.SetActive(false);
        }
    }
}

//there is image name and prefab corresponding to the image.
[System.Serializable]
public struct PlaceablePrefab
{
    public string name;
    public GameObject prefab;
}
