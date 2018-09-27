using System;
using System.Windows.Forms;
using Image_Upload;
using NewArch;
using StockbrokerProNewArchForm;
using System.Data;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ImageMainForm : Form
    {
        public ImageMainForm()
        {
            InitializeComponent();
        }
        private void stAccountHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhotoBatch batch = new frmPhotoBatch { MdiParent = this };
            batch.Text = "1st Account Holder.";
            batch.Show();
        }

        private void ndAccountHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchImgUploader batch = new frmBatchImgUploader { MdiParent = this };
            batch.Show();
        }

        private void phToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImgShow imgShow = new frmImgShow { MdiParent = this };
            imgShow.Text = "Image Viewer";
            imgShow.Show();
        }


        private void stToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBath1stNoimeeImgUpload Ba1stNoi = new frmBath1stNoimeeImgUpload { MdiParent = this };
            Ba1stNoi.Show();
        }

        private void ndNomineeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBatch2ndNomineeImgUploader Batch2ndNoi = new frmBatch2ndNomineeImgUploader { MdiParent = this };
            Batch2ndNoi.Show();
        }

        private void stGurdianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch1stGurdiamImgUploader Batch1stGur = new frmBatch1stGurdiamImgUploader { MdiParent = this };
            Batch1stGur.Show();
        }

        private void ndGurdianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch2ndGurdianImgUploader Batch2ndGur = new frmBatch2ndGurdianImgUploader { MdiParent = this };
            Batch2ndGur.Show();
        }

        private void powerOFAttornayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchPOAImgUploader BatchPOAImg = new frmBatchPOAImgUploader { MdiParent = this };
            BatchPOAImg.Show();
        }

        private void stAccountHolderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "1st Account Holder";
            batchSig.Show();
        }

        private void ndAccountHolderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "2nd Account Holder";
            batchSig.Show();
        }

        private void stNomineeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "Nominee1";
            batchSig.Show();

        }

        private void ndNomineeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "Nominee2";
            batchSig.Show();
        }

        private void stGurdianToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "Guardian1";
            batchSig.Show();
        }

        private void ndGurdianToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "Guardian2";
            batchSig.Show();
        }

        private void powerOFAttorneyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "POA";
            batchSig.Show();
        }

        private void signatureToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmImgShow imgShow = new frmImgShow { MdiParent = this };
            imgShow.Text = "Signature Viewer";
            imgShow.Show();
        }

        private void authorizedPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBathchAuthorImgUpload batchAuth = new frmBathchAuthorImgUpload { MdiParent = this };
            batchAuth.Show();
        }

        private void authorizedPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };
            batchSig.Text = "Author";
            batchSig.Show();
        }
        private void othersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormUpload formUp = new frmFormUpload { MdiParent = this };
            formUp.Show();
        }

        private void othersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFormViewer formview = new frmFormViewer { MdiParent = this };
            formview.Show();
        }

        private void applicationFormGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGMainForm fgMainForm = new FGMainForm { MdiParent = this };
            fgMainForm.Show();
        }

        private void accountHolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmSingleAccountHolder frSingleHolder = new frmSingleAccountHolder { MdiParent = this };
            frSingleHolder.Show();
        }

        private void signatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSingleSignatureUpload SingleSign = new frmSingleSignatureUpload { MdiParent = this };
            SingleSign.Show();
        }
        private void ImageMainForm_Load(object sender, EventArgs e)
        {

            ResetPrevillize();
            LoadPrevilize();
        }



        private void LoadPrevilize()
        {
            bool result = false;


            DataTable RoleWiseUserPrevillizeDatatable = new DataTable();
            DataTable RoleWisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();

            RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();


            RoleWiseUserPrevillizeDatatable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWiseUserPrevillizeDatatable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWiseUserPrevillizeDatatable.Rows.Count; i++)
                {
                    if (RoleWiseUserPrevillizeDatatable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int j = 0; j < RoleWiseUserPrevillizeDatatable.Rows.Count; j++)
                    {
                        if (RoleWiseUserPrevillizeDatatable.Rows[j][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWiseUserPrevillizeDatatable.Rows[j]["Previllize"].ToString());
                        }
                    }
                }
                DeactiveMenu();
            }
            else if (RoleWiseUserPrevillizeDatatable.Rows.Count == 0)
            {
                RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int k = 0; k < RoleWisePrevillizeDataTable.Rows.Count; k++)
                {
                    SetPrevillize(RoleWisePrevillizeDataTable.Rows[k]["Previllize"].ToString());
                }
                DeactiveMenu();
            }
        }


        private void DeactiveMenu()
        {
        }
        private void SetPrevillize(string Previllize)
        {
            switch (Previllize)
            {

                case "Single Photo Upload":
                    accountHolderToolStripMenuItem.Visible = true;
                    break;

                case "Single Signature Upload":
                    signatureToolStripMenuItem.Visible = true;
                    break;

                case "Others":
                    othersToolStripMenuItem.Visible = true;
                    break;


                //case "Photo-First Account Holder":
                //    stAccountHolderToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo-Second Account Holder":
                //    ndAccountHolderToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo- First Nominee":
                //    stToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo- Second Nominee":
                //    ndNomineeToolStripMenuItem1.Visible = true;
                //    break;

                //case "Photo- First Girdian":
                //    stGurdianToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo- Second Girdian":
                //    ndGurdianToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo- Power of Attomay":
                //    powerOFAttornayToolStripMenuItem.Visible = true;
                //    break;

                //case "Photo- Authorized Person":
                //    authorizedPersonToolStripMenuItem.Visible = true;
                //    break;

                //case "Signature- First Account Holder":
                //    stAccountHolderToolStripMenuItem2.Visible = true;
                //    break;

                //case "Signature- Second Account Holder":
                //    ndAccountHolderToolStripMenuItem2.Visible = true;
                //    break;

                //case "Signature- First Nominee":
                //    stNomineeToolStripMenuItem2.Visible = true;
                //    break;


                //case "Signature- Second Nominee":
                //    ndNomineeToolStripMenuItem3.Visible = true;
                //    break;

                //case "Signature- First Gurdian":
                //    stGurdianToolStripMenuItem2.Visible = true;
                //    break;

                //case "Signature- Second Gurdian":
                //    ndGurdianToolStripMenuItem2.Visible = true;
                //    break;

                //case "Signature- Power of Attomey":
                //    powerOFAttorneyToolStripMenuItem1.Visible = true;
                //    break;

                //case "Signature- Authorized Person":
                //    authorizedPersonToolStripMenuItem1.Visible = true;
                //    break;


                case "Image Viewer-Photo":
                    phToolStripMenuItem.Visible = true;
                    break;

                case "Image Viewer-Signature":
                    signatureToolStripMenuItem2.Visible = true;
                    break;

                case "Image Viewer-Others":
                    othersToolStripMenuItem1.Visible = true;
                    break;


                default:
                    break;


            }
        }


        private void ResetPrevillize()
        {
            accountHolderToolStripMenuItem.Visible = false;
            signatureToolStripMenuItem.Visible = false;
            othersToolStripMenuItem.Visible = false;


            //stAccountHolderToolStripMenuItem.Visible = false;
            //ndAccountHolderToolStripMenuItem.Visible = false;
            //stToolStripMenuItem.Visible = false;
            //ndNomineeToolStripMenuItem1.Visible = false;
            //stGurdianToolStripMenuItem.Visible = false;
            //ndGurdianToolStripMenuItem.Visible = false;
            //powerOFAttornayToolStripMenuItem.Visible = false;
            //authorizedPersonToolStripMenuItem.Visible = false;
            //stAccountHolderToolStripMenuItem2.Visible = false;
            //ndAccountHolderToolStripMenuItem2.Visible = false;
            //stNomineeToolStripMenuItem2.Visible = false;
            //ndNomineeToolStripMenuItem3.Visible = false;
            //stGurdianToolStripMenuItem2.Visible = false;
            //ndGurdianToolStripMenuItem2.Visible = false;
            //powerOFAttorneyToolStripMenuItem1.Visible = false;
            //authorizedPersonToolStripMenuItem1.Visible = false;


            phToolStripMenuItem.Visible = false;
            signatureToolStripMenuItem2.Visible = false;
            othersToolStripMenuItem1.Visible = false;

        }

        private void photoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhotoBatch batch = new frmPhotoBatch { MdiParent = this };          
            batch.Show();
        }

        private void signatureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBatchSignatureUpload batchSig = new frmBatchSignatureUpload { MdiParent = this };      
            batchSig.Show();
        }

    }
}
