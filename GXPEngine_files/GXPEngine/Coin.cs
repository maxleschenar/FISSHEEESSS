using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Coin: Sprite
    {
        public int value;
        Level _level;
        Sound colectCoin;
        public Coin(Fish fish, Level level) : base("coin.png")
        {
            x = fish.x;
            y = fish.y;
            value = fish.coinValue;
            width /= 17;
            height /= 17;
            _level = level;
            colectCoin = new Sound("pick_up_coin_sound.wav", false, true);
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
                if (Input.GetMouseButtonDown(button: 0))
                {
                    if (Input.mouseX > this.x &&
                        Input.mouseX < this.x + this.width &&
                        Input.mouseY > this.y &&
                        Input.mouseY < this.y + this.height)
                    {
                        colectCoin.Play();
                        colected = true;
                        _level.currencySystem.AddMoney(value);
                        this.LateDestroy();
                    }
                }
            }
        }
    }
}
