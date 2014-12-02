using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;
using Winterdom.Design.TypeEditors;
namespace POS.Control
{
    /*
     [Browsable(bool)] – to show property or not
    [ReadOnly(bool)] – possibility to edit property
    [Category(string)] – groups of property
    [Description(string)] – property description. It is something like a hint.
    [DisplayName(string)] – display property
     */
    public class ControPropertiesDTO
    {
        private DragItem dragItem;
        private string _text;
        private string _backgroupnPath;
        [Category("Font")]
        public string Text { get { return _text; } set { _text = value; dragItem.Refresh(); } }
        [Category("Font")]
        public Font Font { get { return this.dragItem.Font; } set { this.dragItem.Font = value; this.dragItem.Refresh(); } }
        [Category("Font")]
        public Color ForeColor { get { return this.dragItem.ForeColor; } set { this.dragItem.ForeColor = value; this.dragItem.Refresh(); } }


        [Category("BackGroupd")]
        public Color BackGroupdColor { get { return this.dragItem.BackColor; } set { this.dragItem.BackColor = value; dragItem.Refresh(); } }
        [Category("BackGroupd")]
        public ImageLayout BackGroundLayout { get { return this.dragItem.BackgroundImageLayout; } set { this.dragItem.BackgroundImageLayout = value; dragItem.Refresh(); } }
        [Category("BackGroupd")]
        [Editor(typeof(FileSelectorTypeEditor), typeof(UITypeEditor))]
        public string BackGroundImage
        {
            get { return _backgroupnPath; }
            set
            {
                _backgroupnPath = value;
                this.dragItem.BackgroundImage = Image.FromFile(_backgroupnPath);
                this.dragItem.Refresh();
            }
        }
        [Category("BackGroupd")]
        public BorderStyle BorderStyle { get { return this.dragItem.BorderStyle; } set { this.dragItem.BorderStyle = value; dragItem.Refresh(); } }

        [Category("Position")]
        public int Top { get { return this.dragItem.Top; } set { this.dragItem.Top = value; this.dragItem.Refresh(); } }
        [Category("Position")]
        public int Left { get { return this.dragItem.Left; } set { this.dragItem.Left = value; this.dragItem.Refresh(); } }
        [Category("Position")]
        public Size Size { get { return this.dragItem.Size; } set { this.dragItem.Size = value; this.dragItem.Refresh(); } }


        public ControPropertiesDTO(DragItem dragItem)
        {
            // TODO: Complete member initialization
            this.dragItem = dragItem;

            //Get Font Text
            Font font1 = new Font("Arial", 12, FontStyle.Italic);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            // Saving Font object as a string
            string fontString = converter.ConvertToString(font1);
            // Load an instance of Font from a string
            Font font = (Font)converter.ConvertFromString(fontString);


            //Get Color Int 
            int bC = this.dragItem.BackColor.ToArgb();
            Color tBc = Color.FromArgb(bC);

        }

    }
}
