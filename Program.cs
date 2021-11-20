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

             for(int y = 0; y < 120; y+=(Constants.BRICK_HEIGHT + Constants.BRICK_SPACE))
            {
                for (int x = Constants.BRICK_SPACE; x < 760; x+=(Constants.BRICK_WIDTH + Constants.BRICK_SPACE))
                {
                    Brick _brick = new Brick();
                    Point _point = new Point(x, y);
                    _brick.SetPosition(_point);
 
                    cast["bricks"].Add(_brick);
                }
            }

            // for (int y = 0; y < 5; y++)
            // {
            //     for (int x = 1; x < 10; x++)
            //     {
            //         Brick b = new Brick();
            //         Point brickPoint = new Point(x * 75, y * 50);
            //         b.SetPosition(brickPoint);
            //         cast["bricks"].Add(b);
            //     }
            // }

            // The Ball (or balls if desired)

            cast["balls"] = new List<Actor>();

            Ball ball = new Ball();
            Point ballPoint = new Point(Constants.BALL_X, Constants.BALL_Y);
            ball.SetPosition(ballPoint);
            cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here
            Paddle paddle = new Paddle();
            cast["paddle"].Add(paddle);

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
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction();
            script["update"].Add(handleOffScreenAction);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService);
            script["update"].Add(handleCollisionsAction);

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
