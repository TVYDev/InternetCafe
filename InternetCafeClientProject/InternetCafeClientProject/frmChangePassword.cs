using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafeClientProject
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        Boolean pwCheck = false;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != null && txtNewpassword != null && txtConfirmNew.Text != null)
            {

                client_forms.Form1.com.CommandText = "select * from tbCustomer WHERE accName = '" + client_forms.Form1.username + "'";
                client_forms.Form1.dr = client_forms.Form1.com.ExecuteReader();
                while (client_forms.Form1.dr.Read())
                {
                    if (client_forms.Form1.dr[1].ToString() == txtOldPassword.Text)
                    {
                        if (txtNewpassword.Text == txtConfirmNew.Text)
                        {

                            pwCheck = true;
                            MessageBox.Show("Password Changed");
                        }
                    }
                    else {
                        MessageBox.Show("Sorry Invailed Oldpassword");

                    }

                }
                client_forms.Form1.dr.Close();
                client_forms.Form1.dr.Dispose();
            }

            if (pwCheck == true) {
                client_forms.Form1.com.CommandText = "UPDATE tbCustomer SET pwd = '" + txtNewpassword.Text + "' WHERE accName ='" + client_forms.Form1.username + "'";
                client_forms.Form1.com.ExecuteNonQuery();
            }
        }
    }
}
