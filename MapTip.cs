using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016RPGBase
{
    class MapTip : asd.Chip2D
    {
        public enum Type
        {
            Ground,
            Wall,
            Event
        }

        public MapTip(System.Drawing.Color color, asd.Vector2DF pos, Scene.Field.Data data)
        {
            Texture = Resource.CharactorGraph;
            if (color.R == 255)
            {
                type = Type.Wall;
                if (color.G == 0 && color.B == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Wall);
                else if (color.G == 100 && color.B == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Block);
                else if (color.G == 150 && color.B == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Table);
                if (color.B == 200)
                {
                    if (color.G == 40)
                        Src = Resource.GraphSrc(Resource.GraphType.PartitionVertical);
                    else if (color.G == 80)
                        Src = Resource.GraphSrc(Resource.GraphType.PatitionHorizontal);
                    else if (color.G == 120)
                        Src = Resource.GraphSrc(Resource.GraphType.PartitionLeftTop);
                    else if (color.G == 160)
                        Src = Resource.GraphSrc(Resource.GraphType.PartitionRightTop);
                    else if (color.G == 200)
                        Src = Resource.GraphSrc(Resource.GraphType.PartitionLeftBottom);
                    else if (color.G == 240)
                        Src = Resource.GraphSrc(Resource.GraphType.PartitionRightBottom);
                }
            }
            else if (color.G == 255)
            {
                type = Type.Ground;
                if (color.R == 0 && color.B == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Ground);
                else if (color.R == 200 && color.B == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Step);
                else if (color.R == 0 && color.B == 100)
                    Src = Resource.GraphSrc(Resource.GraphType.Person);
                else if (color.R == 100 && color.B == 100)
                {
                    Src = Resource.GraphSrc(Resource.GraphType.Ground);
                    data.Player.Position = pos;
                }
            }
            else if (color.B == 255)
            {
                type = Type.Event;
                if (color.G == 0 && color.R == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Ground);
                else if (color.G == 100 && color.R == 0)
                    Src = Resource.GraphSrc(Resource.GraphType.Table);
            }
            Position = pos;
        }

        public Type type { get; set; } = Type.Ground;
    }
}
