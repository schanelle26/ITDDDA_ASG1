using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

    public GameObject chickenRicePrefab;
    public GameObject nasiLemakPrefab;
    public GameObject noodlesPrefab;

    // To store spawned objects so that they don’t spawn twice
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            UpdateSpawnedObject(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            UpdateSpawnedObject(trackedImage);
        }

    }

    void UpdateSpawnedObject(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        GameObject prefabToSpawn = null;

        if (imageName == "ChickenRice") prefabToSpawn = chickenRicePrefab;
        if (imageName == "NasiLemak") prefabToSpawn = nasiLemakPrefab;
        if (imageName == "Noodles") prefabToSpawn = noodlesPrefab;

        if (prefabToSpawn == null)
            return;

        // If this marker already spawned an object, reuse it
        if (!spawnedPrefabs.ContainsKey(imageName))
        {
            GameObject newObject = Instantiate(prefabToSpawn, trackedImage.transform);
            spawnedPrefabs.Add(imageName, newObject);

            DatabaseManager dbManager = FindObjectOfType<DatabaseManager>();
            dbManager.UpdateFoodCollected(imageName); //Sends image name as food name

        }

        GameObject spawned = spawnedPrefabs[imageName];

        // Keep the 3D object following the image
        spawned.transform.SetPositionAndRotation(
            trackedImage.transform.position,
            trackedImage.transform.rotation
        );

        spawned.SetActive(true);
    }
}
