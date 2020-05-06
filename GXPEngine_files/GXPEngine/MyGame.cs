using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;

public class MyGame : Game
{
	Button test;
	Level level;
	bool isPlaying;

	public MyGame() : base(1200, 720, false)        // Create a window that's 800x600 and NOT fullscreen
	{
		isPlaying = false;
		test = new Button(new Vec2(width / 2, height / 2 - 100), "playbutton.png");
		AddChild(test);
		//Scene scene = new Scene("fishtanksample.png");
		//AddChild(scene);
	}

	void Update()
	{
		if (CheckMouseInRect(test) && !isPlaying)
		{
			level = new Level();
			AddChild(level);
			isPlaying = true;
		}

	}


	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}

	public static bool CheckMouseInRect(Button button)
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Input.mouseX > button.x && Input.mouseX < button.x + button.Width &&
				Input.mouseY > button.y && Input.mouseY < button.y + button.Height)
			{
				return true;
			}
			return false;
		}
		else return false;
	}

	public static bool CheckMouseInRect(Sprite sprite)
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Input.mouseX > sprite.x && Input.mouseX < sprite.x + sprite.width &&
				Input.mouseY > sprite.y && Input.mouseY < sprite.y + sprite.height)
			{
				return true;
			}
			return false;
		}
		else return false;
	}

}