using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Scene: GameObject
    {

//<<<<<<< HEAD
        //Sprite tank, downArrow;
        
//=======
        Sprite tank, downArrow;
        Level level;
//>>>>>>> 31869b4ec1c682aefb308fdece290575e5992185
        int timer=1000;
        public bool isActive;
        Sponge sponge;
        public List<Food> foodList;
        List<Fish> fishListPerScene;
        Shop shop;
        CurrencySystem _currency;
        int cleanMeter = 0;

//<<<<<<< HEAD
        public Scene(string path, CurrencySystem currency, Level level) : base()
        {
            _currency = currency;
//=======
       // public Scene() : base()
       // {
            visible = false;
            this.level = level;
//>>>>>>> 31869b4ec1c682aefb308fdece290575e5992185
            isActive = true;
            tank = new Sprite(path);
            downArrow = new Sprite("downarrow.png");

            downArrow.SetXY(game.width / 2, game.height - 200);
            downArrow.SetScaleXY(0.2f);
            foodList = new List<Food>();
            AddChild(tank);
            AddChild(downArrow);


            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(1, foodList, fishListPerScene);
            sponge = new Sponge();
            shop = new Shop(fishListPerScene);
        }
        void addFish()
        {
            foreach(Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {
                    if (fish.isAdded == false)
                    {
                        AddChild(fish);
                        fish.isAdded = true;
                    }
                }
            }
        }
        void makeFood()
        {
            if (Input.GetMouseButtonDown(button: 0))
            {
                Food food = new Food();
                AddChildAt(food,1);
                foodList.Add(food);
            }
        }
        void Update()
        {
            if (isActive)
            {
                if (isShopDisplayed == false)
                {
                    makeFood();
                }
                makeDirt();
                displaySponge();
                addFish();
//<<<<<<< HEAD
                goBack();
            }
        }

        void handleMoney()
        {
            foreach (Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {
                    if (fish.isAdded == false)
                    {
                        AddChild(fish);
                        fish.isAdded = true;
                    }
                }
            }
           //if ()
//=======
                displayShop();
                goBack();
            

//>>>>>>> 31869b4ec1c682aefb308fdece290575e5992185
        }
        void makeDirt()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Dirt dirt = new Dirt();
                sponge.addDirt(dirt);
                AddChild(dirt);
                timer = 1000;
            }
        }

        void goBack()
        {
            if (MyGame.CheckMouseInRect(downArrow))
            {
                isActive = false;
                level.isInScene = false;
                visible = false;
            }
        }

        bool spongeOnScreen = false;
        void displaySponge()
        {
            if (Input.GetMouseButton(button: 1))
            {
                if (spongeOnScreen == false)
                {
                    AddChild(sponge);
                    spongeOnScreen = true;
                }
            }
            else
            {
                if (spongeOnScreen == true)
                {
                    RemoveChild(sponge);
                    spongeOnScreen = false;
                }
            } 
                
        }
        bool isShopDisplayed = false;
        void displayShop()
        {
            if (Input.GetKeyDown(Key.SPACE))
            {
                if (isShopDisplayed == false)
                {
                    AddChild(shop);
                    isShopDisplayed = true;
                }
                else
                {
                    RemoveChild(shop);
                    isShopDisplayed = false;
                }
            }
        }
    }
}
