using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Coin: Sprite
    {
        public int value;
        Level _scene;
        public Coin(Fish fish, Level scene) : base("money.png")
        {
            x = fish.x;
            y = fish.y;
            value = fish.coinValue;
            width /= 7;
            height /= 7;
            _scene = scene;
        }
        void Update()
        {
            overlap();
        }
        bool colected = false;
        void overlap()
        {
            if (colected == false)
            {
                if (Input.GetMouseButtonDown(button: 1))
                {
                    if (Input.mouseX > this.x &&
                        Input.mouseX < this.x + this.width &&
                        Input.mouseY > this.y &&
                        Input.mouseY < this.y + this.height)
                    {
                        //Console.WriteLine("coin");
                        this.LateDestroy();
                        colected = true;
                        _scene.currencySystem.AddMoney(value);
                    }
                }
            }
        }
    }
}
