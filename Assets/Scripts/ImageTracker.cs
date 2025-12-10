using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private HashSet<string> activeImages = new HashSet<string>();

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
        SetupPrefabs();
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void SetupPrefabs()
    {
        foreach (GameObject prefab in placeablePrefabs)
        {
            if (!spawnedPrefabs.ContainsKey(prefab.name))
            {
                GameObject obj = Instantiate(prefab);
                obj.name = prefab.name;
                obj.SetActive(false);
                spawnedPrefabs.Add(prefab.name, obj);
            }
            else
            {
                Debug.LogWarning("Duplicate prefab in array ignored: " + prefab.name);
            }
        }
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
            UpdateImage(trackedImage);

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
            UpdateImage(trackedImage);

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            string imgName = trackedImage.referenceImage.name;
            if (spawnedPrefabs.ContainsKey(imgName))
            {
                spawnedPrefabs[imgName].SetActive(false);
                spawnedPrefabs[imgName].transform.SetParent(null);
                activeImages.Remove(imgName);
            }
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null) return;

        string imgName = trackedImage.referenceImage.name;

        if (!spawnedPrefabs.ContainsKey(imgName))
        {
            Debug.LogWarning("No prefab found for image: " + imgName);
            return;
        }

        GameObject obj = spawnedPrefabs[imgName];

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            obj.transform.SetParent(trackedImage.transform, false);
            obj.transform.localPosition = new Vector3(0, 0.05f, 0);
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one * 0.1f;

            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                Debug.Log("Spawning prefab: " + obj.name + " on image: " + imgName);
            }

            activeImages.Add(imgName);
        }
        else
        {
            obj.SetActive(false);
            obj.transform.SetParent(null);
            activeImages.Remove(imgName);
        }
    }
}
