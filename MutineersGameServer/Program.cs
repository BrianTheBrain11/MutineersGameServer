using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;


namespace MutineersGameServer
{
	class Program
	{
		private static bool isRunning = false;

		static void Main(string[] args)
		{

			Console.Title = "Mutineers Game Server";
			Console.WriteLine("Mutineers Game Server Software Started");
			isRunning = true;

			Thread mainThread = new Thread(new ThreadStart(MainThread));
			mainThread.Start();

			int playerCount, port;

			Console.Write("What is the player limit?");
			playerCount = Int32.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("What port should I start on?");
			port = Int32.Parse(Console.ReadLine());
			if (port == 0)
            {
				port = 26950;
            }

			NetworkManager.Start(playerCount, port);
		}

		private static void MainThread()
        {
			Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
			DateTime _nextLoop = DateTime.Now;

			while (isRunning)
            {
				while (_nextLoop < DateTime.Now)
                {
					//GameLogic.Update();
					_nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

					if (_nextLoop > DateTime.Now)
                    {
						Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
	}
}
