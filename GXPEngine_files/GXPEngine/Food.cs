using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Food:Sprite
    {
        public Vec2 _position;
        public Food() : base("circle.png")
        {

            this.SetOrigin(width / 2, height / 2);
            width /= 2;
            height /= 2;
            _position.SetXY(Input.mouseX, Input.mouseY);
            this.x = Input.mouseX;
           this.y = Input.mouseY;
        }
        void UpdateScreenPosition()
        {
            x = _position.x;
            y = _position.y;
        }

    }
}
