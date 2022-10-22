using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class Teacher_ViewReport : UserControl
    {
        public System.Windows.Forms.AutoSizeMode AutoSizeMode { get; set; }
        public Teacher_ViewReport()
        {
            InitializeComponent();
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }
    }
}
