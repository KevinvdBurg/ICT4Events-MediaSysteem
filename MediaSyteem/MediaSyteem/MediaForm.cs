﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSyteem
{
    public partial class MediaForm : Form
    {

        private Administation admini;
        private int currentPostReplies = 0;

        public MediaForm(Administation admin)
        {
            InitializeComponent();
            //TESTJES
            /*this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");
            this.dgvPosts.Rows.Add("Titeltje");*/
            admini = admin;
            
            resizeGrid();
            lblName2.Text = admin.currentAccount.Person.Name;
            lblRFID2.Text = admin.currentAccount.RFID;
            
        }

        private void btnNewPost_Click(object sender, EventArgs e)
        {
            tabCPosts.SelectedIndex = 1;
        }

        private void resizeGrid()
        {
            dgvPosts.Rows.Clear();
            foreach (Post p in admini.returnAllPosts())
            {
                dgvPosts.Rows.Add(p.Postid, p.Title, p.Likes, p.Reports);
            }

            int caseSwitch = dgvPosts.RowCount;
            switch (caseSwitch)
            {
                case 1:
                    dgvPosts.Height = 44;
                    break;
                case 2:
                    dgvPosts.Height = 66;
                    break;
                case 3:
                    dgvPosts.Height = 88;
                    break;
                case 4:
                    dgvPosts.Height = 110;
                    break;
                case 5:
                    dgvPosts.Height = 132;
                    break;
                case 6:
                    dgvPosts.Height = 154;
                    break;
                case 7:
                    dgvPosts.Height = 176;
                    break;
                case 8:
                    dgvPosts.Height = 198;
                    break;
                case 9:
                    dgvPosts.Height = 220;
                    break;
                case 10:
                    dgvPosts.Height = 242;
                    break;
                case 11:
                    dgvPosts.Height = 264;
                    break;
                default:
                    if (caseSwitch > 11)
                    {
                        dgvPosts.Height = 286;
                    }
                    
                    break;
                
                    
                
                    
            }
        }

        private void dgvPosts_DoubleClick(object sender, EventArgs e)
        {
            //tabCPosts.SelectedIndex = 2;
            //lblSelectedPostTitle.Text = admini.
            //tbSelectedPost.Text = admini.

        }

        private void btnSelectedPostReturn_Click(object sender, EventArgs e)
        {
            tabCPosts.SelectedIndex = 0;
            resizeGrid();
        }

        private void btnCancelPost_Click(object sender, EventArgs e)
        {
            tabCPosts.SelectedIndex = 0;
            resizeGrid();
        }

        private void btnConfirmPost_Click(object sender, EventArgs e)
        {
            bool Title = true;
            bool Inhoud = true;
            if (string.IsNullOrEmpty(tbPostnaam.Text))
            {
                MessageBox.Show("Vul de titel in");
                Title = false;

            }
            else if (string.IsNullOrEmpty(tbPostText.Text))
            {
                MessageBox.Show("Vul de inhoud in");
                Inhoud = false;
            }
            
            
            //testje
            if (string.IsNullOrEmpty(tbFilePath.Text))
            {
                if (Title && Inhoud)
                {
                    Post post = new Post(DateTime.Now, 0, 1, 0, tbPostnaam.Text, "Bericht");
                    post.Account = admini.currentAccount;
                    admini.Add(post, tbPostText.Text);
                }
            }
            tabCPosts.SelectedIndex = 0;
            resizeGrid();
        }

        private void MediaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbFilePath.Text = openFileDialog1.FileName;
        }

        private void dgvPosts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvPosts.CurrentCell.RowIndex;
            dgvPosts.Rows[index].Selected = true;
            
            btnOpenPost.PerformClick();
            //MessageBox.Show(dgvPosts.SelectedRows[0].Cells["postid"].ToString());
        }

        private void btnOpenPost_Click(object sender, EventArgs e)
        {
            int gridCount = 0;
            int value = 0;

            foreach (DataGridViewRow row in dgvPosts.SelectedRows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (gridCount == 0)
                    {
                        value = Convert.ToInt32(cell.Value);
                    }
                    gridCount++;
                }
            }
            lblSelectedPostTitle.Text = admini.postTitel(value);
            lblPostAuteur.Text = admini.PostAuteur(value);
            currentPostReplies = admini.NumberOfReplies(value);

            if (admini.isMessage(value))
            {
                tbSelectedPost.Text = admini.postText(value);
            }
            if (currentPostReplies > 0)
            {
                foreach (Post p in admini.ReturnAllReplies(value))
                {
                    dgvReplies.Rows.Add(p.Postid, p.Title, p.Likes, p.Reports);
                    
                }
            }
            tabCPosts.SelectedIndex = 2;
            
        }
  
        
    }
}
