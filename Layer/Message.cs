using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016RPGBase.Layer
{
    class Message : asd.Layer2D
    {
        public Message()
        {
            var obj = new asd.GeometryObject2D();
            var rect = new asd.RectangleShape();
            // TODO
            rect.DrawingArea = new asd.RectF(-300, -80, 600, 160);
            obj.Shape = rect;
            obj.Position = new asd.Vector2DF(320, 390);
            obj.Color = new asd.Color(50, 50, 150);
            AddObject(obj);

            messageLabel.Font = Resource.Font;
            messageLabel.Position = obj.Position + new asd.Vector2DF(-300, -80) + new asd.Vector2DF(32, 32);
            AddObject(messageLabel);

            IsUpdated = false;
            IsDrawn = false;
        }

        public void Enable()
        {
            foreach (var layer in Scene.Layers)
                layer.IsUpdated = layer == this;
            count = 0;
            IsDrawn = true;
        }

        protected override void OnUpdated()
        {
            count++;
            if (count <= text.Length * slowness)
                messageLabel.Text = text.Substring(0, count / slowness);
            else
                messageLabel.Text = text;

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                if (count > text.Length * slowness)
                {
                    foreach (var layer in Scene.Layers)
                        layer.IsUpdated = layer != this;
                    IsDrawn = false;
                }
                else
                {
                    count = text.Length * slowness;
                }
            }
        }

        private asd.TextObject2D messageLabel = new asd.TextObject2D();
        private string text = "これはイベントとかが起こった時に表示されるメッセージです\nZキーで閉じます";
        private const int slowness = 3;
        private int count = 0;
    }
}
