using System;
using System.Collections.Generic;
using golf_card.Models;

namespace golf_card
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var gm = new GameManager();
            gm.NewGame();
        }
    }
}
