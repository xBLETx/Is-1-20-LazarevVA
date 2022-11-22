using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Is_1_20_LazarevVA
{
    public class norm_Button : Control
    {
        private StringFormat SF = new StringFormat();
        private bool MouseEntered = false;
        private bool MousePressed = false;
        public norm_Button()
        {
            // оптимизация кастомной кнопки
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new System.Drawing.Size(100, 10);
            BackColor = Color.Gray;
            ForeColor = Color.White;
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }
        //метод перерисовки кнопки при изменении параметров кнопки
        protected override void OnPaint(PaintEventArgs e)
        {
            //базовый метод
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.Clear(Parent.BackColor);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            graph.DrawRectangle(new Pen(BackColor), rect);
            graph.FillRectangle(new SolidBrush(BackColor), rect);
            if(MouseEntered)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(30,Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
            }
            if (MousePressed)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);

        }
        //метод вызывающий событие сраб при курсоре на батоне
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;
            Invalidate();  
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = true;
            Invalidate();
        }
    }
}
