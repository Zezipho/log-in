using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_in
{
    public partial class Principal_Details : UserControl
    {

        String CS = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        String TenResults = "";
        String NineResults = "";
        String EightResults = "";

        public Principal_Details()
        {
            InitializeComponent();


        }
    }
}
