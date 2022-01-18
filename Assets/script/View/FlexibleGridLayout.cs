using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : GridLayoutGroup
{
   public int ColumnCount = 3;
   public int RowCount = 3;
 
 
   public override void SetLayoutHorizontal()
   {
      UpdateCellSize();
      base.SetLayoutHorizontal();
   }
 
   public override void SetLayoutVertical()
   {
      UpdateCellSize();
      base.SetLayoutVertical();
   }
 
   private void UpdateCellSize()
   {        
      float x = (rectTransform.rect.size.x - padding.horizontal/100f * rectTransform.rect.size.x - spacing.x/100f * rectTransform.rect.size.x * (ColumnCount - 1)) / ColumnCount;
      float y = (rectTransform.rect.size.y - padding.vertical/100f * rectTransform.rect.size.y - spacing.y/100f * rectTransform.rect.size.x * (RowCount - 1)) / RowCount;
      this.constraint = Constraint.FixedColumnCount;
      this.constraintCount = ColumnCount;
      this.cellSize = new Vector2(x,y);    
   }
}
