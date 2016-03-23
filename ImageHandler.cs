using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class ImageHandler
    {
        public List<Image> Images { get; set; }
        public Image Image { get; }

        private int _point;

        public int point
        {
            get { return this._point; }
            set {
                if ((value >= Images.Count) || (value < 0))
                {
                    _point = 0;
                }
                else {
                    this._point = value;
                }
                 }
        }



        public ImageHandler()
        {
            Images = new List<Image>();
            var files = Directory.GetFiles(@"C:\Users\Anders\Documents\cards", "*.gif");
            
           

            foreach (var file in files)
            {
              
                Images.Add(Image.FromFile(file));
            }
            _point = 0;
        }

        public Image GetNextImage()
        {
            _point++;

            if (_point >= Images.Count)
            
                _point = 0;
            

            return Images[_point];
        }
    }
}
