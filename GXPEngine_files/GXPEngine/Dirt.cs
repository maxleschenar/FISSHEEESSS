using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Dirt:Sprite
    {
        public float _radius;
        public Vec2 _position;
        public Dirt() : base("triangle.png")
        {
            x = Utils.Random(50, game.width - 50);
            y = Utils.Random(50, game.height - 50);
            _position.SetXY(x,y);
            _radius = width / 2;
        }
    }
}
