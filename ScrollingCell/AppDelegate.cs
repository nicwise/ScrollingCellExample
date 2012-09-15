using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

namespace ScrollingCell
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            //Use MonoTouch.Dialog 'cos its easier than spinning up a whole UITableView thing

            var vc = new DialogViewController(UITableViewStyle.Plain, BuildRootElement(), false);
            
            window.RootViewController = new UINavigationController(vc);
            window.MakeKeyAndVisible();
            
            return true;
        }

        public RootElement BuildRootElement()
        {

            //make a root element and a single section.
            var root = new RootElement("TEST!");

            root.UnevenRows = true;
            ScrollingElement scrollElement, scrollElement2;


            //put in 2 scrollingin elements - this is our wide thing!
            root.Add(new Section() {
                new StringElement("whatever"),
                (scrollElement = new ScrollingElement()),
                (scrollElement2 = new ScrollingElement())
            });


            //populate the scrolling areas with some subviews. Just colored blocks for the moment.
            for (int i = 0; i < 5; i++)
            {
                scrollElement.Add(new ScrollElementItem(UIColor.Red));
                scrollElement.Add(new ScrollElementItem(UIColor.Green));
                scrollElement.Add(new ScrollElementItem(UIColor.Blue));
                scrollElement.Add(new ScrollElementItem(UIColor.Black));
                scrollElement.Add(new ScrollElementItem(UIColor.Yellow));

                scrollElement2.Add(new ScrollElementItem(UIColor.Yellow, 132f));
                scrollElement2.Add(new ScrollElementItem(UIColor.Green));
                scrollElement2.Add(new ScrollElementItem(UIColor.Blue));
               

            }

            return root;
        }
    }






}

