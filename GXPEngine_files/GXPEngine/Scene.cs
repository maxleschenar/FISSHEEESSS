using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{

    public class Scene: GameObject
    {        
        Sprite tank, downArrow;
        Level level;
        int timer=1000;
        public bool isActive;
        bool canMakeFood;
        Sponge sponge;
        public List<Food> foodList;
        List<Fish> fishListPerScene;
        Shop shop;
        Inventory inv;
        public CurrencySystem _currency;
        int cleanMeter = 0;
        int scene;

        public Scene(string path, CurrencySystem currency, Level level, int scene) : base()
        {
            this.scene = scene;
            _currency = currency;
            visible = false;
            this.level = level;
            isActive = false;
            canMakeFood = true;
            tank = new Sprite(path);
            downArrow = new Sprite("downarrow.png");

            downArrow.SetXY(game.width / 2, game.height - 200);
            downArrow.SetScaleXY(0.2f);
            foodList = new List<Food>();
            AddChild(tank);
            AddChild(downArrow);


            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(scene, foodList, fishListPerScene);
            sponge = new Sponge(this);
//<<<<<<< HEAD
            shop = new Shop(fishListPerScene,level);
             inv = new Inventory();
            AddChild(inv);
//=======
            //shop = new Shop(fishListPerScene, level);

//>>>>>>> 9ec9b0844e97dc6d221fd4297b2c139ffc277aff
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
            if (Input.GetMouseButtonDown(button: 0) && canMakeFood)
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
                canMakeFood = true;
//<<<<<<< HEAD
                switch (inv.id)
//=======

                //if (isShopDisplayed == false)
//>>>>>>> 9ec9b0844e97dc6d221fd4297b2c139ffc277aff
                {
                    case Inventory.Food:
                        makeFood();
                        RemoveShop();
                        RemoveSponge();
                        break;
                    case Inventory.Sponge:
                        displaySponge();
                        RemoveShop();
                        break;
                    case Inventory.Shop:
                        displayShop();
                        RemoveSponge();
                        break;
                    case 0:
                        RemoveShop();
                        RemoveSponge();
                        handleMoney();
                        break;
                }
                makeDirt();
                addFish();
                goBack();
            }
        }

        void handleMoney()
        {
            foreach (Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {

                    if (fish.isFishHungry >3000 && cleanMeter < 75)
                    {
                        // Console.WriteLine(fish.FishProgrss);
                        //Console.WriteLine(fish.FishProgrss);
                        if (fish.FishProgrss >= 3000)
                        {
                            Coin coin = new Coin(fish,level);
                            AddChild(coin);
                            fish.FishProgrss = 0;
                            //Console.WriteLine(fish.FishProgrss);

                            // _currency.AddMoney(fish.coinValue);
                        }
                        else
                        {
                            fish.FishProgrss += Time.deltaTime;
                        }
                    }
                }
            }
            
        }
        void makeDirt()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Dirt dirt = new Dirt(ref cleanMeter);
                sponge.addDirt(dirt);
                AddChild(dirt);
                timer = 1000;
            }
        }

        public void removeDirtConsequence(Dirt dirt)
        {
            cleanMeter -= dirt.cleanImpact;
        }

        void goBack()
        {
            if (MyGame.CheckMouseInRect(downArrow))
            {
                canMakeFood = false;
            }
            if (MyGame.CheckMouseInRectClick(downArrow))
            {
                isActive = false;
                level.isInScene = false;
                visible = false;
                if(shop != null)
                {
                    RemoveChild(shop);
                }
            }
        }

        bool spongeOnScreen = false;
        void displaySponge()
        {
            //if (Input.GetMouseButton(button: 1))
            //{
                if (spongeOnScreen == false)
                {
                    AddChild(sponge);
                    spongeOnScreen = true;
                }
               // else
                //{
               //RemoveChild(sponge);
                //spongeOnScreen = false;
            //}
            //}
            //else
            //{
                //if (spongeOnScreen == true)
                //{
                    
                //}
            //} 
                
        }
        void RemoveSponge()
        {
            if (spongeOnScreen == true)
            {
                RemoveChild(sponge);
                spongeOnScreen = false;
            }


        }
        bool isShopDisplayed = false;
        void displayShop()
        {
            
//<<<<<<< HEAD

                if (isShopDisplayed == false)
//=======
            //if (Input.GetKeyDown(Key.SPACE))
           // {
               // if (isShopDisplayed == false || !HasChild(shop))
//>>>>>>> 9ec9b0844e97dc6d221fd4297b2c139ffc277aff
                {
                    AddChild(shop);
                    isShopDisplayed = true;
                }
                //else
                //{
                //    RemoveChild(shop);
                //    isShopDisplayed = false;
                //}
            
        }
        void RemoveShop()
        {
            if (isShopDisplayed == true)
            {
                RemoveChild(shop);
                isShopDisplayed = false;
            }
        }
    }
}
