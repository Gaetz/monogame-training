using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _09._3dTest
{
    public class Ship
    {
        private Model model;
        private Vector3 position;
        private float angle;
        private Matrix world;

        public void Load(ContentManager content)
        {
            model = content.Load<Model>("Ship");
            position = new Vector3(0, 5.0f, 0);
            angle = 0;
        }

        public void Update(double dt)
        {
            position += new Vector3(0, -1.0f * (float)dt, 0);
            angle += float.Pi * 2 * (float)dt;
            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position);
        }

        public void Draw(Matrix view, Matrix projection, DirectionalLight light)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.DirectionalLight0.DiffuseColor = light.diffuseColor;
                    effect.DirectionalLight0.Direction = light.direction;
                    effect.DirectionalLight0.SpecularColor = light.specularColor;
                    effect.AmbientLightColor = light.ambiantColor;
                    //effect.EmissiveColor = new Vector3(1, 0, 0);

                    effect.FogEnabled = true;
                    effect.FogColor = Color.CornflowerBlue.ToVector3();
                    effect.FogStart = 9.75f;
                    effect.FogEnd = 10.25f;

                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}
