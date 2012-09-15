using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace ScrollingCell
{
    public class ScrollElementItem
    {
        UIColor Color;
        UIView theView;
        float width = 0;
        
        public ScrollElementItem(UIColor baseColor, float width = -1)
        {
            Color = baseColor;
            this.width = width;
        }
        
        public float Width
        {
            get
            {
                return width == -1 ? 66f : width;
            }
            
        }
        
        //grab the view - cached if we can. 
        //it's just an area with a color. Customize at will.
        public UIView GetView(RectangleF bounds)
        {
            if (theView == null)
            {
                theView = new UIView(bounds) {
                    BackgroundColor = Color
                };
            }
            
            return theView;
        }
        
        
        
    }
}

