using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house1 : MonoBehaviour
{
    private string targetMaterialName = "map4";
    private MeshRenderer meshRender;

    void  Awake() {
        meshRender = GetComponent<MeshRenderer>();
    }
    void Start(){
        HouseRandomColor(meshRender);
    }

    void HouseRandomColor(MeshRenderer meshRender){
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
}
