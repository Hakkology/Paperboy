using UnityEngine;

public class NewspaperManager
{
    private GameObject newspaperPrefab;
    private Transform bikerHandTransform; 
    private float bikerspeed;
    private float lastThrowTime;
    [SerializeField]
    private const float throwCooldown = 0.4f; 

    public NewspaperManager(GameObject newspaperPrefab, Transform bikerHandTransform, float bikerspeed)
    {
        this.newspaperPrefab = newspaperPrefab;
        this.bikerHandTransform = bikerHandTransform;
        this.bikerspeed = bikerspeed;
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastThrowTime >= throwCooldown)
        {
            ThrowNewspaper();
            lastThrowTime = Time.time;
        }
    }

    private void ThrowNewspaper()
    {
        Transform newspapersParent = GameObject.Find("Environment/Newspapers")?.transform;

        if (newspapersParent == null) // if null, gives error
        {
            GameObject environmentObj = new GameObject("Environment");
            newspapersParent = environmentObj.transform;
            
            GameObject newspapersObj = new GameObject("Newspapers");
            newspapersObj.transform.SetParent(newspapersParent);
        }

        GameObject newspaperInstance = GameObject.Instantiate(newspaperPrefab, bikerHandTransform.position, Quaternion.identity);
        newspaperInstance.transform.SetParent(newspapersParent);
        NewspaperHandler handler = newspaperInstance.GetComponent<NewspaperHandler>();
        handler.Initialize(bikerspeed);
    }
}
