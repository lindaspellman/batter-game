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
    public class HandleOffScreenAction : Action 
    {
        OutputService _outputService = new OutputService();
        public HandleOffScreenAction()
        {

        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor ball = cast["balls"][0]; // There is only one

            int x = ball.GetX();
            int y = ball.GetY();

            int dx = ball.GetVelocity().GetX();
            int dy = ball.GetVelocity().GetY();

            if (x > Constants.MAX_X || x < 0)
            {
                dx = -dx;
            }

            if (y > Constants.MAX_Y || y < 0)
            {
                dy = -dy;
            }

            ball.SetVelocity(new Point(dx, dy));
        }
    }
}
