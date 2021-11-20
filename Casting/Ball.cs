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
        Random rG = new Random();
        public Ball()
        {
            int num1 = rG.Next(1, 4);
            int num2 = rG.Next(1, 4);
            SetImage(Constants.IMAGE_BALL);
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_WIDTH);

            Point velocity = new Point(1 + num1, 1 + num2);
            SetVelocity(velocity);
        }

        public void BounceHorizontal()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();
 
            _velocity = new Point (-dx, dy);
        }
        public void BounceVertical()
        {
            int num1 = rG.Next(1, 4);
            int num2 = rG.Next(1, 4);

            int dx = _velocity.GetX();
            int dy = _velocity.GetY();
 
            _velocity = new Point (dx + num1, -dy + num2);
        }

    }
}
