using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockbrokerProNewArch
{
    public partial class ImageViewer : Form
    {
        private Image _image;
        private float _xStart;
        private float _yStart;
        private float _xEnd;
        private float _yEnd;
        private float _zoomFactor;

        public ImageViewer(Image image)
        {
            InitializeComponent();
            _image = image;
            _xStart = 0;
            _yStart = 0;
            _xEnd = 0;
            _yEnd = 0;
            _zoomFactor = 1;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void ProcessZooming(Image image)
        {
            float panelWidth = imgPanel.Width;
            float panelHeight = imgPanel.Height;
            float imageWidth = image.Width;
            float imageHeight = image.Height;

            _xEnd = imageWidth*_zoomFactor;
            _yEnd = imageHeight*_zoomFactor;

            if (panelWidth > (imageWidth * _zoomFactor))
            {
                _xStart = (panelWidth - (imageWidth*_zoomFactor))/2;
            }
            else
            {
                _xStart = 0;
            }
            AutoScrollMinSize = new Size((int)_xEnd,(int)_yEnd);
        }

        private void imgPanel_Paint(object sender, PaintEventArgs e)
        {
            ProcessZooming(_image);
            Graphics graphics = e.Graphics;
            graphics.TranslateTransform(imgPanel.AutoScrollPosition.X, imgPanel.AutoScrollPosition.Y);
            graphics.DrawImage(_image,_xStart,_yStart,_xEnd,_yEnd);
            base.OnPaint(e);
        }


        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            _zoomFactor = (float)(_zoomFactor + 0.2);
            imgPanel.Invalidate();
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            if(_zoomFactor <= 0)
                return;
            _zoomFactor = (float)(_zoomFactor - 0.2);
            imgPanel.Invalidate();
        }

        private void tsbRotateLeft_Click(object sender, EventArgs e)
        {
            _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imgPanel.Invalidate();
        }
    }
}
