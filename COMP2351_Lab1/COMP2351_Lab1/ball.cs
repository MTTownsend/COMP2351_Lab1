using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2351_Lab1
{
    class ball:PongEntity
    {
        private Vector2 Angle;
        private Vector2 Direction;
        private int bounce = 0;
        private Random rng = new Random();
        public ball()
        {
            _mSpeed = 3;
            Angle = new Vector2((float)rng.NextDouble() * 360, (float)rng.NextDouble() * 360);
        }

         public void CheckWallCollision()
        {
            if (this._location.X > Game1.ScreenWidth - this._texture.Width || this._location.X < 0)
            {
                Angle.X *= -1;
                bounce++;
                _mSpeed += 3;
            }
            if (this._location.Y > Game1.ScreenHeight - this._texture.Height || this._location.Y < 0)
            {
                Angle.Y *= -1;
                bounce++;
                _mSpeed += 3;
            }
        }

        public override void Update()
        {
            if (bounce < 3)
            {
                Direction = Vector2.Normalize(Angle);
                this._location = this._location + _mSpeed * Direction;
                CheckWallCollision();
            }
        }
    }

}
