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
    class ball : PongEntity
    {

        private Random random;
        public ball()
        {
            random = new Random();
            _mSpeed = 8;      
        }

        public void CheckWallCollision()
        {
            if (this._location.X > Game1.ScreenWidth - this._texture.Width || this._location.X < 0)
            {
                _velocity.X *= -1;
            }
            if (this._location.Y > Game1.ScreenHeight - this._texture.Height || this._location.Y < 0)
            {
                _velocity.Y *= -1;  
            }
        }

        public void Serve()
        {
            _location.X = Game1.ScreenWidth/2 - _texture.Width/2;
            _location.Y = Game1.ScreenHeight/2 - _texture.Height/2;
            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));
            _velocity.X = (float)Math.Sin(rotation);
            _velocity.Y = (float)Math.Cos(rotation);

            if (random.Next(1, 3) == 2)
            {
                _velocity.X *= -1;
            }

            _velocity *= _mSpeed;
        }
        

        public override void Update()
        {
            _location += _velocity;
            CheckWallCollision();
        }
    }
}
