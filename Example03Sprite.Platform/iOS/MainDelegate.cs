using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Impression;

namespace Example03Sprite
{
    [Register("MainAppDelegate")]
	public partial class MainAppDelegate : iOSImpressionApplicationDelegate
	{
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			// Instantiate the game
			this.Game = new Example03SpriteGame();

			return base.FinishedLaunching(app, options);
        }

		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "MainAppDelegate");
		}

		public override void WillTerminate (UIApplication application)
		{
			this.Game.Dispose();
		}
    }
}

