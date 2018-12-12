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
    abstract class PongEntity:Game
    {
        public Vector2 _location;
        //protected float _mSpeed;
        public Texture2D _texture;
        public PongEntity()
        {
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.AntiqueWhite);
        }
    }
}
