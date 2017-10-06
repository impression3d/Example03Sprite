using System;
using Impression;

namespace Example03Sprite
{
    class Program
    {
        static void Main(string[] args)
		{
			using(var game = new Example03SpriteGame())
            {
                game.Run();
            }
		}
    }
}