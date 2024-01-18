using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_ColorCheck : MonoBehaviour
{
    public Ball_Modify Ball_Modify;
    public List<Image> Ball_Images;
    private Color32 Layer_Color;

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            switch (Ball_Modify.getColorModList()[i])//red,yellow,blue,green,orange,purple,brown,grey, white, pink, light yellow, light blue
            {
                case "red":
                    Layer_Color = new Color32(255, 0, 0, 255);
                    break;
                case "yellow":
                    Layer_Color = new Color32(255, 255, 0, 255);
                    break;
                case "blue":
                    Layer_Color = new Color32(0, 0, 255, 255);
                    break;
                case "green":
                    Layer_Color = new Color32(0, 255, 0, 255);
                    break;
                case "orange":
                    Layer_Color = new Color32(255, 127, 0, 255);
                    break;
                case "purple":
                    Layer_Color = new Color32(255, 0, 255, 255);
                    break;
                case "brown":
                    Layer_Color = new Color32(127, 64, 0, 255);
                    break;
                case "grey":
                    Layer_Color = new Color32(127, 127, 127, 255);
                    break;
                case "white":
                    Layer_Color = new Color32(255, 255, 255, 255);
                    break;
                case "pink":
                    Layer_Color = new Color32(255, 64, 127, 255);
                    break;
                case "light yellow":
                    Layer_Color = new Color32(255, 255, 127, 255);
                    break;
                case "light blue":
                    Layer_Color = new Color32(0, 255, 255, 255);
                    break;
                case null:
                    Layer_Color = new Color32(0, 0, 0, 0);
                    break;
                default:
                    Layer_Color = new Color32(0, 0, 0, 0);
                    break;
            }
            Ball_Images[i].color = Layer_Color;//color at same index is color
        }
    }
}
