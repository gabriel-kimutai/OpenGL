using OpenGLTutorial.GameLoop;
using GLFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenGL.OpenGL.GL;
using OpenGL.Rendering.Display;

namespace OpenGLTutorial
{
    class TestGame : Game
    {

        uint vao;
        uint vbo;

        public TestGame(int initialWindowWidth, int initialWindowHeight, string? initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
        }

        protected override void Initialize()
        {
        }

        protected unsafe override void LoadContent()
        {
            // create vao and vbo
            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);

            glBindBuffer(GL_ARRAY_BUFFER, 0);

            float[] vertices =
            {
                -0.5f, 0.5f, 1f, 0f, 0f, // top left
                0.5f, 0.5f, 0f, 1f, 0f,// top right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left

                0.5f, 0.5f, 0f, 1f, 0f,// top right
                0.5f, -0.5f, 0f, 1f, 1f, // bottom right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left
            };

            fixed(float* v = &vertices[0])
            {

                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);

            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);

        }

        protected override void Update()
        {
        }

        protected override void Render()
        {
            glClearColor(0, 0, 0, 0);
            glClear(GL_COLOR_BUFFER_BIT);

            glBindVertexArray(vao);
            glDrawArrays(GL_TRIANGLES, 0, 0);
            glBindVertexArray(0);

            Glfw.SwapBuffers(DisplayManager.Window);
        }

    }
}
