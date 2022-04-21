using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace GeneticAlgorithmTimetablingSystem
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class HardConstraints : UserControl
    {
        public HardConstraints()
        {
            InitializeComponent();
        }

        private string _title;
        [Category("Custom Props")]
        public string GetTitle { get { return _title; } set { _title = value; Title.Text = value; } }

        private string _label;
        [Category("Custom Props")]
        public string GetLabel {get { return _label; } set { _label = value; description.Text = value; } }

        private Image _image;
        [Category("Custom Props")]
        public Image GetImage {get { return _image; } set { _image = value; pbConstraint.Image = value; } }

    }
}
