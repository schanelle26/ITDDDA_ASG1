using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FoodImageTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

    public GameObject chickenRicePrefab;
    public GameObject nasiLemakPrefab;
    public GameObject noodlesPrefab;

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
        foreach (var tracked in args.added)
        {
            SpawnFood(tracked);
        }

        foreach (var tracked in args.updated)
        {
            SpawnFood(tracked);
        }
    }

    void SpawnFood(ARTrackedImage tracked)
    {
        string name = tracked.referenceImage.name;
        GameObject prefabToSpawn = null;

        if (name == "ChickenRice") prefabToSpawn = chickenRicePrefab;
        if (name == "NasiLemak") prefabToSpawn = nasiLemakPrefab;
        if (name == "Noodles") prefabToSpawn = noodlesPrefab;

        if (prefabToSpawn != null)
        {
            prefabToSpawn.SetActive(true);
            prefabToSpawn.transform.position = tracked.transform.position;
            prefabToSpawn.transform.rotation = tracked.transform.rotation;
            prefabToSpawn.transform.SetParent(tracked.transform);
        }
    }
}
