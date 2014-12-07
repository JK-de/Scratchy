using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media.Media3D;
using System.Windows.Forms;

namespace Scratchy
{
    public partial class Scratch
    {
        //public Bitmap Image;

        public ScratchData _data;
        public ScratchRender _render;

        public Scratch()
        {
            _data = new ScratchData();
            _render = new ScratchRender(_data);
        }

        public void UpdateImage()
        {
            _render.Render();
        }

        public Bitmap GetImage()
        {
            return _render.GetImage();
        }

    }
}
