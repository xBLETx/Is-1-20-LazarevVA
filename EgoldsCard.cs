using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EgoldsUI;

namespace Is_1_20_LazarevVA
{
    public class EgoldsCard: Control
    {
        #region Переменные
        private float CurtainHeight;//высота шторки баз


        #endregion
        #region свойства
        public Color BackColorCurtain { get; set; } = FlatColors.Red;
        public string TextHeader { get; set; } = "Header";//текст
        public Font FontHeader { get; set; } = new Font("Verdana", 12F, FontStyle.Bold);//свойство шрифта
         //цвет шрифта

        #endregion
        public EgoldsCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(250, 200);
            CurtainHeight = Height - 60;

            Font = new Font("Verdana", 9F, FontStyle.Regular);
            BackColor = Color.White;
            CurtainHeight = Height - 60;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;

            graph.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle rectCurtain = new Rectangle(0, 0, Width - 1, (int)CurtainHeight);

            //Фон
            graph.FillRectangle(new SolidBrush(BackColor), rect);

            //Шторка
            graph.DrawRectangle(new Pen(BackColorCurtain), rectCurtain);
            graph.FillRectangle(new SolidBrush(BackColorCurtain), rectCurtain);

            //Обводка
            graph.DrawRectangle(new Pen(FlatColors.Gray), rect);

        }
    }
}
