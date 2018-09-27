using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.BO;
using System.Drawing;
using System.Collections.Specialized;

namespace BusinessAccessLayer.Constants
{
    public class Indication_FormControlResize
    {


        public static List<FormControlResizeBO> NewCustomerOpen = new List<FormControlResizeBO>()
                                                               {
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlPaymentInfo",
                                                                           ControlWidth = 277,
                                                                           ControlHeight = 136,
                                                                           LocationX = 6,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlPaymentInfo",
                                                                           ControlWidth = 227,
                                                                           ControlHeight = 136,
                                                                           LocationX = 6,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlVoucherInfo",
                                                                           ControlWidth = 257,
                                                                           ControlHeight = 234,
                                                                           LocationX = 320,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlVoucherInfo",
                                                                           ControlWidth = 257,
                                                                           ControlHeight = 234,
                                                                           LocationX = 240,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlPaymentOCCInfo",
                                                                           ControlWidth = 252,
                                                                           ControlHeight = 74,
                                                                           LocationX = 2,
                                                                           LocationY = 7,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlPaymentOCCInfo",
                                                                           ControlWidth = 227,
                                                                           ControlHeight = 136,
                                                                           LocationX = 6,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = false,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlAnnualChargeInfo",
                                                                           ControlWidth = 244,
                                                                           ControlHeight = 140,
                                                                           LocationX = 4,
                                                                           LocationY = 87,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlAnnualChargeInfo",
                                                                           ControlWidth = 244,
                                                                           ControlHeight = 140,
                                                                           LocationX = 2,
                                                                           LocationY = 7,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                       

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlAccountDepositInfo",
                                                                           ControlWidth = 244,
                                                                           ControlHeight = 115,
                                                                           LocationX = 2,
                                                                           LocationY = 22,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlAccountDepositInfo",
                                                                           ControlWidth = 244,
                                                                           ControlHeight = 36,
                                                                           LocationX = 5,
                                                                           LocationY = 108,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = false,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                       new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "ckbAnnualCharge",
                                                                           ControlWidth = 294,
                                                                           ControlHeight = 155,
                                                                           LocationX = 332,
                                                                           LocationY = 19,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "ckbAnnualCharge",
                                                                           ControlWidth = 244,
                                                                           ControlHeight = 36,
                                                                           LocationX = 5,
                                                                           LocationY = 108,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = false,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                       new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlCustInfo",
                                                                           ControlWidth = 226,
                                                                           ControlHeight = 153,
                                                                           LocationX = 501,
                                                                           LocationY = 21,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = false,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "pnlCustInfo",
                                                                           ControlWidth = 226,
                                                                           ControlHeight = 153,
                                                                           LocationX = 501,
                                                                           LocationY = 26,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "groupBox3",
                                                                           ControlWidth = 639,
                                                                           ControlHeight = 201,
                                                                           LocationX = 8,
                                                                           LocationY = 52,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "groupBox3",
                                                                           ControlWidth = 733,
                                                                           ControlHeight = 201,
                                                                           LocationX = 8,
                                                                           LocationY = 52,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "panel1",
                                                                           ControlWidth = 639,
                                                                           ControlHeight = 26,
                                                                           LocationX = 8,
                                                                           LocationY = 346,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "panel1",
                                                                           ControlWidth = 733,
                                                                           ControlHeight = 26,
                                                                           LocationX = 8,
                                                                           LocationY = 346,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "lblTotalAmount",
                                                                           ControlWidth = 152,
                                                                           ControlHeight = 13,
                                                                           LocationX = 434,
                                                                           LocationY = 6,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "lblTotalAmount",
                                                                           ControlWidth = 213,
                                                                           ControlHeight = 20,
                                                                           LocationX = 434,
                                                                           LocationY = 6,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "dgvPaymentOOcInfo",
                                                                           ControlWidth = 640,
                                                                           ControlHeight = 206,
                                                                           LocationX = 8,
                                                                           LocationY = 392,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "dgvPaymentOOcInfo",
                                                                           ControlWidth = 733,
                                                                           ControlHeight = 216,
                                                                           LocationX = 8,
                                                                           LocationY = 300,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "btnCancel",
                                                                           ControlWidth = 91,
                                                                           ControlHeight = 23,
                                                                           LocationX = 560,
                                                                           LocationY = 608,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "btnCancel",
                                                                           ControlWidth = 91,
                                                                           ControlHeight = 23,
                                                                           LocationX = 650,
                                                                           LocationY = 612,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },
                                                                       new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "btnSearch",
                                                                           ControlWidth = 30,
                                                                           ControlHeight = 24,
                                                                           LocationX = 239,
                                                                           LocationY = 16,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = false,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "btnSearch",
                                                                           ControlWidth = 30,
                                                                           ControlHeight = 24,
                                                                            LocationX = 239,
                                                                           LocationY = 16,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       },

                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "frmNewCustomerOpen",
                                                                           ControlWidth = 667,
                                                                           ControlHeight = 672,
                                                                           LocationX = 0,
                                                                           LocationY = 0,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.NewCustomerOpen
                                                                       },
                                                                   new FormControlResizeBO()
                                                                       {
                                                                           ControlName = "frmNewCustomerOpen",
                                                                           ControlWidth = 761,
                                                                           ControlHeight = 672,
                                                                           LocationX = 0,
                                                                           LocationY = 0,
                                                                           ControlBackColor = SystemColors.Control,
                                                                           ControlForeColor = SystemColors.ControlText,
                                                                           Enabled = true,
                                                                           Visible = true,
                                                                           StateName = Indication_Forms_Title.BORenewal
                                                                       }
                                                               };


    }
}
