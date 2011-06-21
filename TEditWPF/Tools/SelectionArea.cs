﻿
namespace TEditWPF.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;
    using TEditWPF.Common;
    using System.Windows;
    using TEditWPF.TerrariaWorld.Structures;

    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SelectionArea : ObservableObject
    {
        public SelectionArea()
        {
            this.Rectangle = new Int32Rect();
        }

        public void SetRectangle(PointInt32 p1, PointInt32 p2)
        {
            int x = p1.X < p2.X ? p1.X : p2.X;
            int y = p1.Y < p2.Y ? p1.Y : p2.Y;
            int width = (int)Math.Abs(p2.X - p1.X);
            int height = (int)Math.Abs(p2.Y - p1.Y);
            this.Rectangle = new Int32Rect(x, y, width, height);
        }

        public int SelectedArea
        {
            get
            {
                return this.Rectangle.Width * this.Rectangle.Height;
            }
        }

        private Int32Rect _Rectangle;
        public Int32Rect Rectangle
        {

            get { return this._Rectangle; }
            set
            {
                if (this._Rectangle != value)
                {
                    this._Rectangle = value;
                    this.RaisePropertyChanged("Rectangle");
                }
            }
        }


    }
}
