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
        int priceOfAquarium;
        bool isBought=false;
        bool isOneFishShown = false;
        Sprite clickToBuy;


        public Scene(string path, CurrencySystem currency, Level level, int scene, int price=400) : base()
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
            priceOfAquarium = price;

            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(scene, foodList, fishListPerScene);
            sponge = new Sponge(this);
            shop = new Shop(fishListPerScene,level);
             inv = new Inventory();
            clickToBuy = new Sprite("checkers.png");
            clickToBuy.width = 200;
            clickToBuy.height = 200;
            AddChild(clickToBuy);
            for(int i = 0; i < 30; i++)
            {
                Dirt dirt = new Dirt(ref cleanMeter);
                sponge.addDirt(dirt);
                AddChild(dirt);
            }

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
                        if (isOneFishShown == false)
                        {
                            isOneFishShown = true;
                        }
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
                if (isBought == true)
                {
                    canMakeFood = true;
                    switch (inv.id)
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
                    if (isOneFishShown == true)
                    {
                        makeDirt();
                    }
                    addFish();
                }
                else
                {
                    buyAquarium();
                }
                goBack();

            }
        }

        void buyAquarium()
        {
            if (MyGame.CheckMouseInRectClick(clickToBuy))
            {
                clickToBuy.LateDestroy();
                isBought = true;
                AddChild(inv);
                level.currencySystem.RemoveMoney(priceOfAquarium);
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
                        if (fish.FishProgrss >= 3000)
                        {
                            Coin coin = new Coin(fish,level);
                            AddChild(coin);
                            fish.FishProgrss = 0;
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
            if (MyGame.CheckMouseInRectClick(downArrow))
            {
                isActive = false;
                level.isInScene = false;
                visible = false;
                if(HasChild(shop))
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
            

                if (isShopDisplayed == false)

                {
                    AddChild(shop);
                    isShopDisplayed = true;
                }
            
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
