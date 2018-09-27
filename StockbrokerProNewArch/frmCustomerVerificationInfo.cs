using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.IO;

namespace StockbrokerProNewArch
{
    public partial class frmCustomerVerificationInfo : Form
    {
        AccDashboard an = new AccDashboard();
        private string[] ref_Cust_CodeList;
        private int Ref_Cust_code_current_Index = 0;
        public frmCustomerVerificationInfo(string[] Cust_CodeList)
        {
            if (Cust_CodeList.Length == 0)
                throw new Exception("No Customer Found!!");
            InitializeComponent();
            ref_Cust_CodeList = Cust_CodeList;
            Ref_Cust_code_current_Index = 0;
            Cmbselection.SelectedIndex = 0;
            txtsearchCustInfo.Focus();            
        }        

        CustomerVerificationInfoBal OBJbal = new CustomerVerificationInfoBal();
        private void CustInfo_Click(object sender, EventArgs e)
        {
            if (txtsearchCustInfo.Text.Length > 7 && Cmbselection.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Bo Id instead of csutomer code");
            }
            else
            {
                CustomerInfo();
            }
        }

        private void CustomerInfo()
        {
            DataTable dt = new DataTable();
            if (Cmbselection.SelectedItem.Equals("Bo Id"))
            {
                dt = OBJbal.Customer_verified("", txtsearchCustInfo.Text);
                txtCustomerName.Text = dt.Rows[0]["Customer"].ToString();
                txtboid.Text = dt.Rows[0]["Bo Id"].ToString();
                txtBankAccount.Text = dt.Rows[0]["Bank Account"].ToString();
                txtphone.Text = dt.Rows[0]["Phone"].ToString();
                txtNationalId.Text = dt.Rows[0]["National_ID"].ToString();
                txtdateofbirth.Text = dt.Rows[0]["Date of birth"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                txtjointype.Text = dt.Rows[0]["Joint Type"].ToString();
                txtNominee.Text = dt.Rows[0]["Nominee Name"].ToString();
                txtpowerofAttorney.Text = dt.Rows[0]["Power of Attorney Name"].ToString();
                txtjointNmae.Text = dt.Rows[0]["joint name"].ToString();
                MemoryStream st = photo("", txtsearchCustInfo.Text);
                MemoryStream stsignature = signature("", txtsearchCustInfo.Text);
                MemoryStream poast = POAimage(txtsearchCustInfo.Text);
                MemoryStream poasig = POAsignature(txtsearchCustInfo.Text);
                MemoryStream nopic = NomineePic(txtsearchCustInfo.Text);
                MemoryStream NoSig = NomineeSignature(txtsearchCustInfo.Text);
                MemoryStream JointPic = joingphoto(txtsearchCustInfo.Text);
                MemoryStream joinsig = jointsignature(txtsearchCustInfo.Text);
                MemoryStream joinCustPic = photo(txtsearchCustInfo.Text, "");
                MemoryStream joincustsig = signature("", txtsearchCustInfo.Text);
                if (joinCustPic != null)
                {
                    SingleImage.Image = Image.FromStream(joinCustPic);
                }
                else
                {
                    SingleImage.Image = null;
                }
                if (joincustsig != null)
                {
                    singleSignautre.Image = Image.FromStream(joincustsig);
                }
                else
                {
                    singleSignautre.Image = null;
                }
                if (JointPic != null)
                {
                    jointimage.Image = Image.FromStream(JointPic);
                }
                else
                {
                    jointimage.Image = null;
                }
                if (joinsig != null)
                {
                    joinsignature.Image = Image.FromStream(joinsig);
                }
                else
                {
                    joinsignature.Image = null;
                }
                if (nopic != null)
                {
                    PicNominee.Image = Image.FromStream(nopic);
                }
                else
                {
                    PicNominee.Image = null;
                }
                if (NoSig != null)
                {
                    SignatureNominee.Image = Image.FromStream(NoSig);
                }
                else
                {
                    SignatureNominee.Image = null;
                }
                if (poast != null)
                {
                    POAPIC.Image = Image.FromStream(poast);
                }
                else
                {
                    POAPIC.Image = null;
                }
                if (poasig != null)
                {
                    POASIGNATURE.Image = Image.FromStream(poasig);
                }
                else
                {
                    POASIGNATURE.Image = null;
                }
                if (st != null)
                {
                    CustomerPhoto.Image = Image.FromStream(st);

                }
                else
                {
                    CustomerPhoto.Image = null;

                }
                if (stsignature != null)
                {
                    CutomerSignature.Image = Image.FromStream(stsignature);
                }
                else
                {
                    CutomerSignature.Image = null;
                }
                if (txtjointype.Text.Contains("INDIVIDUAL"))
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel1.Show();

                }
                else if (txtjointype.Text.Contains("JOINT HOLDERS"))
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                    panel2.Show();
                }  
            }
            else
            {
                dt = OBJbal.Customer_verified(txtsearchCustInfo.Text, "");
                txtCustomerName.Text = dt.Rows[0]["Customer"].ToString();
                txtboid.Text = dt.Rows[0]["Bo Id"].ToString();
                txtBankAccount.Text = dt.Rows[0]["Bank Account"].ToString();
                txtphone.Text = dt.Rows[0]["Phone"].ToString();
                txtNationalId.Text = dt.Rows[0]["National_ID"].ToString();
                txtdateofbirth.Text = dt.Rows[0]["Date of birth"].ToString();
                txtaddress.Text = dt.Rows[0]["Address"].ToString();
                txtjointype.Text = dt.Rows[0]["Joint Type"].ToString();
                txtNominee.Text = dt.Rows[0]["Nominee Name"].ToString();
                txtpowerofAttorney.Text = dt.Rows[0]["Power of Attorney Name"].ToString();
                txtjointNmae.Text = dt.Rows[0]["joint name"].ToString();
                MemoryStream st = photo(txtsearchCustInfo.Text, "");
                MemoryStream sts = signature(txtsearchCustInfo.Text, "");
                MemoryStream poast = POAimage(txtsearchCustInfo.Text);
                MemoryStream poasig = POAsignature(txtsearchCustInfo.Text);
                MemoryStream nopic = NomineePic(txtsearchCustInfo.Text);
                MemoryStream NoSig = NomineeSignature(txtsearchCustInfo.Text);
                MemoryStream JointPic = joingphoto(txtsearchCustInfo.Text);
                MemoryStream joinsig = jointsignature(txtsearchCustInfo.Text);
                MemoryStream joinCustPic = photo(txtsearchCustInfo.Text, "");
                MemoryStream joincustsig = signature( txtsearchCustInfo.Text,"");
                if (joinCustPic != null)
                {
                    SingleImage.Image = Image.FromStream(joinCustPic);
                }
                else
                {
                    SingleImage.Image = null;
                }
                if (joincustsig != null)
                {
                    singleSignautre.Image = Image.FromStream(joincustsig);
                }
                else
                {
                    singleSignautre.Image = null;
                }
                if (JointPic != null)
                {
                    jointimage.Image = Image.FromStream(JointPic);
                }
                else
                {
                    jointimage.Image = null;
                }
                if (joinsig != null)
                {
                    joinsignature.Image = Image.FromStream(joinsig);
                }
                else
                {
                    joinsignature.Image = null;
                }
                if (nopic != null)
                {
                    PicNominee.Image = Image.FromStream(nopic);
                }
                else
                {
                    PicNominee.Image = null;
                }
                if (NoSig != null)
                {
                    SignatureNominee.Image = Image.FromStream(NoSig);
                }
                else
                {
                    SignatureNominee.Image = null;
                }

                if (poast != null)
                {
                    POAPIC.Image = Image.FromStream(poast);
                }
                else
                {
                    POAPIC.Image = null;
                }
                if (poasig != null)
                {
                    POASIGNATURE.Image = Image.FromStream(poasig);
                }
                else
                {
                    POASIGNATURE.Image = null;
                }
                if (st != null)
                {
                    CustomerPhoto.Image = Image.FromStream(st);


                }
                else
                {
                    CustomerPhoto.Image = null;

                }
                if (sts != null)
                {
                    CutomerSignature.Image = Image.FromStream(sts);
                }
                else
                {
                    CutomerSignature.Image = null;
                }
                if (txtjointype.Text.Contains("INDIVIDUAL"))
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel1.Show();
                     
                }
                else if (txtjointype.Text.Contains("JOINT HOLDERS"))
                {
                    panel1.Visible = false;
                    panel2.Visible = true;                    
                    panel2.Show();                    
                }                
            }
        }

        #region Image Query
        private MemoryStream joingphoto(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.JOintHolderPic(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream jointsignature(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.jointholderSignature(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream photo(string id, string boid)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.GetCustomerImagePhoto(id, boid);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream signature(string id, string boid)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.GetCustomerImageSignature(id, boid);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream POAsignature(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.PowerOfattorneySignature(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream POAimage(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.PowerOfAttorneyPic(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream NomineePic(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.NomeneePhoto(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        private MemoryStream NomineeSignature(string id)
        {
            MemoryStream ms = null;
            byte[] imageByte = new byte[0];
            imageByte = OBJbal.NomineeSignature(id);
            if (imageByte != null)
            {
                ms = new MemoryStream(imageByte);
            }
            return ms;
        }
        #endregion
        private void frmCustomerVerificationInfo_Load(object sender, EventArgs e)
        {
            txtsearchCustInfo.Focus();
            txtsearchCustInfo.Text = ref_Cust_CodeList.First();
                //AccDashboard.quantity;// an.quantity;

            //if (AccDashboard.quantity != null)
            //{
            //    txtsearchCustInfo.Text = AccDashboard.quantity;// an.quantity;
            //}
            //else if (frm_IPOPaymentForm.quantity != null)
            //{
            //    txtsearchCustInfo.Text = frm_IPOPaymentForm.quantity;
            //}
            if(txtsearchCustInfo.Text.Length>7)
            {
             Cmbselection.SelectedIndex=1;             
            CustomerInfo();
            }
            else
            {
                CustomerInfo();
            }

        }

        

        private void txtsearchCustInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtsearchCustInfo.Text.Length > 7 && Cmbselection.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Bo Id instead of csutomer code");
                }
                else
                {
                    CustomerInfo();
                }
            }
        }

        #region Mouse enter and leave
        private void singleSignautre_MouseEnter(object sender, EventArgs e)
        {
            //singleSignautre.SizeMode=PictureBoxSizeMode.Zoom;
            singleSignautre.Location = new Point(10, 100);
            singleSignautre.Size = new Size(185, 60);
        }

        private void singleSignautre_MouseLeave(object sender, EventArgs e)
        {
            singleSignautre.SizeMode = PictureBoxSizeMode.StretchImage;
            singleSignautre.Location = new Point(10, 124);
            singleSignautre.Size = new Size(117, 23);
        }

        private void SingleImage_MouseEnter(object sender, EventArgs e)
        {
            SingleImage.Location = new Point(11, 13);
            SingleImage.Size = new Size(180, 140);
            singleSignautre.Visible = false;
        }

        private void SingleImage_MouseLeave(object sender, EventArgs e)
        {
            
            SingleImage.Location = new Point(11, 18);
            SingleImage.Size = new Size(116, 98);
            singleSignautre.Visible = true;
        }

        private void jointimage_MouseEnter(object sender, EventArgs e)
        {
            
            jointimage.Location = new Point(11, 150);
            jointimage.Size = new Size(180, 150);
        }

        private void jointimage_MouseLeave(object sender, EventArgs e)
        {
            jointimage.Location = new Point(11, 156);
            jointimage.Size = new Size(116, 110);
        }

        private void joinsignature_MouseEnter(object sender, EventArgs e)
        {
            joinsignature.Location = new Point(11, 250);
            joinsignature.Size = new Size(183, 55);
            jointimage.Size = new Size(116, 90);
        }

        private void joinsignature_MouseLeave(object sender, EventArgs e)
        {
            joinsignature.Location = new Point(11,273);
            joinsignature.Size = new Size(117, 23);
            jointimage.Size = new Size(116, 110);
        }
        #endregion

        private void BtnCodeforward_Click(object sender, EventArgs e)
        {
           if(ref_Cust_CodeList.Length-1>Ref_Cust_code_current_Index)
            Ref_Cust_code_current_Index++;
           else 
               Ref_Cust_code_current_Index=0;

           txtsearchCustInfo.Text = ref_Cust_CodeList[Ref_Cust_code_current_Index];

           if (txtsearchCustInfo.Text.Length > 7 && Cmbselection.SelectedIndex == 0)
           {
               MessageBox.Show("Please select Bo Id instead of csutomer code");
           }
           else
           {
               CustomerInfo();
           }
        }

    }
}
