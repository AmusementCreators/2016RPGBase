using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016RPGBase.Scene
{
    sealed class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();
            var bg = new asd.TextureObject2D();
            bg.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            layer.AddObject(bg);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                asd.Engine.ChangeScene(new Field());
            }
        }
    }
}
