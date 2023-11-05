using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    public string targetMaterialName = "";
    private MeshRenderer meshRender;

    void  Awake() {
        meshRender = GetComponent<MeshRenderer>();
        if (this.gameObject.name == "House1")
        {
            targetMaterialName = "map4";
        }
        else
        {
            targetMaterialName = "map2";
        }
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
