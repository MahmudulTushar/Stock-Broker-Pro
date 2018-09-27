using System;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using System.Data;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class FGMainForm : Form
    {
        public FGMainForm()
        {
            InitializeComponent();
        }


        private void btnViewCustAccInfo_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter = 1;
                frmcustomerAccInfo.Show();
            }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();

        }

        private void btnViewTermsandCond_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
                
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
             {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 11;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewTermsandCond2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
               
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
              {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 8;
            frmcustomerAccInfo.Show();
               }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewBoAccOpen_Click(object sender, EventArgs e)
        {
            

            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 2;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewBoAccOpen2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 3;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewByeLaws_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();    
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 9;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewByeLaws2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 10;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewBoAccNomination_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 4;
            frmcustomerAccInfo.Show();
             }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewBoAccNomination2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 5;
            frmcustomerAccInfo.Show();
                     }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewPoa_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 6;
            frmcustomerAccInfo.Show();
                     }
            else 
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewPoa2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();
            
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
            pdfReportBo.CustomerCode = txtCustomerCode.Text;

            frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
            frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
            frmcustomerAccInfo.MenuCounter = 7;
            frmcustomerAccInfo.Show();

            }
                else
                {
                    MessageBox.Show("Enter Customer Code");
                }
        }

        private void btnPdfCustAccInfo_Click(object sender, EventArgs e)
        {

            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
   
                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";    
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 12;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            
        }

        private void btnPdfTermCond_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 13;
                    frmcustomerAccInfo.Show();
                }

            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfTermCond2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 14;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfBoOpening_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 15;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfBoOpening2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 16;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfByeLaws_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 17;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfByeLaws2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 18;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfBoNomination_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 19;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfBoNomination2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 20;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfPoa_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 21;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnPdfPoa2_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 22;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewAFSR_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();


            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter = 23;
                frmcustomerAccInfo.Show();
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();
        }

        private void btnpdfAFSR_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 26;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }



        }

        private void btnViewLOA_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();


            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter =24;
                frmcustomerAccInfo.Show();
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();
        }

        private void btnpdfLOA_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 25;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void FGMainForm_Load(object sender, EventArgs e)
        {

        }

      
        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                DataTable serviceInfo = new DataTable();
                PdfReportBAL pdfReportBal = new PdfReportBAL();
                PdfReportBO pdfReportBo = new PdfReportBO();
                pdfReportBo.CustomerCode = txtCustomerCode.Text;


                serviceInfo = pdfReportBal.GetCustomerName(pdfReportBo);
                if (serviceInfo.Rows.Count > 0)
                {
                    CustomerName.Text = serviceInfo.Rows[0][0].ToString();

                }
            
            }
        }

        private void btnViewCdBLPersonalDetail_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();


            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter = 27;
                frmcustomerAccInfo.Show();
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();
        }

        private void btnPdfCDBLPersonalDetail_Click(object sender, EventArgs e)
        {

            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 28;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }

        private void btnViewCDBLNominee_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();


            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter = 29;
                frmcustomerAccInfo.Show();
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();

        }

        private void btnViewCDBLpowerOfAttorney_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();


            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                pdfReportBo.CustomerCode = txtCustomerCode.Text;
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();
                frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                frmcustomerAccInfo.MenuCounter = 30;
                frmcustomerAccInfo.Show();
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
            //this.Hide();
        }

        private void btnPdfCDBLNominee_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 31;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }

        }

        private void btnPdfCDBLpowerOfAttorney_Click(object sender, EventArgs e)
        {
            PdfReportBO pdfReportBo = new PdfReportBO();

            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                frmCustomerAccInfo frmcustomerAccInfo = new frmCustomerAccInfo();

                custAccInfoSaveFileDlg.Title = "Save Forms";
                custAccInfoSaveFileDlg.DefaultExt = "pdf";
                custAccInfoSaveFileDlg.AddExtension = true;
                custAccInfoSaveFileDlg.Filter = "PDF files (*.pdf)|*.pdf";
                custAccInfoSaveFileDlg.RestoreDirectory = true;
                if (custAccInfoSaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    frmcustomerAccInfo.PathName = custAccInfoSaveFileDlg.FileName;
                    pdfReportBo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.CustomerCode = txtCustomerCode.Text;
                    frmcustomerAccInfo.MenuCounter = 32;
                    frmcustomerAccInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Enter Customer Code");
            }
        }
    }
}
