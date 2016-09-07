using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016RPGBase.Charactor
{
    class Player : asd.TextureObject2D
    {
        public Player(Scene.Field.Data data)
        {
            Texture = Resource.CharactorGraph;
            Src = Resource.GraphSrc(Resource.GraphType.Player);

            this.data = data;
        }

        protected override void OnUpdate()
        {
            if (count != 0)
            {
                Position += speed;
                count--;
                return;
            }

            speed = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                speed.X -= Resource.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                speed.X += Resource.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                speed.Y -= Resource.Chip.Height;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                speed.Y += Resource.Chip.Height;
            if (data.At(Position + speed).type == MapTip.Type.Event)
                (Layer.Scene as Scene.Field).MessageMode();
            if (data.At(Position + speed).type != MapTip.Type.Ground)
                speed = new asd.Vector2DF();
            speed /= MaxCount;
            count = MaxCount;
        }

        private const int MaxCount = 8;

        private Scene.Field.Data data;
        private int count = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
    }
}
