using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Recursion.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(PickCoin(1, "alice", "bob") == "alice 1");
            Debug.Assert(PickCoin(2, "bob", "alice") == "bob 1");
            Debug.Assert(PickCoin(3, "alice", "bob") == "bob 2");

            Debug.Assert(PickCoin(4, "alice", "bob") == "alice 3");
            Debug.Assert(PickCoin(5, "alice", "bob") == "alice 2");
            Debug.Assert(PickCoin(6, "alice", "bob") == "bob 6");
            Debug.Assert(PickCoin(7, "alice", "bob") == "alice 8");
            Debug.Assert(PickCoin(8, "alice", "bob") == "alice 6");
            Debug.Assert(PickCoin(9, "alice", "bob") == "bob 16");

            Debug.Assert(PickCoin(10, "alice", "bob") == "alice 22");
            Debug.Assert(PickCoin(25, "alice", "bob") == "alice 3344");
            Debug.Assert(PickCoin(30, "alice", "bob") == "bob 18272");
        }

        static string PickCoin(int coins, string player1, string player2)
        {
            int result = Strategies(coins);
            string winner = result < 0 ? player2 : player1;
            return string.Format("{0} {1}", winner, Math.Abs(result));
        }
        static int Strategies(int coins)
        {
            if (coins <= 0) return 0;
            if (coins <= 2) return 1;
//             if (coins == 4) return -(1 +Strategies(3));

            switch(coins % 3)
            {
                case (0):
                    return -(Strategies(coins - 1) + Strategies(coins - 2) + Strategies(coins - 4));
                    
                case (1):
                    return -(Strategies(coins - 1) + Strategies(coins - 4));
                    
                case (2):
                    return -Strategies(coins - 2);
            }
            throw new ArgumentOutOfRangeException("Should not get here.");
        }
    }
}
