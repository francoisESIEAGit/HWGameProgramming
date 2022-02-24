using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class ConsumableItem : InventoryItems
{
    [Header("Consumable Data")]
    [SerializeField] private string useText = "Does Something";
    public override string GetInfoDisplayText()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(Name).AppendLine();
        builder.Append("<color=green>Use:").Append(useText).Append("</color>").AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();

        return builder.ToString();
    }
}
