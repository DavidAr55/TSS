using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Teachers_Strike_Simulator
{
    class Escenario1
    {
        Vector2 pos_Plataforma;
        Texture2D Fondo, Plataforma;
        BoundingBox BPlataforma_Arr;

        public Escenario1(Texture2D FondoM1, Vector2 pos_Plataforma1, Texture2D Plataforma1)
        {
            this.Fondo = FondoM1;
            this.pos_Plataforma = pos_Plataforma1;
            this.Plataforma = Plataforma1;
        }

        public void UpDate(GameTime gameTime)
        {
            BPlataforma_Arr = new BoundingBox(new Vector3(pos_Plataforma.X, pos_Plataforma.Y, 0), new Vector3(pos_Plataforma.X + Plataforma.Width, pos_Plataforma.Y + 2, 0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Fondo, Vector2.Zero, Color.White);
        }
    }
}
