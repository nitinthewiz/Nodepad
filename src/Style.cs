using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Nodepad
{
    public class Style
    {
        public String Name = null;

        public System.Drawing.Font Font;
        public System.Drawing.Color Color;
        public System.Windows.Forms.HorizontalAlignment Alignment;

        public Style(System.Windows.Forms.RichTextBox textbox)
        {
            this.Font = textbox.SelectionFont;
            this.Alignment = textbox.SelectionAlignment;
            this.Color = textbox.SelectionColor;
        }

        public bool IsInvalid()
        {
            return (this.Font == null) || (Convert.ToInt32(this.Font.Size) == 13) || (this.Color == System.Drawing.Color.Empty);
        }

        public Style(String name)
        {
            this.Name = name;

            this.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, (float)12);
            this.Color = EditorWindow.DefaultForeColor;
            this.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
        }

        public Style(String name, System.Drawing.Font font, System.Drawing.Color color, System.Windows.Forms.HorizontalAlignment alignment)
        {
            this.Name = name;
            this.Font = font;
            this.Color = System.Drawing.Color.FromArgb(color.ToArgb());
            this.Alignment = alignment;
        }

        public bool Equivalent(Style s)
        {
            bool aiv = this.IsInvalid();
            bool biv = s.IsInvalid();
            if (aiv || biv)
                return (aiv && biv);

            bool test = (
                (this.Font.FontFamily.Equals(s.Font.FontFamily) &&
                Convert.ToInt32(this.Font.Size).Equals(Convert.ToInt32(s.Font.Size))) &&
            this.Color.ToArgb().Equals(s.Color.ToArgb()) &&
            this.Alignment.Equals(s.Alignment));

            return test;
        }

        public void Apply(System.Windows.Forms.RichTextBox textbox)
        {
            textbox.SelectionColor = this.Color;
            textbox.SelectionFont = this.Font;
            textbox.SelectionAlignment = this.Alignment;
        }

        public void ApplyAsDefault(System.Windows.Forms.RichTextBox textbox)
        {
            textbox.ForeColor = this.Color;
            textbox.Font = this.Font;

            int tb_prev_sel_start = textbox.SelectionStart;
            int tb_prev_sel_len = textbox.SelectionLength;

            textbox.SelectAll();
            textbox.SelectionAlignment = this.Alignment;
            textbox.Select(tb_prev_sel_start, tb_prev_sel_len);
        }


        override public String ToString()
        {
            if (this.Name != null)
            {
                return this.Name;
            }
            else
            {
                return "Style[" + ((this.Font != null) ? this.Font.ToString() : "null")+ ", " + this.Alignment.ToString() + ", " + this.Color.ToString() + "]";
            }
        }

        public static Style Empty()
        {
            return new Style("", null, System.Drawing.Color.Empty, System.Windows.Forms.HorizontalAlignment.Left);
        }
    }
}
