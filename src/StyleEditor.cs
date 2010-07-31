using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nodepad
{
    public partial class StyleEditor : Form
    {
        public IList<Style> Styles;

        public StyleEditor(IList<Style> i_styles)
        {
            InitializeComponent();
            Styles = i_styles;

            refresh_style_list();
            refresh_button_states();

            refresh_font_list();
            refresh_position_list();

            read_style_into_controls((Style)styleListBox.SelectedItem);
            update_preview();
        }

        public void SelectStyle(Style s)
        {
            styleListBox.SelectedItem = s;
        }

        private Style find_style(String style_name)
        {
            foreach (Style s in styleListBox.Items)
            {
                if (s.Name == style_name)
                    return s;
            }

            return null;
        }

        private void read_style_into_controls(Style s)
        {
            styleNameTextBox.Text = s.Name;
            fontListBox.SelectedItem = s.Font.FontFamily.Name;
            fontSizeBox.Value = (decimal)s.Font.Size;
            positionComboBox.SelectedItem = s.Alignment;
            styleColorButton.BackColor = s.Color;
        }

        private void update_preview()
        {
            stylePreviewBox.SelectAll();

            ((Style)styleListBox.SelectedItem).Apply(stylePreviewBox);

            stylePreviewBox.Select(0, 0);
        }

        private void styleColorButton_Click(object sender, EventArgs e)
        {
            styleColorDialog.ShowDialog();

            styleColorButton.BackColor = styleColorDialog.Color;
            ((Style)styleListBox.SelectedItem).Color = styleColorDialog.Color;

            update_preview();
        }

        private void styleEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Styles.Clear();
            foreach (Style s in styleListBox.Items)
            {
                this.Styles.Add(s);
            }
        }

        private void refresh_style_list()
        {
            styleListBox.Items.Clear();

            foreach (Style s in Styles)
            {
                styleListBox.Items.Add(s);
            }

            styleListBox.SelectedItem = styleListBox.Items[0];
        }

        private void refresh_font_list()
        {
            fontListBox.Items.Clear();
            fontListBox.BeginUpdate();
            foreach (FontFamily ff in FontFamily.Families)
            {
                if (ff.IsStyleAvailable(FontStyle.Regular) && ff.IsStyleAvailable(FontStyle.Bold) && ff.IsStyleAvailable(FontStyle.Italic))
                {
                    fontListBox.Items.Add(ff.Name);
                }
            }
            fontListBox.EndUpdate();
        }

        private void refresh_position_list()
        {
            positionComboBox.Items.Clear();
            positionComboBox.BeginUpdate();
            positionComboBox.Items.Add(HorizontalAlignment.Left);
            positionComboBox.Items.Add(HorizontalAlignment.Center);
            positionComboBox.Items.Add(HorizontalAlignment.Right);
            positionComboBox.EndUpdate();
        }

        private void fontSizeBox_ValueChanged(object sender, EventArgs e)
        {
            ((Style)styleListBox.SelectedItem).Font = new Font(((Style)styleListBox.SelectedItem).Font.FontFamily, (float)fontSizeBox.Value);
            update_preview();
        }

        private void fontListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Style)styleListBox.SelectedItem).Font = new Font((string)fontListBox.SelectedItem, ((Style)styleListBox.SelectedItem).Font.Size);
            update_preview();
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Style)styleListBox.SelectedItem).Alignment = (HorizontalAlignment)positionComboBox.SelectedItem;
            update_preview();
        }

        private void styleNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ((Style)styleListBox.SelectedItem).Name = styleNameTextBox.Text;
            styleListBox.Items[styleListBox.SelectedIndex] = styleListBox.SelectedItem;
        }

        private void styleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (styleListBox.SelectedItem != null)
            {
                read_style_into_controls((Style)styleListBox.SelectedItem);
                update_preview();
            }

            refresh_button_states();
        }

        private void addStyleButton_Click(object sender, EventArgs e)
        {
            Style s = new Style("New style");
            styleListBox.Items.Insert(styleListBox.SelectedIndex + 1, s);
            styleListBox.SelectedItem = s;
        }

        private void removeStyleButton_Click(object sender, EventArgs e)
        {
            int old_si = styleListBox.SelectedIndex;
            styleListBox.Items.Remove(styleListBox.SelectedItem);
            styleListBox.SelectedIndex = System.Math.Min(old_si, styleListBox.Items.Count - 1);
            refresh_button_states();
        }

        private void refresh_button_states()
        {
            moveStyleDownButton.Enabled = ((styleListBox.SelectedIndex + 1) < styleListBox.Items.Count);
            moveStyleUpButton.Enabled = (styleListBox.SelectedIndex > 0);
            removeStyleButton.Enabled = (styleListBox.Items.Count > 1);
        }

        private void moveStyleUpButton_Click(object sender, EventArgs e)
        {
            int si = styleListBox.SelectedIndex;
            switch_styles(si, si - 1);
            styleListBox.SelectedIndex = si - 1;
        }

        private void moveStyleDownButton_Click(object sender, EventArgs e)
        {
            int si = styleListBox.SelectedIndex;
            switch_styles(si, si + 1);
            styleListBox.SelectedIndex = si + 1;
        }

        private void switch_styles(int index_a, int index_b)
        {
            Style a = (Style)styleListBox.Items[index_a];
            Style b = (Style)styleListBox.Items[index_b];
            styleListBox.Items[index_a] = b;
            styleListBox.Items[index_b] = a;
        }
    }
}