using System;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;

namespace ScrollingCell
{
    public class ScrollingElement : Element, IElementSizing
    {
        
        // this is likely to be badly coded and leak memory all over the show.
        //
        //it's designed as an illistration of how to strcture a wide scrolling element, nothing more than
        // the controls which are in there.
        //
        //you might want to look here for how to do a custom cell-based Element
        // properly:
        //
        //https://github.com/migueldeicaza/MonoTouch.Dialog/blob/master/MonoTouch.Dialog/Elements/MessageElement.cs

        // basically, we have our cell, which is 320x<height>.
        // Into that we add a UIScrollView, which is 320x<height>
        // We set the UIScrollView's "virtual area" (ContentView) to be <the width of our subviews>x<height>
        // We then add all of our subviews in, and iOS handles the scrolling.
        
        public ScrollingElement() : base("")
        {
            //odds are, we dont want to reuse things
            cellKey = new NSString("ScrollingElement" + Guid.NewGuid().ToString());
            
        }
        
        //fixed height.
        float height = 66f;
        
        public float GetHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return height;
        }
        
        NSString cellKey = new NSString("");
        
        protected override NSString CellKey
        {
            get
            {
                return cellKey;
            }
        }
        
        public override UITableViewCell GetCell(UITableView tv)
        {
            
            //get the cell, or make one
            var cell = tv.DequeueReusableCell(CellKey);
            
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellKey);
            }
            
            //Lets just ignore the stuff thats already in the cell. See header comment.
            
            
            //make the scrollview.
            var scrollView = new UIScrollView(new RectangleF(0, 0, cell.Frame.Width, height));
            
            //set the size of it's content area. This is the "virtual" space you scroll around
            scrollView.ContentSize = new System.Drawing.SizeF(TotalWidth, height);
            
            //no vertical please, we only want horizontal.
            //we could turn that off too - might look better. YMMV.
            scrollView.ShowsVerticalScrollIndicator = false;
            
            
            //add in all the subviews. We keep track of where they are in the contentview, as it's
            //basically a big view canvas.
            //maybe iOS6's autolayout could help here.
            var x = 0f;
            foreach (var item in items)
            {
                var newWidth = item.Width;
                
                scrollView.AddSubview(item.GetView(new RectangleF(x, 0, newWidth, height)));
                x += newWidth;
            }
            
            //add it.
            cell.ContentView.AddSubview(scrollView);
            //cell.ContentView.BringSubviewToFront(scrollView);
            
            return cell;
            
        }
        
        public float TotalWidth
        {
            get
            {
                float width = 0;
                foreach (var item in items)
                {
                    width += item.Width;
                }
                
                return width;
            }
        }
        
        
        //storage for the list of items we are viewing. Might
        // be image + labels if you want to do something like iTunes does.
        List<ScrollElementItem> items = new List<ScrollElementItem>();
        
        public void Add(ScrollElementItem element)
        {
            items.Add(element);
        }
        
        
    }
}

