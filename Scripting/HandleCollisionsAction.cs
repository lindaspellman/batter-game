using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Scripting;

namespace cse210_batter_csharp
{
    /// <summary>
    /// 
    /// 
    /// Stereotype:
    ///     
    /// </summary>
    public class HandleCollisionsAction : Action 
    {
        PhysicsService _physicsService = new PhysicsService();
        AudioService _audioService = new AudioService();

        public HandleCollisionsAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor balls = cast["balls"][0]; // There is only one
            Actor paddle = cast["paddle"][0]; // There is only one 
            List<Actor> bricks = cast["bricks"]; // Get all the bricks
            List<Actor> toRemove = new List<Actor>();

            foreach (Actor ball in cast["balls"])
            {

                if (_physicsService.IsCollision(paddle, ball))
                {
                    Ball b = (Ball)ball;
                    b.BounceVertical();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }

                foreach (Actor brick in cast["bricks"])
                {
                    if(_physicsService.IsCollision(ball, brick))
                    {
                        Ball b = (Ball)balls;
                        b.BounceVertical();
                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                        toRemove.Add(brick);
                    }
                }

                foreach (Brick b in toRemove)
                {
                    bricks.Remove(b);
                }

            }
        }
    }
}
