using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class BranchReport : Form
    {
        public BranchReport()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GenerateTree();
        }
        private void GenerateTree()
        {
            treeView.Nodes.Clear();
            DataTable dataTable;
            ManagementViewBAL managementViewBal = new ManagementViewBAL();
            dataTable = managementViewBal.GetBranchReport(dtDate.Value.Month, dtDate.Value.Year);

            TreeNode mainNode = new TreeNode();
            mainNode.Name = "mainNode";
            mainNode.Text = "K-Securities & Consultants Ltd";
            mainNode.ForeColor = Color.Green;
            treeView.Nodes.Add(mainNode);


            int track = 1;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                TreeNode brNode = new TreeNode();
                brNode.Name = "brNode" + track;
                brNode.Text = dataRow[0].ToString();
                brNode.ForeColor = Color.DarkRed;
                mainNode.Nodes.Add(brNode);

                int rowCounter = 0;
                foreach (object value in dataRow.ItemArray)
                {
                    if (rowCounter != 0)
                        AddNode(brNode, dataTable.Columns[rowCounter].ColumnName + " = " + value.ToString());
                    ++rowCounter;
                }
                ++track;
            }
        }
        private void AddNode(TreeNode parentNode, string text)
        {
            TreeNode treeNode = new TreeNode(text);
            parentNode.Nodes.Add(treeNode);
        }

        private void BranchReport_Load(object sender, EventArgs e)
        {

            dtDate.Value = DateTime.Today;
            GenerateTree();
        }
    }
}
