using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            // Brick b1 = new Brick();
            // Point p1 = new Point(10, 10);
            // b1.SetPosition(p1);
            // b1.SetImage(Constants.IMAGE_BRICK);
            // b1.SetWidth(Constants.BRICK_WIDTH);
            // b1.SetHeight(Constants.BRICK_HEIGHT);
            // cast["bricks"].Add(b1);

            // Brick b2 = new Brick();
            // Point p2 = new Point(100, 10);
            // b2.SetPosition(p2);
            // b2.SetImage(Constants.IMAGE_BRICK);
            // b2.SetWidth(Constants.BRICK_WIDTH);
            // b2.SetHeight(Constants.BRICK_HEIGHT);
            // cast["bricks"].Add(b2);

            // Brick b3 = new Brick();
            // Point p3 = new Point(200, 10);
            // b3.SetPosition(p3); 
            // b3.SetImage(Constants.IMAGE_BRICK);
            // b3.SetWidth(Constants.BRICK_WIDTH);
            // b3.SetHeight(Constants.BRICK_HEIGHT);
            // cast["bricks"].Add(b3);

            for (int x = 0; x < Constants.MAX_X; x++)
            {
                for (int y = 0; y < Constants.MAX_Y; y++)
                {
                    Brick b = new Brick();
                    Point p = new Point(x, y);
                    b.SetPosition(p);
                    b.SetImage(Constants.IMAGE_BRICK);
                    b.SetWidth(Constants.BRICK_WIDTH);
                    b.SetHeight(Constants.BRICK_HEIGHT);
                    cast["bricks"].Add(b);
                }
            }

            ///////////////////////////
            // NOT RELEVANT TO MAIN PROGRAM
            //
            // List<Brick> bricks = new List<Brick>();
            // bricks.Add(b1);
            // bricks.Add(b2);
            // bricks.Add(b3);

            // foreach (Brick b in bricks)
            // {
            //     b.GetPosition(); //doesn't do anything
            //     Console.WriteLine($"({b.GetX()}, {b.GetY()})"); //adding "{b}:" changes output but IDK what it means
            // }
            ///////////////////////////

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // TODO: Add your ball here

            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
