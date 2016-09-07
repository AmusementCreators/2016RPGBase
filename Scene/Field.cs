using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2016RPGBase.Scene
{
    sealed class Field : asd.Scene
    {
        public class Data
        {
            public Data()
            {
                Player = new Charactor.Player(this);
            }

            public MapTip At(asd.Vector2DF pos)
            {
                int x = (int)pos.X / Resource.Chip.Width;
                int y = (int)pos.Y / Resource.Chip.Height;
                return Chips[x, y];
            }

            public Charactor.Player Player { get; set; }
            public MapTip[,] Chips { get; set; }
        }

        public Field()
        {
            camera.Src = new asd.RectI(new asd.Vector2DI(), Resource.Window.Size.To2DI());
            camera.Dst = new asd.RectI(new asd.Vector2DI(), Resource.Window.Size.To2DI());
            gameLayer.AddObject(camera);

            LoadMap();

            gameLayer.AddObject(data.Player);
            AddLayer(gameLayer);

            AddLayer(messageLayer);
        }

        protected override void OnUpdated()
        {
           camera.Src = new asd.RectI(data.Player.Position.To2DI() - camera.Src.Size / 2, camera.Src.Size);
        }


        private void LoadMap()
        {
            var map = new asd.MapObject2D();
            using (var img = new Bitmap(Image.FromFile("Resource/map1.bmp")))
            {
                data.Chips = new MapTip[img.Width, img.Height];
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        var color = img.GetPixel(x, y);
                        var position = new asd.Vector2DF(x * Resource.Chip.Width, y * Resource.Chip.Height);
                        data.Chips[x, y] = new MapTip(color, position, data);
                        map.AddChip(data.Chips[x, y]);
                    }
                }
            }

            gameLayer.AddObject(map);
        }

        public void MessageMode()
        {
            messageLayer.Enable();
        }
        asd.CameraObject2D camera = new asd.CameraObject2D();
        asd.Layer2D gameLayer = new asd.Layer2D();
        Layer.Message messageLayer = new Layer.Message();
        Data data = new Data();
    }
}
