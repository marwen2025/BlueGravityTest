using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
   public ItemDefinition ItemDefinition { get; private set; }
   

   public ItemInstance(ItemDefinition itemDefinition)
   {
      ItemDefinition = itemDefinition;
   }

   public virtual void OnItemRemoved()
   {
      
   }
}
