using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016RPGBase
{
    static class Resource
    {
        public static class Chip
        {
            public const int Width = 32;
            public const int Height = 32;
            public static asd.Vector2DF Size { get; } = new asd.Vector2DF(Width, Height);
        }

        public static class Window
        {
            public const int Width = 640;
            public const int Height = 480;
            public static asd.Vector2DF Size { get; set; } = new asd.Vector2DF(Width, Height);
        }

        public static asd.Texture2D CharactorGraph { get; set; }
        public static asd.Font Font { get; set; }

        static public void Init()
        {
            CharactorGraph = asd.Engine.Graphics.CreateTexture2D("Resource/charactors.png");
            Font = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 16, new asd.Color(255, 255, 255), 0, new asd.Color());
        }

        public enum GraphType
        {
            Ground,
            Wall,
            Step,
            Block,
            Table,
            Person,
            Player,
            PartitionVertical,
            PatitionHorizontal,
            PartitionLeftTop,
            PartitionLeftBottom,
            PartitionRightTop,
            PartitionRightBottom
        }
        static public asd.RectF GraphSrc(GraphType type)
        {
            var pos = new asd.Vector2DF();
            switch (type)
            {
                case GraphType.Ground:
                    pos = new asd.Vector2DF(0, 0);
                    break;
                case GraphType.Wall:
                    pos = new asd.Vector2DF(Resource.Chip.Width, 0);
                    break;
                case GraphType.Step:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 4, 0);
                    break;
                case GraphType.Block:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 5, 0);
                    break;
                case GraphType.Table:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 6, 0);
                    break;
                case GraphType.Person:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 7, 0);
                    break;
                case GraphType.Player:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 8, 0);
                    break;
                case GraphType.PartitionVertical:
                    pos = new asd.Vector2DF(0, Resource.Chip.Height);
                    break;
                case GraphType.PatitionHorizontal:
                    pos = new asd.Vector2DF(Resource.Chip.Width, Resource.Chip.Height);
                    break;
                case GraphType.PartitionLeftTop:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 2, 0);
                    break;
                case GraphType.PartitionRightTop:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 3, 0);
                    break;
                case GraphType.PartitionLeftBottom:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 2, Resource.Chip.Height);
                    break;
                case GraphType.PartitionRightBottom:
                    pos = new asd.Vector2DF(Resource.Chip.Width * 3, Resource.Chip.Height);
                    break;
            }
            return new asd.RectF(pos, Resource.Chip.Size);
        }
    }
}
