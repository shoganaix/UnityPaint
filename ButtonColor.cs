using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public ChangeColor cambiarMaterialScript;

    private void Start()
    {
        Button Black = transform.Find("Black").GetComponent<Button>();
        Button White = transform.Find("White").GetComponent<Button>();
        Button Blue = transform.Find("Blue").GetComponent<Button>();
        Button Red = transform.Find("Red").GetComponent<Button>();
        Button Yellow = transform.Find("Yellow").GetComponent<Button>();

    }
    public void ColorToBlack()
    {
        cambiarMaterialScript.ChangeMaterial(0);
    }
    public void ColorToWhite()
    {
        cambiarMaterialScript.ChangeMaterial(1);
    }
    public void ColorToBlue()
    {
        cambiarMaterialScript.ChangeMaterial(2);
    }
    public void ColorToRed()
    {
        cambiarMaterialScript.ChangeMaterial(3);
    }
    public void ColorToYellow()
    {
        cambiarMaterialScript.ChangeMaterial(4);
    }
}
