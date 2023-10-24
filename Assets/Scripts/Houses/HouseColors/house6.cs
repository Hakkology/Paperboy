using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house6 : MonoBehaviour
{

    public GameObject mailboxPrefab;
    private bool isMailboxInstantiated = false;

    private string targetMaterialName = "map2";
    private MeshRenderer meshRender;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();

        Material[] materials = meshRender.materials;

        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name.StartsWith(targetMaterialName))
            {
                Color randomColor = new Color (Random.value, Random.value, Random.value);
                materials[i].color = randomColor;
                break;
            }
        }

        meshRender.materials = materials;

        if (!isMailboxInstantiated)
        {
            InstantiateMailboxPrefab();
            isMailboxInstantiated=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateMailboxPrefab(){
        if (mailboxPrefab == null)
        {
            Debug.Log("House 6 mailbox Prefab missing!");
        }

        Transform grassTransform = transform.Find("Grass");
        if (grassTransform == null)
        {
            Debug.LogError("No 'grass' child found in the house prefab!");
            return;
        }

        GameObject newMailbox = Instantiate(mailboxPrefab, transform);
        float randomZ = Random.Range(-0.5f, 0.5f);
        newMailbox.transform.localPosition = new Vector3(-0.3f, 0.5f, randomZ);
    }
}
