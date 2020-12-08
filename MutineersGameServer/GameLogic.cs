using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

public class GameLogic
{
	public static Timer aTimer;
	public static bool gameRunning = false;
	public static bool lobbyWaiting = true;
	public static bool inRound = false;
	public static int roundNumber = 0;

	public static void Update()
	{
		Player.FixedUpdate();

		if (!gameRunning)
		{
			Console.WriteLine("Waiting to start next round, hit enter to continue");
			Console.Read();
			gameRunning = true;
			lobbyWaiting = true;
			SetTimer(120000); //2 minutes
		} 
		else
		{

			if (inRound)
			{
				//logic update, send and receive packets


				if (lobbyWaiting)
				{
					if (/*amount of people to start roung*/true)
					{
						lobbyWaiting = false;
						SetTimer(false);
						SetTimer(6000);
					}
				}
				else if (!lobbyWaiting)
				{
					if (/*mutineer threshold past*/false)
					{
						GameEnd("Mutineers");
					}

					if (/*nomutineers*/false)
					{
						GameEnd("Pirates");
					}
					if (/*orderscompleted*/false)
                    {
						GameEnd("Pirates");
                    }
				}
			}
		}


	}
	public static void SetTimer(int _time)
	{
		aTimer = new Timer(_time);
		aTimer.Elapsed += onTimedEvent;
		aTimer.AutoReset = false;
		aTimer.Enabled = true;
	}
	public static void SetTimer(bool _reset)
	{
		if (!_reset)
		{
			aTimer = new Timer();
			aTimer.Enabled = false;
		}
	}

	private static void onTimedEvent(Object source, ElapsedEventArgs e)
	{
		RoundEnd();
	}

	public static void RoundEnd()
	{
		//do round end Routine
		//send vote packet
		//receive vote packet
		//send kill order to person who done died
		if (/*mutineer threshold past*/false)
		{
			GameEnd("Mutineers");
		}
		
		if (/*no mutineers left*/false)
		{
			GameEnd("Pirates");
		}

		SetTimer(60000);
	}

	public static void GameEnd(string winner)
	{

	}
}
