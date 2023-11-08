using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material[] materiales;
    public void ChangeMaterial(int indice)
    {
            meshRenderer.material = materiales[indice];
    }
}
