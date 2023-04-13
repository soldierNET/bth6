using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bth6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static List<User> listUser = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuVaoGridView();
               /* GridView1.DataSource = listUser;
                this.DataBind();*/
            }
        }

        public int CheckUser(User user)
        {
            for (int i = 0; i < listUser.Count; i++)
                if (listUser[i].UserName.Equals(user.UserName))
                    return i;
            return -1;
        }
        public User LayDuLieuTuForm()
        {
            bool gender = Boolean.Parse(rblGender.SelectedValue.ToString());
            User user = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Gender = gender,
                Address = txtAddress.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
            };
            return user;
        }
        public User LayDuLieuTuForm1() 
        {
            bool gender = Boolean.Parse(rblGender.SelectedValue.ToString());
            User user = new User(txtFirstName.Text, txtLastName.Text, txtEmail.Text,
                            gender, txtAddress.Text, txtUserName.Text, txtPassword.Text);
            return user;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.checkUser(user.UserName);
            if (exist)
            {
                lblMessage.Text = "Username da ton tai";
            }
            else
            {
                bool result = userDAO.Insert(user);
                if (result)
                {
                    lblMessage.Text = "Dang ky thanh cong";
                }
                else
                {
                    lblMessage.Text = "Co loi. Vui long thu lai sau";
                }
            }
            /*if (CheckUser(us) != -1)
                lblMessage.Text = "Trùng dữ liệu";
            else
            {
                listUser.Add(us);
                GridView1.DataSource = listUser;
                GridView1.DataBind();
            }*/
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDAO userDAO = new UserDAO();
            bool exist = userDAO.checkUser(user.UserName);
            if (!exist)
            {
                lblMessage.Text = "Username khong ton tai";
            }
            else
            {
                bool result = userDAO.Remove(user);
                if (result)
                {
                    lblMessage.Text = " thanh cong";
                }
                else
                {
                    lblMessage.Text = "Co loi. Vui long thu lai sau";
                }
            }
            /* User us = LayDuLieuTuForm();
             if (CheckUser(us) != -1 ) 
             {
                 listUser.RemoveAt(CheckUser(us));
                 GridView1.DataSource = listUser;
                 GridView1.DataBind(); 
             }
             else
                 lblMessage.Text = "không có dữ liệu";*/
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            User us = LayDuLieuTuForm();
            if (CheckUser(us) != -1)
            {
                listUser.RemoveAll(u => u.UserName != null);
                GridView1.DataSource = listUser;
                GridView1.DataBind();
            }
            else
                lblMessage.Text = "Đã trống form";
        }
        private void LayDuLieuVaoGridView()
        {
            UserDAO userDAO = new UserDAO();
            GridView1.DataSource = userDAO.GetAllUsers();
            GridView1.DataBind();
        }
    }
}