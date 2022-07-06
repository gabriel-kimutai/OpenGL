﻿using OpenGLTutorial;
using OpenGLTutorial.GameLoop;

namespace OpenGL
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new TestGame(800, 600, "Test");
            game.Run();
        }
    }
}