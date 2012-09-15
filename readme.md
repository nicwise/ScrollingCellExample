
##ScrollingCell example

This is an example of how you would do a wide, scrolling cell in MonoTouch. It uses MonoTouch.Dialog to abstract away the UITableView bits, but the idea would be the same if you used a UITableView - just it's more code.

__Note that this is likely going to leak all over town__. Don't take it as HOW you should do it - take it as what components you need to do it. Those are

* A UITableViewCell containing....
  * A UIScrollView containing....    
  	 * A number of UIView's.

If you need an example of how to properly structure a custom View-based MonoTouch.Dialog Element, [you should look at the MessageElement](https://github.com/migueldeicaza/MonoTouch.Dialog/blob/master/MonoTouch.Dialog/Elements/MessageElement.cs) included in MT.D. This is just a quick hack to illistrate what to do.

License: MIT, I guess. Do whatever you want with it :)