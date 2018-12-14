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
    class paddle:PongEntity
    {

        static Vector2 _direction;

        public paddle()
        {
            _direction.X = 0;
            _direction.Y = 0;
        }

        public override void Update(Vector2 velocity)
        {
            _location += velocity;
        }
    }
}
