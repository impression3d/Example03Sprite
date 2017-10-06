﻿using Android.App;
using Android.OS;
using Impression;

namespace Example03Sprite
{
	[Activity(MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.KeyboardHidden)]
    public class MainActivity : AndroidImpressionActivity
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;

            // Create and run the game
            var game = new Example03SpriteGame();
            game.Run();
        }      
    }
}

