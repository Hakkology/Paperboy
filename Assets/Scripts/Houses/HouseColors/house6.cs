using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house6 : MonoBehaviour
{
    private string targetMaterialName = "map2";
    private MeshRenderer meshRender;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
