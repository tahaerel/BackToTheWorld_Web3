using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    [SerializeField] private Rarity rarity;
    [SerializeField] private string useText = "-";
    [SerializeField] private string gerekli_kaynak2 = "-";
    [SerializeField] private string gerekli_kaynak3= "-";
    [SerializeField] private string gerekli_kaynak4 = "-";


    public Rarity Rarity { get { return rarity; } }

    public override string ColouredName
    {
        get
        {
            string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
            return $"<color=#{hexColour}>{Name}</color>";
        }
    }

    public override string GetTooltipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Rarity.Name).AppendLine();
        if (Bina1Hover.Bina1_hover) 
        { 

        if (Bina1Hover.Bina1enerji_yeter)
        {
            builder.Append(Bina1Hover.colorRed).Append(useText).Append("</color>").AppendLine();
        }
        else
        {
            builder.Append(Bina1Hover.colorgreen).Append(useText).Append("</color>").AppendLine();
        }
        if (Bina1Hover.Bina1demir_yeter)
        {
            builder.Append(Bina1Hover.colorRed).Append(gerekli_kaynak2).Append("</color>").AppendLine();
        }
        else
        {
            builder.Append(Bina1Hover.colorgreen).Append(gerekli_kaynak2).Append("</color>").AppendLine();
        }
        if (Bina1Hover.Bina1yemek_yeter)
        {
            builder.Append(Bina1Hover.colorRed).Append(gerekli_kaynak3).Append("</color>").AppendLine();
        }
        else
        {
            builder.Append(Bina1Hover.colorgreen).Append(gerekli_kaynak3).Append("</color>").AppendLine();
        }
        }

        //////////////////////////////////////////////// BÝNA2 ENERJÝ PANELÝ //////////////////////////////
        ///

        if (Bina2Hover.Bina2_hover)
        {
            if (Bina2Hover.Bina2demir_yeter)
            {
                builder.Append(Bina2Hover.colorRed2).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina2Hover.colorgreen2).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
        }
        //////////////////////////////////////////////// BÝNA3 FARM  //////////////////////////////
        ///

        if (Bina3Hover.Bina3_hover)
        {

            if (Bina3Hover.Bina3demir_yeter)
            {
                builder.Append(Bina3Hover.colorRed3).Append(useText).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina3Hover.colorgreen3).Append(useText).Append("</color>").AppendLine();
            }
            if (Bina3Hover.Bina3enerji_yeter)
            {
                builder.Append(Bina3Hover.colorRed3).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina3Hover.colorgreen3).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            if (Bina3Hover.Bina3su_yeter)
            {
                builder.Append(Bina3Hover.colorRed3).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina3Hover.colorgreen3).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }
            if (Bina3Hover.Bina3koloni_yeter)
            {
                builder.Append(Bina3Hover.colorRed3).Append(gerekli_kaynak4).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina3Hover.colorgreen3).Append(gerekli_kaynak4).Append("</color>").AppendLine();
            }


        }

        //////////////////////////////////////////////// BÝNA4  //////////////////////////////
        ///

        if (Bina4Hover.Bina4_hover)
        {

            if (Bina4Hover.Bina4demir_yeter)
            {
                builder.Append(Bina4Hover.colorRed4).Append(useText).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina4Hover.colorgreen4).Append(useText).Append("</color>").AppendLine();
            }
            if (Bina4Hover.Bina4enerji_yeter)
            {
                builder.Append(Bina4Hover.colorRed4).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina4Hover.colorgreen4).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
           
            if (Bina4Hover.Bina4koloni_yeter)
            {
                builder.Append(Bina4Hover.colorRed4).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina4Hover.colorgreen4).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }


        }
        //////////////////////////////////////////////// BÝNA5  //////////////////////////////
        ///
        if (Bina5Hover.Bina5_hover)
        {

            if (Bina5Hover.Bina5demir_yeter)
            {
                builder.Append(Bina5Hover.colorRed5).Append(useText).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina5Hover.colorgreen5).Append(useText).Append("</color>").AppendLine();
            }
            if (Bina5Hover.Bina5enerji_yeter)
            {
                builder.Append(Bina5Hover.colorRed5).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina5Hover.colorgreen5).Append(gerekli_kaynak2).Append("</color>").AppendLine();
            }
            if (Bina5Hover.Bina5su_yeter)
            {
                builder.Append(Bina5Hover.colorRed5).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina5Hover.colorgreen5).Append(gerekli_kaynak3).Append("</color>").AppendLine();
            }

            if (Bina5Hover.Bina5koloni_yeter)
            {
                builder.Append(Bina5Hover.colorRed5).Append(gerekli_kaynak4).Append("</color>").AppendLine();
            }
            else
            {
                builder.Append(Bina5Hover.colorgreen5).Append(gerekli_kaynak4).Append("</color>").AppendLine();
            }


        }
        //////////////////////////////////////////////// BÝNA5  //////////////////////////////
        ///
        if (Bina6Hover.Bina6_hover)
        {

        
            if (Bina6Hover.Bina6demir_yeter)
        {
            if (Bina6Hover.Bina6demir_yeter)
            {
               builder.Append(Bina6Hover.colorRed6).Append(useText).Append("</color>").AppendLine();
           }
            else
            {
                builder.Append(Bina6Hover.colorgreen6).Append(useText).Append("</color>").AppendLine();
            }
        }
        }
        //builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}
