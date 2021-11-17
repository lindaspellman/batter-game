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
    public class Ball : Actor 
    {
        public Ball()
        {
            SetImage(Constants.IMAGE_BALL);
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_WIDTH);

            Point velocity = new Point(4, 4);
            SetVelocity(velocity);
        }

    }
}
