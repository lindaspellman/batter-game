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
    public class Paddle : Actor 
    {
        public Paddle()
        {
            SetImage(Constants.IMAGE_PADDLE);
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);

            Point paddlePosition = new Point(Constants.PADDLE_X, Constants.PADDLE_Y);
            SetPosition(paddlePosition);
        }
    }
}
