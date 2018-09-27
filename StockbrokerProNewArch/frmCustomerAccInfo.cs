using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace StockbrokerProNewArch
{
    public partial class frmCustomerAccInfo : Form
    {
        public string CustomerCode;
        public string PathName;

        public int MenuCounter;



        PdfReportBAL pdfReportBal = new PdfReportBAL();
        PdfReportBO pdfReportBo = new PdfReportBO();

        public frmCustomerAccInfo()
        {
            InitializeComponent();
        }



        public void LoadInformationFromDb()
        {
            pdfReportBo.CustomerCode = CustomerCode;
            DataTable dataTableCustomerBasic = new DataTable();
            /////// Retrieve Customer Basic Information /////////// 
            dataTableCustomerBasic = pdfReportBal.GetCustomerPersonalInfo(pdfReportBo);

            if (dataTableCustomerBasic.Rows.Count > 0)
            {
                pdfReportBo.CustomerName = dataTableCustomerBasic.Rows[0][0].ToString();
                pdfReportBo.CustomerFatherOrHusbandName = dataTableCustomerBasic.Rows[0][1].ToString();
                pdfReportBo.CustomerMotherName = dataTableCustomerBasic.Rows[0][2].ToString();
                if (dataTableCustomerBasic.Rows[0][3] != DBNull.Value)
                    pdfReportBo.CustomerDateOfBirth =
                        Convert.ToDateTime(dataTableCustomerBasic.Rows[0][3]).ToString("dd/MM/yyyy");
                pdfReportBo.CustomerSex = dataTableCustomerBasic.Rows[0][4].ToString();
                if (dataTableCustomerBasic.Rows[0][5] != DBNull.Value)
                    pdfReportBo.CustomerNationalId = dataTableCustomerBasic.Rows[0][5].ToString();
                pdfReportBo.BoId = dataTableCustomerBasic.Rows[0][6].ToString();
                pdfReportBo.SpecialRemarks = dataTableCustomerBasic.Rows[0][7].ToString();
                pdfReportBo.AccountType = dataTableCustomerBasic.Rows[0][8].ToString();
                pdfReportBo.AccountStatus = dataTableCustomerBasic.Rows[0][9].ToString();
                pdfReportBo.BoCategory = dataTableCustomerBasic.Rows[0][10].ToString();

                if(dataTableCustomerBasic.Rows[0][11]!=DBNull.Value)
                pdfReportBo.BoOpenDate = Convert.ToDateTime(dataTableCustomerBasic.Rows[0][11]).ToString("dd/MM/yyyy");
                
                pdfReportBo.CustomerOccupation = dataTableCustomerBasic.Rows[0][12].ToString();

                if (dataTableCustomerBasic.Rows[0][13]!=DBNull.Value)
                pdfReportBo.CustomerOpenDate =
                    Convert.ToDateTime(dataTableCustomerBasic.Rows[0][13]).ToString("dd/MM/yyyy");
                pdfReportBo.CdblParticipantId = "23500"; //dataTableCustomerBasic.Rows[0][14].ToString();
                
                pdfReportBo.BrokerBoId = dataTableCustomerBasic.Rows[0][15].ToString();
                pdfReportBo.BoId = pdfReportBo.BrokerBoId + pdfReportBo.BoId;
            }
            DataTable dataTableCustomerAdditionalInfo = new DataTable();
            dataTableCustomerAdditionalInfo = pdfReportBal.GetCustomerAdditionalInfo(pdfReportBo);

            if (dataTableCustomerAdditionalInfo.Rows.Count > 0)
            {
                pdfReportBo.CustomerNationality = dataTableCustomerAdditionalInfo.Rows[0][0].ToString();


                pdfReportBo.CustomerCity = dataTableCustomerAdditionalInfo.Rows[0][4].ToString();
                pdfReportBo.CustomerDevision = dataTableCustomerAdditionalInfo.Rows[0][5].ToString();
                pdfReportBo.CustomerCountry = dataTableCustomerAdditionalInfo.Rows[0][6].ToString();

                pdfReportBo.CustomerAddress = "";
                if (!string.IsNullOrEmpty(dataTableCustomerAdditionalInfo.Rows[0][1].ToString()))
                    pdfReportBo.CustomerAddress = dataTableCustomerAdditionalInfo.Rows[0][1].ToString();
                if (!string.IsNullOrEmpty(dataTableCustomerAdditionalInfo.Rows[0][2].ToString()))
                    pdfReportBo.CustomerAddress = pdfReportBo.CustomerAddress + " , " + dataTableCustomerAdditionalInfo.Rows[0][2].ToString();
                if (!string.IsNullOrEmpty(dataTableCustomerAdditionalInfo.Rows[0][3].ToString()))
                    pdfReportBo.CustomerAddress = pdfReportBo.CustomerAddress + " , " + dataTableCustomerAdditionalInfo.Rows[0][3].ToString();

                if (!string.IsNullOrEmpty(pdfReportBo.CustomerCity))
                    pdfReportBo.CustomerAddress = pdfReportBo.CustomerAddress + " , " + pdfReportBo.CustomerCity;
                if (!string.IsNullOrEmpty(pdfReportBo.CustomerDevision))
                    pdfReportBo.CustomerAddress = pdfReportBo.CustomerAddress + " , " + pdfReportBo.CustomerDevision;
                if (!string.IsNullOrEmpty(pdfReportBo.CustomerCountry))
                    pdfReportBo.CustomerAddress = pdfReportBo.CustomerAddress + " , " + pdfReportBo.CustomerCountry;

                pdfReportBo.CustomerPhone = dataTableCustomerAdditionalInfo.Rows[0][7].ToString();
                pdfReportBo.CustomerMobile = dataTableCustomerAdditionalInfo.Rows[0][8].ToString();
                pdfReportBo.CustomerEmail = dataTableCustomerAdditionalInfo.Rows[0][9].ToString();
                pdfReportBo.CustomerPassportNo = dataTableCustomerAdditionalInfo.Rows[0][10].ToString();
                pdfReportBo.CustomerPlaceofIssue = dataTableCustomerAdditionalInfo.Rows[0][11].ToString();
                if (dataTableCustomerAdditionalInfo.Rows[0][12] != DBNull.Value)
                    pdfReportBo.CustomerExpairDate =
                        Convert.ToDateTime(dataTableCustomerAdditionalInfo.Rows[0][12]).ToString("dd/MM/yyyy");

                pdfReportBo.BankName = dataTableCustomerAdditionalInfo.Rows[0][13].ToString();
                pdfReportBo.BankBranchName = dataTableCustomerAdditionalInfo.Rows[0][14].ToString();
                pdfReportBo.BankAccountNo = dataTableCustomerAdditionalInfo.Rows[0][15].ToString();
                if (dataTableCustomerAdditionalInfo.Rows[0][16]!=DBNull.Value)
                    pdfReportBo.IsElectronicDivinedCredit = Convert.ToInt16(dataTableCustomerAdditionalInfo.Rows[0][16]);
                if (dataTableCustomerAdditionalInfo.Rows[0][17] != DBNull.Value)
                    pdfReportBo.IsTaxExemption = Convert.ToInt16(dataTableCustomerAdditionalInfo.Rows[0][17]);
                pdfReportBo.TinTax = dataTableCustomerAdditionalInfo.Rows[0][18].ToString();
                pdfReportBo.CustomerPostCode = dataTableCustomerAdditionalInfo.Rows[0][19].ToString();
                pdfReportBo.CustomerFax = dataTableCustomerAdditionalInfo.Rows[0][20].ToString();
                pdfReportBo.CompanyRegistrationNo = dataTableCustomerAdditionalInfo.Rows[0][21].ToString();

                if (dataTableCustomerAdditionalInfo.Rows[0][22] != DBNull.Value)
                    pdfReportBo.CustomerPassportIssueDate =Convert.ToDateTime(dataTableCustomerAdditionalInfo.Rows[0][22]).ToString("dd/MM/yyyy");

                pdfReportBo.CustomerResidency = dataTableCustomerAdditionalInfo.Rows[0][23].ToString();
                pdfReportBo.CustomerStatementCycle = dataTableCustomerAdditionalInfo.Rows[0][24].ToString();
                pdfReportBo.CustomerInternalRefNo = dataTableCustomerAdditionalInfo.Rows[0][25].ToString();

                if (dataTableCustomerAdditionalInfo.Rows[0][26] != DBNull.Value)
                    pdfReportBo.CompanyRegistrationDate =Convert.ToDateTime(dataTableCustomerAdditionalInfo.Rows[0][26]).ToString("dd/MM/yyyy");

                if (dataTableCustomerAdditionalInfo.Rows[0][27] != DBNull.Value)
                    pdfReportBo.IsAccountLinkRequest = Convert.ToInt16(dataTableCustomerAdditionalInfo.Rows[0][27]);

                pdfReportBo.AccountLinkBoId = dataTableCustomerAdditionalInfo.Rows[0]["Acc_Link_BO_ID"].ToString();

                if (dataTableCustomerAdditionalInfo.Rows[0]["Standing_Ins"] != DBNull.Value)
                    pdfReportBo.IsStandingInstruction =
                        Convert.ToInt16(dataTableCustomerAdditionalInfo.Rows[0]["Standing_Ins"]);
            }

            DataTable dataTableAuthorizedPerson = new DataTable();
            dataTableAuthorizedPerson = pdfReportBal.GetAuthorizedPerson(pdfReportBo);

            if (dataTableAuthorizedPerson.Rows.Count > 0)
            {
                pdfReportBo.NomineeName = dataTableAuthorizedPerson.Rows[0][0].ToString();
                pdfReportBo.NomineeRelationship = dataTableAuthorizedPerson.Rows[0][1].ToString();

                if (dataTableAuthorizedPerson.Rows[0][2] != DBNull.Value)
                    pdfReportBo.NomineeAge =(DateTime.Now.Year - (Convert.ToDateTime(dataTableAuthorizedPerson.Rows[0][2])).Year).ToString();

                pdfReportBo.NomineeNationalId = dataTableAuthorizedPerson.Rows[0][3].ToString();
                pdfReportBo.NomineePercentage = dataTableAuthorizedPerson.Rows[0][4].ToString();

                if (dataTableAuthorizedPerson.Rows[0][5] != DBNull.Value)
                    pdfReportBo.IsAccountHolderOfficer = Convert.ToInt16(dataTableAuthorizedPerson.Rows[0][5]);

                pdfReportBo.NameAddressOfSeOrListedComp = dataTableAuthorizedPerson.Rows[0][6].ToString();
                pdfReportBo.AuthorizedPersonName = dataTableAuthorizedPerson.Rows[0][7].ToString();
                pdfReportBo.AuthorizedPersonAddress = dataTableAuthorizedPerson.Rows[0][8].ToString();
                pdfReportBo.AuthorizedPersonMobile = dataTableAuthorizedPerson.Rows[0][9].ToString();

                ////Person Introducing The customer
                pdfReportBo.NameOfpersonIntroducingCustomer = dataTableAuthorizedPerson.Rows[0][10].ToString();
                pdfReportBo.AddressOfpersonIntroducingCustomer = dataTableAuthorizedPerson.Rows[0][11].ToString();
                pdfReportBo.SpecialInstruction = dataTableAuthorizedPerson.Rows[0][23].ToString();

                ////Joint Holder Information retrieve 
                pdfReportBo.JointAccountHolderName = dataTableAuthorizedPerson.Rows[0][12].ToString();
                pdfReportBo.JointAccHldrFatherHusbandName = dataTableAuthorizedPerson.Rows[0][13].ToString();
                pdfReportBo.JointAccHldrMotherName = dataTableAuthorizedPerson.Rows[0][14].ToString();

                if (dataTableAuthorizedPerson.Rows[0][15] != DBNull.Value)
                    pdfReportBo.JointAccHldrDateofBirth =Convert.ToDateTime(dataTableAuthorizedPerson.Rows[0][15]).ToString("dd/MM/yyyy");

                pdfReportBo.JointAccHldrSex = dataTableAuthorizedPerson.Rows[0][16].ToString();
                pdfReportBo.JointAccHldrNationality = dataTableAuthorizedPerson.Rows[0][17].ToString();
                pdfReportBo.JointAccHldrAddress = dataTableAuthorizedPerson.Rows[0][18].ToString();
                pdfReportBo.JointAccHldrNationalId = dataTableAuthorizedPerson.Rows[0][19].ToString();
                pdfReportBo.JointAccHldrPhone = dataTableAuthorizedPerson.Rows[0][20].ToString();
                pdfReportBo.JointAccHldrMobile = dataTableAuthorizedPerson.Rows[0][21].ToString();
                pdfReportBo.JointAccHldrEmail = dataTableAuthorizedPerson.Rows[0][22].ToString();
                pdfReportBo.CustomerIntroducerBoId = dataTableAuthorizedPerson.Rows[0]["Intro_BO_ID"].ToString();
                pdfReportBo.JointHldrSpecialInstr = dataTableAuthorizedPerson.Rows[0]["Operation_Ins"].ToString();
            }

            DataTable dataTableOtherInfo = new DataTable();
            dataTableOtherInfo = pdfReportBal.GetOtherInfo(pdfReportBo);

            if (dataTableOtherInfo.Rows.Count > 0)
            {
                pdfReportBo.ParticipatoryName = dataTableOtherInfo.Rows[0]["Name"].ToString();
                pdfReportBo.ExchangeName = dataTableOtherInfo.Rows[0]["Exchange_Name"].ToString();
                pdfReportBo.TradingId = dataTableOtherInfo.Rows[0]["Trade_ID"].ToString();
            }





            DataTable dataTableNomineeGurdian = new DataTable();
            dataTableNomineeGurdian = pdfReportBal.GetNomineeGurdian(pdfReportBo);

            if (dataTableNomineeGurdian.Rows.Count > 0)
            {
                ///// Nominee 1
                //MessageBox.Show(pdfReportBo.CustomerCode.ToString());
                pdfReportBo.NomineeAddress = dataTableNomineeGurdian.Rows[0][0].ToString();
                pdfReportBo.NomineeCity = dataTableNomineeGurdian.Rows[0][1].ToString();
                pdfReportBo.NomineeDivision = dataTableNomineeGurdian.Rows[0][2].ToString();
                pdfReportBo.NomineePostCode = dataTableNomineeGurdian.Rows[0][3].ToString();
                pdfReportBo.NomineeCountry = dataTableNomineeGurdian.Rows[0][4].ToString();
                pdfReportBo.NomineeTelephone = dataTableNomineeGurdian.Rows[0][5].ToString();
                pdfReportBo.NomineeMobile = dataTableNomineeGurdian.Rows[0][6].ToString();
                pdfReportBo.NomineeFax = dataTableNomineeGurdian.Rows[0][7].ToString();
                pdfReportBo.NomineeEmail = dataTableNomineeGurdian.Rows[0][8].ToString();

                if (dataTableNomineeGurdian.Rows[0][9] != DBNull.Value)
                    pdfReportBo.NomineeDateOfBirth =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][9]).ToString("dd/MM/yyyy");

                pdfReportBo.NomineeNationality = dataTableNomineeGurdian.Rows[0][10].ToString();
                pdfReportBo.NomineeResident = dataTableNomineeGurdian.Rows[0][11].ToString();
                pdfReportBo.NomineePassportNo = dataTableNomineeGurdian.Rows[0][12].ToString();

                if (dataTableNomineeGurdian.Rows[0][13] != DBNull.Value)
                    pdfReportBo.NomineePassportIssueDate =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][13]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][14] != DBNull.Value)
                    pdfReportBo.NomineePassportExpireDate =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][14]).ToString("dd/MM/yyyy");

                pdfReportBo.NomineePassportIssuePlace = dataTableNomineeGurdian.Rows[0][15].ToString();

                ///// Nominee 2
                pdfReportBo.NomineeName2 = dataTableNomineeGurdian.Rows[0][16].ToString();
                pdfReportBo.NomineeRelationship2 = dataTableNomineeGurdian.Rows[0][17].ToString();
                pdfReportBo.NomineePercentage2 = dataTableNomineeGurdian.Rows[0][18].ToString();

                pdfReportBo.NomineeAddress2 = dataTableNomineeGurdian.Rows[0][19].ToString();
                pdfReportBo.NomineeCity2 = dataTableNomineeGurdian.Rows[0][20].ToString();
                pdfReportBo.NomineeDivision2 = dataTableNomineeGurdian.Rows[0][21].ToString();
                pdfReportBo.NomineePostCode2 = dataTableNomineeGurdian.Rows[0][22].ToString();
                pdfReportBo.NomineeCountry2 = dataTableNomineeGurdian.Rows[0][23].ToString();
                pdfReportBo.NomineeTelephone2 = dataTableNomineeGurdian.Rows[0][24].ToString();
                pdfReportBo.NomineeMobile2 = dataTableNomineeGurdian.Rows[0][25].ToString();
                pdfReportBo.NomineeFax2 = dataTableNomineeGurdian.Rows[0][26].ToString();
                pdfReportBo.NomineeEmail2 = dataTableNomineeGurdian.Rows[0][27].ToString();

                if (dataTableNomineeGurdian.Rows[0][28] != DBNull.Value)
                    pdfReportBo.NomineeDateOfBirth2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][28]).ToString("dd/MM/yyyy");

                pdfReportBo.NomineeNationality2 = dataTableNomineeGurdian.Rows[0][29].ToString();
                pdfReportBo.NomineeResident2 = dataTableNomineeGurdian.Rows[0][30].ToString();
                pdfReportBo.NomineePassportNo2 = dataTableNomineeGurdian.Rows[0][31].ToString();

                if (dataTableNomineeGurdian.Rows[0][32] != DBNull.Value)
                    pdfReportBo.NomineePassportIssueDate2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][32]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][33] != DBNull.Value)
                    pdfReportBo.NomineePassportExpireDate2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][33]).ToString("dd/MM/yyyy");

                pdfReportBo.NomineePassportIssuePlace2 = dataTableNomineeGurdian.Rows[0][34].ToString();

                ///// Gurdian 1
                pdfReportBo.GurdianName = dataTableNomineeGurdian.Rows[0][35].ToString();
                pdfReportBo.GurdianAddress = dataTableNomineeGurdian.Rows[0][36].ToString();
                pdfReportBo.GurdianCity = dataTableNomineeGurdian.Rows[0][37].ToString();
                pdfReportBo.GurdianDivision = dataTableNomineeGurdian.Rows[0][38].ToString();
                pdfReportBo.GurdianCountry = dataTableNomineeGurdian.Rows[0][39].ToString();
                pdfReportBo.GurdianPostCode = dataTableNomineeGurdian.Rows[0][40].ToString();
                pdfReportBo.GurdianTelephone = dataTableNomineeGurdian.Rows[0][41].ToString();
                pdfReportBo.GurdianMobile = dataTableNomineeGurdian.Rows[0][42].ToString();
                pdfReportBo.GurdianFax = dataTableNomineeGurdian.Rows[0][43].ToString();
                pdfReportBo.GurdianEmail = dataTableNomineeGurdian.Rows[0][44].ToString();

                if (dataTableNomineeGurdian.Rows[0][45] != DBNull.Value)
                    pdfReportBo.GurdianDateOfBirth =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][45]).ToString("dd/MM/yyyy");

                pdfReportBo.GurdianNationality = dataTableNomineeGurdian.Rows[0][46].ToString();
                pdfReportBo.GurdianResidency = dataTableNomineeGurdian.Rows[0][47].ToString();
                pdfReportBo.GurdianPassportNo = dataTableNomineeGurdian.Rows[0][48].ToString();

                if (dataTableNomineeGurdian.Rows[0][49] != DBNull.Value)
                    pdfReportBo.GurdianPassportIssueDate =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][49]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][50] != DBNull.Value)
                    pdfReportBo.GurdianPassportExpiryDate =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][50]).ToString("dd/MM/yyyy");

                pdfReportBo.GurdianPassportIssuePlace = dataTableNomineeGurdian.Rows[0][51].ToString();
                pdfReportBo.GurdianRelationship = dataTableNomineeGurdian.Rows[0][52].ToString();

                if (dataTableNomineeGurdian.Rows[0][53] != DBNull.Value)
                    pdfReportBo.GurdianDateOfBirthMinor =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][53]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][54] != DBNull.Value)
                    pdfReportBo.GurdianMaturityDate =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][54]).ToString("dd/MM/yyyy");

                ///// Gurdian 2
                pdfReportBo.GurdianName2 = dataTableNomineeGurdian.Rows[0][55].ToString();
                pdfReportBo.GurdianAddress2 = dataTableNomineeGurdian.Rows[0][56].ToString();
                pdfReportBo.GurdianCity2 = dataTableNomineeGurdian.Rows[0][57].ToString();
                pdfReportBo.GurdianDivision2 = dataTableNomineeGurdian.Rows[0][58].ToString();
                pdfReportBo.GurdianCountry2 = dataTableNomineeGurdian.Rows[0][59].ToString();
                pdfReportBo.GurdianPostCode2 = dataTableNomineeGurdian.Rows[0][60].ToString();
                pdfReportBo.GurdianTelephone2 = dataTableNomineeGurdian.Rows[0][61].ToString();
                pdfReportBo.GurdianMobile2 = dataTableNomineeGurdian.Rows[0][62].ToString();
                pdfReportBo.GurdianFax2 = dataTableNomineeGurdian.Rows[0][63].ToString();
                pdfReportBo.GurdianEmail2 = dataTableNomineeGurdian.Rows[0][64].ToString();

                if (dataTableNomineeGurdian.Rows[0][65] != DBNull.Value)
                    pdfReportBo.GurdianDateOfBirth2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][65]).ToString("dd/MM/yyyy");

                pdfReportBo.GurdianNationality2 = dataTableNomineeGurdian.Rows[0][66].ToString();
                pdfReportBo.GurdianResidency2 = dataTableNomineeGurdian.Rows[0][67].ToString();
                pdfReportBo.GurdianPassportNo2 = dataTableNomineeGurdian.Rows[0][68].ToString();

                if (dataTableNomineeGurdian.Rows[0][69] != DBNull.Value)
                    pdfReportBo.GurdianPassportIssueDate2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][69]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][70] != DBNull.Value)
                    pdfReportBo.GurdianPassportExpiryDate2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][70]).ToString("dd/MM/yyyy");

                pdfReportBo.GurdianPassportIssuePlace2 = dataTableNomineeGurdian.Rows[0][71].ToString();
                pdfReportBo.GurdianRelationship2 = dataTableNomineeGurdian.Rows[0][72].ToString();

                if (dataTableNomineeGurdian.Rows[0][73] != DBNull.Value)
                    pdfReportBo.GurdianDateOfBirthMinor2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][73]).ToString("dd/MM/yyyy");

                if (dataTableNomineeGurdian.Rows[0][74] != DBNull.Value)
                    pdfReportBo.GurdianMaturityDate2 =Convert.ToDateTime(dataTableNomineeGurdian.Rows[0][74]).ToString("dd/MM/yyyy");
            }

            //// Power of Attorney

            DataTable dataTablePoa = new DataTable();
            dataTablePoa = pdfReportBal.GetPowerOfAttorney(pdfReportBo);

            if (dataTablePoa.Rows.Count > 0)
            {
                pdfReportBo.PoaName = dataTablePoa.Rows[0][0].ToString();
                pdfReportBo.PoaAddress = dataTablePoa.Rows[0][1].ToString();
                pdfReportBo.PoaCity = dataTablePoa.Rows[0][2].ToString();
                pdfReportBo.PoaDivision = dataTablePoa.Rows[0][3].ToString();
                pdfReportBo.PoaCountry = dataTablePoa.Rows[0][4].ToString();
                pdfReportBo.PoaPostCode = dataTablePoa.Rows[0][5].ToString();
                pdfReportBo.PoaTelephone = dataTablePoa.Rows[0][6].ToString();
                pdfReportBo.PoaMobile = dataTablePoa.Rows[0][7].ToString();
                pdfReportBo.PoaFax = dataTablePoa.Rows[0][8].ToString();
                pdfReportBo.PoaEmail = dataTablePoa.Rows[0][9].ToString();
                pdfReportBo.PoaPassportNo = dataTablePoa.Rows[0][10].ToString();
                pdfReportBo.PoaPassportIssueDate = dataTablePoa.Rows[0][11].ToString();
                pdfReportBo.PoaPassportExpireDate = dataTablePoa.Rows[0][12].ToString();
                pdfReportBo.PoaPassportIssuePlace = dataTablePoa.Rows[0][13].ToString();
                pdfReportBo.PoaNationality = dataTablePoa.Rows[0][14].ToString();
                pdfReportBo.PoaResidency = dataTablePoa.Rows[0][15].ToString();

                if(dataTablePoa.Rows[0][16]!=DBNull.Value)
                pdfReportBo.PoaDateOfBirth = Convert.ToDateTime(dataTablePoa.Rows[0][16]).ToString("dd/MM/yyyy");
                
                if(dataTablePoa.Rows[0][17]!=DBNull.Value)
                pdfReportBo.PoaEffectiveDateFrom = Convert.ToDateTime(dataTablePoa.Rows[0][17]).ToString("dd/MM/yyyy");

                if (dataTablePoa.Rows[0][18] != DBNull.Value)
                pdfReportBo.PoaEffectiveDateTo = Convert.ToDateTime(dataTablePoa.Rows[0][18]).ToString("dd/MM/yyyy");
                pdfReportBo.PoaRemarks = dataTablePoa.Rows[0][19].ToString();

            }
           DataTable serviceInfo = new DataTable();
           serviceInfo = pdfReportBal.GetServiceInfo(pdfReportBo);
           pdfReportBo.SmsService = "Not Register";
           pdfReportBo.Webservice = "Not Register";

           if (serviceInfo.Rows.Count > 0)
            {
                var WebService = serviceInfo.Rows[0][0].ToString();
                var SmsTrade =serviceInfo.Rows[0][1].ToString();
                var SmsConfirm =serviceInfo.Rows[0][2].ToString();
                pdfReportBo.RoutingNumber= serviceInfo.Rows[0][3].ToString();
                if (SmsTrade == "True" || SmsConfirm == "True")
                {
                    pdfReportBo.SmsService = "Register";
                }
                if (WebService == "True") 
                {
                    pdfReportBo.Webservice = "Register";
                }   
            }


        }

        private void AccountInfo(crCustAccInfo crpdfReport)
        {
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtCustomerCode"]).Text =pdfReportBo.CustomerCode.ToString();
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNameofCustomer"]).Text =pdfReportBo.CustomerName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtFatherOrHusbandName"]).Text =pdfReportBo.CustomerFatherOrHusbandName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtMotherName"]).Text =pdfReportBo.CustomerMotherName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtDateOfBirth"]).Text =pdfReportBo.CustomerDateOfBirth;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtSex"]).Text =pdfReportBo.CustomerSex;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNationalID"]).Text =pdfReportBo.CustomerNationalId;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtBoId"]).Text = pdfReportBo.BoId;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtSpecialRemarks"]).Text =pdfReportBo.SpecialRemarks;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAccountType"]).Text =pdfReportBo.AccountType;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAccountStatus"]).Text =pdfReportBo.AccountStatus;

            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNationality"]).Text =pdfReportBo.CustomerNationality;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text =pdfReportBo.CustomerAddress;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtPhoneNo"]).Text =pdfReportBo.CustomerPhone;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtMobileNo"]).Text =pdfReportBo.CustomerMobile;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtEmail"]).Text =pdfReportBo.CustomerEmail;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtPassportNo"]).Text =pdfReportBo.CustomerPassportNo;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtPlaceOfIssue"]).Text =pdfReportBo.CustomerPlaceofIssue;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtExpairDate"]).Text =pdfReportBo.CustomerExpairDate;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtCustomerBankName"]).Text =pdfReportBo.BankName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtCustomerBankBranchName"]).Text= pdfReportBo.BankBranchName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtCustomerBankAccountNumber"]).Text = pdfReportBo.BankAccountNo;

            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNomineeName"]).Text =pdfReportBo.NomineeName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtRelationship"]).Text =pdfReportBo.NomineeRelationship;

            if (!string.IsNullOrEmpty(pdfReportBo.NomineeAge))((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNomineeAge"]).Text =pdfReportBo.NomineeAge + " Yr";

            //if (pdfReportBo.NomineePercentage)
            if (!string.IsNullOrEmpty(pdfReportBo.NomineePercentage))
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNomineePercentage"]).Text =pdfReportBo.NomineePercentage + " %";
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNomineeNationalID"]).Text =pdfReportBo.NomineeNationalId;


            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAuthorizedPersonName"]).Text =pdfReportBo.AuthorizedPersonName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAuthorizedPersonAddress"]).Text= pdfReportBo.AuthorizedPersonAddress;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAuthorizedPersonMobile"]).Text= pdfReportBo.AuthorizedPersonMobile;

            if (pdfReportBo.IsAccountHolderOfficer == 1)
            {
                ((TextObject)
                 crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAccHolderOfficerOrDirector"]).Text ="Yes";
                ((TextObject)
                 crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNameAddressofListedCompany"]).Text =pdfReportBo.NameAddressOfSeOrListedComp;

            }
            else
            {
                ((TextObject)
                 crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtAccHolderOfficerOrDirector"]).Text ="No";
                ((TextObject)
                 crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtNameAddressofListedCompany"]).Text ="N/A";

            }

            //// Person Introducer Information
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtPersonIntroducingCustomerName"])
                .Text = pdfReportBo.NameOfpersonIntroducingCustomer;
            ((TextObject)
             crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtPersonIntroducingCustomerAddress"]).Text =pdfReportBo.AddressOfpersonIntroducingCustomer;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtSpecialInstruction"]).Text =pdfReportBo.SpecialInstruction;

            //// Joint Holder Information
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJointAccountHolderName"]).Text= pdfReportBo.JointAccountHolderName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrFatherName"]).Text =pdfReportBo.JointAccHldrFatherHusbandName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrMotherName"]).Text =pdfReportBo.JointAccHldrMotherName;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrDateOfBirth"]).Text =pdfReportBo.JointAccHldrDateofBirth;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrSex"]).Text =pdfReportBo.JointAccHldrSex;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrNationality"]).Text =pdfReportBo.JointAccHldrNationality;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrAddress"]).Text =pdfReportBo.JointAccHldrAddress;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrNaionalID"]).Text =pdfReportBo.JointAccHldrNationalId;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrPhoneNo"]).Text =pdfReportBo.JointAccHldrPhone;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrMobilNo"]).Text =pdfReportBo.JointAccHldrMobile;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["txtJntAccHldrEmail"]).Text =pdfReportBo.JointAccHldrEmail;
            ((TextObject)crpdfReport.ReportDefinition.Sections[2].ReportObjects["RoutingNo"]).Text = pdfReportBo.RoutingNumber;


           
        
        }

        private void BoAccountOpening(crBoAccOpening crboAccOpening)
        {
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtCustomerOpenDate"]).Text = pdfReportBo.CustomerOpenDate;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBocategory"]).Text = pdfReportBo.BoCategory;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBoType"]).Text = pdfReportBo.AccountType;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBoId"]).Text = pdfReportBo.BoId;
           // ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtParticipantName"]).Text = pdfReportBo.ParticipatoryName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtCdblParticipantId"]).Text = pdfReportBo.CdblParticipantId;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBoAccOpenedDate"]).Text = pdfReportBo.BoOpenDate;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtNameOfAccHolder"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtAccHolderShortName"]).Text = pdfReportBo.CustomerName;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtIndividualSex"]).Text = pdfReportBo.CustomerSex;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtOccupation"]).Text = pdfReportBo.CustomerOccupation;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtFatherName"]).Text = pdfReportBo.CustomerFatherOrHusbandName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtMotherName"]).Text = pdfReportBo.CustomerMotherName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtAddress"]).Text = pdfReportBo.CustomerAddress;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtCity"]).Text = pdfReportBo.CustomerCity;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtPostCode"]).Text = pdfReportBo.CustomerPostCode;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtDivision"]).Text = pdfReportBo.CustomerDevision;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtCountry"]).Text = pdfReportBo.CustomerCountry;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtTelephone"]).Text = pdfReportBo.CustomerPhone;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtMobileNo"]).Text = pdfReportBo.CustomerMobile;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtFax"]).Text = pdfReportBo.CustomerFax;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtEmail"]).Text = pdfReportBo.CustomerEmail;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtPassportNo"]).Text = pdfReportBo.CustomerPassportNo;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtIssuePlace"]).Text = pdfReportBo.CustomerPlaceofIssue;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtIssueDate"]).Text = pdfReportBo.CustomerPassportIssueDate;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtExpireDate"]).Text = pdfReportBo.CustomerExpairDate;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBankName"]).Text = pdfReportBo.BankName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtBranchName"]).Text = pdfReportBo.BankBranchName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtAccountNo"]).Text = pdfReportBo.BankAccountNo;

            if (pdfReportBo.IsElectronicDivinedCredit == 1)
            {
                ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtElectronicDebitCard"]).Text = "Yes";
            }
            else
            {
                ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtElectronicDebitCard"]).Text = "No";
            }


            if (pdfReportBo.IsTaxExemption == 1)
            {
                ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtTaxExemption"]).Text = "Yes";
            }
            else
            {
                ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtTaxExemption"]).Text = "No";
            }

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtTaxTin"]).Text = pdfReportBo.TinTax;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtResidency"]).Text = pdfReportBo.CustomerResidency;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtNationality"]).Text = pdfReportBo.CustomerNationality;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtDateofBirth"]).Text = pdfReportBo.CustomerDateOfBirth;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtStatementCycleCode"]).Text = pdfReportBo.CustomerStatementCycle;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtInternalRefNo"]).Text = pdfReportBo.CustomerInternalRefNo;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtRegistration"]).Text = pdfReportBo.CompanyRegistrationNo;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtDateofRegistration"]).Text = pdfReportBo.CompanyRegistrationDate;

            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtJointAccHolderName"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crboAccOpening.ReportDefinition.ReportObjects["txtJointHolderShortName"]).Text = pdfReportBo.JointAccountHolderName;

        }

        private void BoAccountOpening2(crBoAccOpening2 crboaccOpening2)
        {
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtExchangeName"]).Text = pdfReportBo.ExchangeName;
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtTradingId"]).Text = pdfReportBo.TradingId;

            if (pdfReportBo.IsAccountLinkRequest == 1)
            {
                ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtIsLinkCreate"]).Text = "Yes";
            }
            else
            {
                ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtIsLinkCreate"]).Text = "No";

            }

            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtDepositoryBoAccCode"]).Text = pdfReportBo.AccountLinkBoId;

            if (pdfReportBo.IsStandingInstruction == 1)
            {
                ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtIsFaxTransInsForDelivery"]).Text = "Yes";
            }
            else
            {
                ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtIsFaxTransInsForDelivery"]).Text = "No";

            }
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtNameOfFirstApplicant"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtNameOfSecondApplicant"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtSignatoryForCompany"]).Text = pdfReportBo.AuthorizedPersonName;

            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtSpecialInstruction"]).Text = pdfReportBo.JointHldrSpecialInstr;

           // ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtParticipatoryName"]).Text = pdfReportBo.ParticipatoryName;
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtIntroducerName"]).Text = pdfReportBo.NameOfpersonIntroducingCustomer;
            ((TextObject)crboaccOpening2.ReportDefinition.ReportObjects["txtAccountId"]).Text = pdfReportBo.CustomerIntroducerBoId;

        
        }

        private void BoAccountNomination(crBoAccNominationForm crboaccNominationForm)
        {

            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtCustomerOpenDate"]).Text = pdfReportBo.CustomerOpenDate;
          //  ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtParticipantName"]).Text = pdfReportBo.ParticipatoryName;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtBoId"]).Text = pdfReportBo.BoId;


            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtCdblParticipantId"]).Text = pdfReportBo.CdblParticipantId;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNameOfAccHolder"]).Text = pdfReportBo.CustomerName;

            //// Nominee 1
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeName1"]).Text = pdfReportBo.NomineeName;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeShortName1"]).Text = pdfReportBo.NomineeName;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeRelationShip1"]).Text = pdfReportBo.NomineeRelationship;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineePercentage1"]).Text = pdfReportBo.NomineePercentage;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtAddress"]).Text = pdfReportBo.NomineeAddress;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeCity1"]).Text = pdfReportBo.NomineeCity;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineePostCode1"]).Text = pdfReportBo.NomineePostCode;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeDivision1"]).Text = pdfReportBo.NomineeDivision;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeCountry1"]).Text = pdfReportBo.NomineeCountry;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeTelephone1"]).Text = pdfReportBo.NomineeTelephone;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txNomineetMobileNo1"]).Text = pdfReportBo.NomineeMobile;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeFax1"]).Text = pdfReportBo.NomineeFax;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeEmail1"]).Text = pdfReportBo.NomineeEmail;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineePassportNo1"]).Text = pdfReportBo.NomineePassportNo;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeIssuePlace1"]).Text = pdfReportBo.NomineePassportIssuePlace;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeIssueDate1"]).Text = pdfReportBo.NomineePassportIssueDate;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeExpireDate1"]).Text = pdfReportBo.NomineePassportExpireDate;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeResidency1"]).Text = pdfReportBo.NomineeResident;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeNationality1"]).Text = pdfReportBo.NomineeNationality;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtNomineeDateOfBirth1"]).Text = pdfReportBo.NomineeDateOfBirth;

            ///// Gurdian 1
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianName1"]).Text = pdfReportBo.GurdianName;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianShortName1"]).Text = pdfReportBo.GurdianName;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianRelationship1"]).Text = pdfReportBo.GurdianRelationship;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianDateofBirthMinor"]).Text = pdfReportBo.GurdianDateOfBirthMinor;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianMaturityDate"]).Text = pdfReportBo.GurdianMaturityDate;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianAddress1"]).Text = pdfReportBo.GurdianAddress;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianCity1"]).Text = pdfReportBo.GurdianCity;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianPostCode1"]).Text = pdfReportBo.GurdianPostCode;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianDivision1"]).Text = pdfReportBo.GurdianDivision;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianCountry1"]).Text = pdfReportBo.GurdianCountry;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianTelephone1"]).Text = pdfReportBo.GurdianTelephone;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianMobile1"]).Text = pdfReportBo.GurdianMobile;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianFax1"]).Text = pdfReportBo.GurdianFax;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianEmail1"]).Text = pdfReportBo.GurdianEmail;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianPassportNo1"]).Text = pdfReportBo.GurdianPassportNo;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianIssuePlace1"]).Text = pdfReportBo.GurdianPassportIssuePlace;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianIssueDate1"]).Text = pdfReportBo.GurdianPassportIssueDate;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianExpireDate1"]).Text = pdfReportBo.GurdianPassportExpiryDate;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianResidency1"]).Text = pdfReportBo.GurdianResidency;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianNationality1"]).Text = pdfReportBo.GurdianNationality;
            ((TextObject)crboaccNominationForm.ReportDefinition.ReportObjects["txtGurdianDateOfBirth"]).Text = pdfReportBo.GurdianDateOfBirth;

        }

        private void BoAccountNomination2(crBoAccNominationForm2 crboaccNominationForm2)
        {

            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeName2"]).Text = pdfReportBo.NomineeName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeShortName2"]).Text = pdfReportBo.NomineeName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeRelationShip2"]).Text = pdfReportBo.NomineeRelationship2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineePercentage2"]).Text = pdfReportBo.NomineePercentage2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtAddress2"]).Text = pdfReportBo.NomineeAddress2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeCity2"]).Text = pdfReportBo.NomineeCity2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineePostCode2"]).Text = pdfReportBo.NomineePostCode2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeDivision2"]).Text = pdfReportBo.NomineeDivision2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeCountry2"]).Text = pdfReportBo.NomineeCountry2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeTelephone2"]).Text = pdfReportBo.NomineeTelephone2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txNomineetMobileNo2"]).Text = pdfReportBo.NomineeMobile2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeFax2"]).Text = pdfReportBo.NomineeFax2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeEmail2"]).Text = pdfReportBo.NomineeEmail2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineePassportNo2"]).Text = pdfReportBo.NomineePassportNo2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeIssuePlace2"]).Text = pdfReportBo.NomineePassportIssuePlace2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeIssueDate2"]).Text = pdfReportBo.NomineePassportIssueDate2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeExpireDate2"]).Text = pdfReportBo.NomineePassportExpireDate2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeResidency2"]).Text = pdfReportBo.NomineeResident2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeNationality2"]).Text = pdfReportBo.NomineeNationality2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeDateOfBirth2"]).Text = pdfReportBo.NomineeDateOfBirth2;

            ///// Gurdian 2
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianName2"]).Text = pdfReportBo.GurdianName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianShortName2"]).Text = pdfReportBo.GurdianName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianRelationship2"]).Text = pdfReportBo.GurdianRelationship2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianDateofBirthMinor2"]).Text = pdfReportBo.GurdianDateOfBirthMinor2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianMaturityDate2"]).Text = pdfReportBo.GurdianMaturityDate2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianAddress2"]).Text = pdfReportBo.GurdianAddress2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianCity2"]).Text = pdfReportBo.GurdianCity2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianPostCode2"]).Text = pdfReportBo.GurdianPostCode2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianDivision2"]).Text = pdfReportBo.GurdianDivision2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianCountry2"]).Text = pdfReportBo.GurdianCountry2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianTelephone2"]).Text = pdfReportBo.GurdianTelephone2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianMobile2"]).Text = pdfReportBo.GurdianMobile2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianFax2"]).Text = pdfReportBo.GurdianFax2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianEmail2"]).Text = pdfReportBo.GurdianEmail2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianPassportNo2"]).Text = pdfReportBo.GurdianPassportNo2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianIssuePlace2"]).Text = pdfReportBo.GurdianPassportIssuePlace2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianIssueDate2"]).Text = pdfReportBo.GurdianPassportIssueDate2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianExpireDate2"]).Text = pdfReportBo.GurdianPassportExpiryDate2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianResidency2"]).Text = pdfReportBo.GurdianResidency2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianNationality2"]).Text = pdfReportBo.GurdianNationality2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianDateOfBirth2"]).Text = pdfReportBo.GurdianDateOfBirth2;



            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeName1"]).Text = pdfReportBo.NomineeName;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdianName1"]).Text = pdfReportBo.GurdianName;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtNomineeHeir2"]).Text = pdfReportBo.NomineeName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtGurdian2"]).Text = pdfReportBo.GurdianName2;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtAccHolder"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtSecAccHolder"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crboaccNominationForm2.ReportDefinition.ReportObjects["txtAuthorized"]).Text = pdfReportBo.AuthorizedPersonName;

        }

        private void PowerOfAttorney(crPowerOfAttorney crpowerofAttorney)
        {

            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtCustomerOpenDate"]).Text = pdfReportBo.CustomerOpenDate;
            //((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtParticipantName"]).Text = pdfReportBo.ParticipatoryName;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtBoId"]).Text = pdfReportBo.BoId;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtCdblParticipantId"]).Text = pdfReportBo.CdblParticipantId;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtNameOfAccHolder"]).Text = pdfReportBo.CustomerName;

            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaName"]).Text = pdfReportBo.PoaName;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaShortName"]).Text = pdfReportBo.PoaName;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaAddress"]).Text = pdfReportBo.PoaAddress;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaCity"]).Text = pdfReportBo.PoaCity;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaPostCode"]).Text = pdfReportBo.PoaPostCode;

            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaDivision"]).Text = pdfReportBo.PoaDivision;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaCountry"]).Text = pdfReportBo.PoaCountry;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaTelephone"]).Text = pdfReportBo.PoaTelephone;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaFax"]).Text = pdfReportBo.PoaFax;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaEmail"]).Text = pdfReportBo.PoaEmail;

            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaPassportNo"]).Text = pdfReportBo.PoaPassportNo;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaIssuePlace"]).Text = pdfReportBo.PoaPassportIssuePlace;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaIssueDate"]).Text = pdfReportBo.PoaPassportIssueDate;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaExpireDate"]).Text = pdfReportBo.PoaPassportExpireDate;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaResidency"]).Text = pdfReportBo.PoaResidency;

            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaNationality"]).Text = pdfReportBo.PoaNationality;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaDateOfBirth"]).Text = pdfReportBo.PoaDateOfBirth;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaEffectiveDateFrom"]).Text = pdfReportBo.PoaEffectiveDateFrom;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaEffectiveDateTo"]).Text = pdfReportBo.PoaEffectiveDateTo;
            ((TextObject)crpowerofAttorney.ReportDefinition.ReportObjects["txtPoaRemarks"]).Text = pdfReportBo.PoaRemarks;


        
        }

        private void PowerOfAttorney2(crPowerOfAttorney2 crpowerofAttorney2)
        {
            ((TextObject)crpowerofAttorney2.ReportDefinition.ReportObjects["txtPoaHolderName"]).Text = pdfReportBo.PoaName;
            ((TextObject)crpowerofAttorney2.ReportDefinition.ReportObjects["txtNameOfFirstApplicant"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crpowerofAttorney2.ReportDefinition.ReportObjects["txtNameOfSecondApplicant"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crpowerofAttorney2.ReportDefinition.ReportObjects["txtSignatoryForCompany"]).Text = pdfReportBo.AuthorizedPersonName;
        
        }

        private void TermsCondition2(crTermsConditions2 crtermsCondition2)
        {

            ((TextObject)crtermsCondition2.ReportDefinition.ReportObjects["txtFirstApplicantName"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crtermsCondition2.ReportDefinition.ReportObjects["txtSecondApplicantName"]).Text = pdfReportBo.JointAccountHolderName;

        
        }

        private void TermConditionBuyLaws(crTermsConditionByeLaws crtermsConditionByeLaws)
        {
            ((TextObject)crtermsConditionByeLaws.ReportDefinition.ReportObjects["txtBoId"]).Text = pdfReportBo.BoId;
            ((TextObject)crtermsConditionByeLaws.ReportDefinition.ReportObjects["txtClentId"]).Text = pdfReportBo.CustomerCode.ToString();
            ((TextObject)crtermsConditionByeLaws.ReportDefinition.ReportObjects["txtOpenDate"]).Text = pdfReportBo.CustomerOpenDate;

        }

        private void TermConditionBuyLaw2(crTermsConditionByeLaws2 crtermsConditionByeLaws2)
        {

            ((TextObject)crtermsConditionByeLaws2.ReportDefinition.ReportObjects["txtFirstApplicant"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crtermsConditionByeLaws2.ReportDefinition.ReportObjects["txtSecondApplicant"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crtermsConditionByeLaws2.ReportDefinition.ReportObjects["txtThirdSignatory"]).Text = pdfReportBo.AuthorizedPersonName;

        }

        private void crserviceReg(crServiceRegistration crserviceRegistration)
        {
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["ClientName"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["BoID"]).Text = pdfReportBo.BoId.ToString();
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["ClientCode"]).Text = pdfReportBo.CustomerCode;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Occupation"]).Text = pdfReportBo.CustomerOccupation;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Department"]).Text = "";
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Position"]).Text = "";
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["ContactAddress"]).Text = pdfReportBo.CustomerAddress;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["City"]).Text = pdfReportBo.CustomerCity;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Division"]).Text = pdfReportBo.CustomerDevision;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Country"]).Text = pdfReportBo.CustomerCountry;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Phone"]).Text = pdfReportBo.CustomerPhone;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Mobile"]).Text = pdfReportBo.CustomerMobile;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Url"]).Text = "";
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["Email"]).Text = pdfReportBo.CustomerEmail;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["SecondEmail"]).Text = "";
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["UserName"]).Text = pdfReportBo.CustomerEmail;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["PrimaryMobile"]).Text = pdfReportBo.CustomerMobile;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["agreeCustName"]).Text =pdfReportBo.CustomerName;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["SmsService"]).Text = pdfReportBo.SmsService;
            ((TextObject)crserviceRegistration.ReportDefinition.ReportObjects["WebService"]).Text = pdfReportBo.Webservice;
           
        }


        private void crLetterOfAuth(crLetterOfAuthorization crLetter)
        {
            ((TextObject)crLetter.ReportDefinition.ReportObjects["AccountID"]).Text = pdfReportBo.CustomerCode.ToString();
            ((TextObject)crLetter.ReportDefinition.ReportObjects["BoAccountNo"]).Text = pdfReportBo.BoId;
            ((TextObject)crLetter.ReportDefinition.ReportObjects["CustomerName"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crLetter.ReportDefinition.ReportObjects["JointAccountHolder"]).Text = pdfReportBo.JointAccountHolderName;

        }



        private void crCDBLPerosnalDetails(cr_CDBLPersonalDetail crCDBLPersonal)
        {
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["DPInternalReferenceNumber"]).Text = pdfReportBo.CustomerCode.ToString();
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BOID"]).Text = pdfReportBo.BoId;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BOType"]).Text = pdfReportBo.AccountType;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BOCategory"]).Text = pdfReportBo.AccountStatus == "Active" ? "Regular" : pdfReportBo.AccountStatus;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["FirstHolder"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["SecondJointHolder"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ThirdJointHolder"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ContactPerson"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["SexCode"]).Text = pdfReportBo.CustomerSex;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["DateofBirth"]).Text = pdfReportBo.CustomerDateOfBirth;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["RegistrationNumber"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["FatherName"]).Text = pdfReportBo.CustomerFatherOrHusbandName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["MothersName"]).Text = pdfReportBo.CustomerMotherName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Occupation"]).Text = pdfReportBo.CustomerOccupation;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ResidencyFlag"]).Text = pdfReportBo.CustomerResidency;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["CitizenOf"]).Text = pdfReportBo.CustomerNationality;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Address"]).Text = pdfReportBo.CustomerAddress;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["City"]).Text = pdfReportBo.CustomerCity;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["StateDivision"]).Text = pdfReportBo.CustomerDevision;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Country"]).Text = pdfReportBo.CustomerCountry;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["PostalCode"]).Text = pdfReportBo.CustomerPostCode;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Phone"]).Text = pdfReportBo.CustomerPhone;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Email"]).Text = pdfReportBo.CustomerEmail;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["Fax"]).Text = pdfReportBo.CustomerFax.Trim();
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["StatementCycleCode"]).Text = pdfReportBo.CustomerStatementCycle;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["FirstHolderNationalID"]).Text = pdfReportBo.CustomerNationalId;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["SecondHolderNationalID"]).Text = pdfReportBo.JointAccHldrNationalId;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ThirdHolderNationalID"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["FirstHolderShrotName"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["SecondHolderShortName"]).Text = pdfReportBo.JointAccountHolderName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ThirdHolderShortName"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["PassportNo"]).Text = pdfReportBo.CustomerPassportNo;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["PassportIssueDate"]).Text = pdfReportBo.CustomerPassportIssueDate;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["PassportExpiryDate"]).Text = pdfReportBo.CustomerExpairDate;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["PassportIssuePlace"]).Text = pdfReportBo.CustomerPlaceofIssue;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["RoutingNumber"]).Text = pdfReportBo.RoutingNumber;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BankName"]).Text = pdfReportBo.BankName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BranchName"]).Text = pdfReportBo.BankBranchName;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BankACNo"]).Text = pdfReportBo.BankAccountNo;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["BankIdentifierCode"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["InternationalBank"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["SWIFTCODE"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ElectronicDividend"]).Text = pdfReportBo.IsElectronicDivinedCredit == 1 ? "Yes" : "No";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["TaxExemption"]).Text = pdfReportBo.IsTaxExemption == 1 ? "Yes" : "NO";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["TaxIdentificationNo"]).Text = pdfReportBo.TinTax;
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["ExchangeName"]).Text = "";
            ((TextObject)crCDBLPersonal.ReportDefinition.ReportObjects["TradingID"]).Text = "";
          

        }


        private void crCDBLNomineeDetails(crCDBL_Additional_Detail crCDBLNominee)
        {
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["BOID"]).Text =pdfReportBo.BoId;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["FirstHolder"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PurposeCode"]).Text = "Nominee";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["SerialNo"]).Text = "1";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["AdditionalHolderName"]).Text = pdfReportBo.NomineeName;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Institution"]).Text = "No";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["InstitutionName"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Address"]).Text = pdfReportBo.NomineeAddress;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["City"]).Text = pdfReportBo.NomineeCity;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Division"]).Text = pdfReportBo.NomineeDivision;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Country"]).Text = pdfReportBo.NomineeCountry;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PostalCode"]).Text = pdfReportBo.NomineePostCode;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Phone"]).Text = pdfReportBo.NomineeMobile;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Email"]).Text = pdfReportBo.NomineeEmail;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Fax"]).Text = pdfReportBo.NomineeFax;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["EffectiveFromDate"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["EffectiveToDate"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["SetupDate"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["NationalID"]).Text = pdfReportBo.NomineeNationalId;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportNo"]).Text = pdfReportBo.NomineePassportNo;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportIssueDate"]).Text = pdfReportBo.NomineePassportIssueDate;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportExpiryDate"]).Text = pdfReportBo.NomineePassportExpireDate;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportIssuePlace"]).Text = pdfReportBo.NomineePassportIssuePlace;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Relationship"]).Text = pdfReportBo.NomineeRelationship;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["NomineePercentage"]).Text = pdfReportBo.NomineePercentage;
        }



        private void crCDBL_POADetails(crCDBL_Additional_Detail crCDBLNominee)
        {
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["BOID"]).Text = pdfReportBo.BoId;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["FirstHolder"]).Text = pdfReportBo.CustomerName;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PurposeCode"]).Text = "Power of Attorney";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["SerialNo"]).Text = "1";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["AdditionalHolderName"]).Text = pdfReportBo.PoaName;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Institution"]).Text = "No";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["InstitutionName"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Address"]).Text = pdfReportBo.PoaAddress;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["City"]).Text = pdfReportBo.PoaCity;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Division"]).Text = pdfReportBo.PoaDivision;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Country"]).Text = pdfReportBo.PoaCountry;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PostalCode"]).Text = pdfReportBo.PoaPostCode;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Phone"]).Text = pdfReportBo.PoaMobile;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Email"]).Text = pdfReportBo.PoaEmail;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Fax"]).Text = pdfReportBo.PoaFax;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["EffectiveFromDate"]).Text = pdfReportBo.PoaEffectiveDateFrom;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["EffectiveToDate"]).Text = pdfReportBo.PoaEffectiveDateTo;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["SetupDate"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["NationalID"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportNo"]).Text = pdfReportBo.PoaPassportNo;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportIssueDate"]).Text = pdfReportBo.PoaPassportIssueDate;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportExpiryDate"]).Text = pdfReportBo.PoaPassportExpireDate;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["PassportIssuePlace"]).Text = pdfReportBo.PoaPassportIssuePlace;
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["Relationship"]).Text = "";
            ((TextObject)crCDBLNominee.ReportDefinition.ReportObjects["NomineePercentage"]).Text = "";
        }








        private void frmCustomerAccInfo_Load(object sender, EventArgs e)
        {
            if (MenuCounter == 1)
            {
                LoadInformationFromDb();

                crCustAccInfo crpdfReport = new crCustAccInfo();

                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);
                AccountInfo(crpdfReport);
                crpdfReport.SetDataSource(dataTableImage);
                crvPdfReport.ReportSource = crpdfReport;
            }

            else if (MenuCounter == 2)
            {

                LoadInformationFromDb();
                crBoAccOpening crboAccOpening = new crBoAccOpening();
                BoAccountOpening(crboAccOpening);
                crvPdfReport.ReportSource = crboAccOpening;

            }
            else if (MenuCounter == 3)
            {
                LoadInformationFromDb();
                crBoAccOpening2 crboaccOpening2 = new crBoAccOpening2();

                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                BoAccountOpening2(crboaccOpening2);
                crboaccOpening2.SetDataSource(dataTableImages);
                crvPdfReport.ReportSource = crboaccOpening2;
            }

            else if (MenuCounter == 4)
            {
                LoadInformationFromDb();
                crBoAccNominationForm crboaccNominationForm = new crBoAccNominationForm();

                BoAccountNomination(crboaccNominationForm);

                crvPdfReport.ReportSource = crboaccNominationForm;

            }
            else if (MenuCounter == 5)
            {
                LoadInformationFromDb();
                crBoAccNominationForm2 crboaccNominationForm2 = new crBoAccNominationForm2();

                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                BoAccountNomination2(crboaccNominationForm2);

                crboaccNominationForm2.SetDataSource(dataTableImages);
                crvPdfReport.ReportSource = crboaccNominationForm2;
            }

            else if (MenuCounter == 6)
            {
                LoadInformationFromDb();
                crPowerOfAttorney crpowerofAttorney = new crPowerOfAttorney();
                PowerOfAttorney(crpowerofAttorney);

                crvPdfReport.ReportSource = crpowerofAttorney;
            }

            else if (MenuCounter == 7)
            {
                LoadInformationFromDb();
                crPowerOfAttorney2 crpowerofAttorney2 = new crPowerOfAttorney2();
                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                PowerOfAttorney2(crpowerofAttorney2);

                crpowerofAttorney2.SetDataSource(dataTableImages);
                crvPdfReport.ReportSource = crpowerofAttorney2;
            }
            else if (MenuCounter == 8)
            {
                LoadInformationFromDb();
                crTermsConditions2 crtermsCondition2 = new crTermsConditions2();

                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                TermsCondition2(crtermsCondition2);

                crtermsCondition2.SetDataSource(dataTableImages);
                crvPdfReport.ReportSource = crtermsCondition2;
            }

            else if (MenuCounter == 9)
            {
                LoadInformationFromDb();
                crTermsConditionByeLaws crtermsConditionByeLaws = new crTermsConditionByeLaws();

                TermConditionBuyLaws(crtermsConditionByeLaws);

                crvPdfReport.ReportSource = crtermsConditionByeLaws;
            }
            else if (MenuCounter == 10)
            {
                LoadInformationFromDb();
                crTermsConditionByeLaws2 crtermsConditionByeLaws2 = new crTermsConditionByeLaws2();

                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                TermConditionBuyLaw2(crtermsConditionByeLaws2);

                crtermsConditionByeLaws2.SetDataSource(dataTableImages);
                crvPdfReport.ReportSource = crtermsConditionByeLaws2;

            }
            else if (MenuCounter == 11)
            {

                crTermsConditions crtermsCondition = new crTermsConditions();
                crvPdfReport.ReportSource = crtermsCondition;

            }


            else if (MenuCounter == 12)
            {
                /////////////

                LoadInformationFromDb();

                crCustAccInfo crpdfReport = new crCustAccInfo();

                crpdfReport.Load("C:\\CrystalReport1.rpt");

                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);

                AccountInfo(crpdfReport);

                crpdfReport.SetDataSource(dataTableImage);
                //

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crpdfReport.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }

                    crpdfReport.Export();

                    MessageBox.Show("Form Sccessfully Exported");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else if (MenuCounter == 13)
            {


                crTermsConditions crtermsCondition = new crTermsConditions();
                crvPdfReport.ReportSource = crtermsCondition;



                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crtermsCondition.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crtermsCondition.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 14)
            {

                LoadInformationFromDb();
                crTermsConditions2 crtermsCondition2 = new crTermsConditions2();

                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                TermsCondition2(crtermsCondition2);

                crtermsCondition2.SetDataSource(dataTableImages);


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crtermsCondition2.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crtermsCondition2.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 15)
            {
                LoadInformationFromDb();
                crBoAccOpening crboAccOpening = new crBoAccOpening();
                crboAccOpening.Load("C:\\CrystalReport1.rpt");

                BoAccountOpening(crboAccOpening);
                //crvPdfReport.ReportSource = crboAccOpening;
                //


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crboAccOpening.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crboAccOpening.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else if (MenuCounter == 16)
            {

                LoadInformationFromDb();
                crBoAccOpening2 crboAccOpening2 = new crBoAccOpening2();
                crboAccOpening2.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImages = new DataTable();


                dataTableImages = pdfReportBal.GetImage(pdfReportBo);
                BoAccountOpening2(crboAccOpening2);

                crboAccOpening2.SetDataSource(dataTableImages);
                //crvPdfReport.ReportSource = crboaccOpening2;


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crboAccOpening2.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crboAccOpening2.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 17)
            {

                LoadInformationFromDb();
                crTermsConditionByeLaws crtermConditionByeLaw = new crTermsConditionByeLaws();
                crtermConditionByeLaw.Load("C:\\CrystalReport1.rpt");
                TermConditionBuyLaws(crtermConditionByeLaw);


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crtermConditionByeLaw.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crtermConditionByeLaw.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 18)
            {

                LoadInformationFromDb();
                crTermsConditionByeLaws2 crtermConditionByeLaw2 = new crTermsConditionByeLaws2();
                crtermConditionByeLaw2.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                TermConditionBuyLaw2(crtermConditionByeLaw2);

                crtermConditionByeLaw2.SetDataSource(dataTableImages);

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crtermConditionByeLaw2.ExportOptions;


                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;



                    crtermConditionByeLaw2.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else if (MenuCounter == 19)
            {
                LoadInformationFromDb();
                crBoAccNominationForm crboAccNomination = new crBoAccNominationForm();
                crboAccNomination.Load("C:\\CrystalReport1.rpt");
                //crvPdfReport.ReportSource = crboAccNomination;
                BoAccountNomination(crboAccNomination);


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crboAccNomination.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crboAccNomination.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 20)
            {
                ///

                LoadInformationFromDb();
                crBoAccNominationForm2 crboaccNominationForm2 = new crBoAccNominationForm2();
                crboaccNominationForm2.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImages = new DataTable();
                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                BoAccountNomination2(crboaccNominationForm2);

                crboaccNominationForm2.SetDataSource(dataTableImages);

                ////

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crboaccNominationForm2.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crboaccNominationForm2.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 21)
            {
                LoadInformationFromDb();
                crPowerOfAttorney crpowerofAttorney = new crPowerOfAttorney();
                crpowerofAttorney.Load("C:\\CrystalReport1.rpt");
                PowerOfAttorney(crpowerofAttorney);


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crpowerofAttorney.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crpowerofAttorney.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else if (MenuCounter == 22)
            {
                LoadInformationFromDb();
                crPowerOfAttorney2 crpowerOfAttorney2 = new crPowerOfAttorney2();
                crpowerOfAttorney2.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImages = new DataTable();

                dataTableImages = pdfReportBal.GetImage(pdfReportBo);

                PowerOfAttorney2(crpowerOfAttorney2);

                crpowerOfAttorney2.SetDataSource(dataTableImages);


                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crpowerOfAttorney2.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crpowerOfAttorney2.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else if (MenuCounter == 23)
            {
                LoadInformationFromDb();

                crServiceRegistration crserviceRegis = new crServiceRegistration();
                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);
                crserviceReg(crserviceRegis);
                crserviceRegis.SetDataSource(dataTableImage);
                crvPdfReport.ReportSource = crserviceRegis;
            }
            else if (MenuCounter == 24)
            {
                LoadInformationFromDb();
                crLetterOfAuthorization crLetterOfAuthor = new crLetterOfAuthorization();
                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);
                crLetterOfAuth(crLetterOfAuthor);
                crLetterOfAuthor.SetDataSource(dataTableImage);
                crvPdfReport.ReportSource = crLetterOfAuthor;
            }

            else if (MenuCounter == 25)
            {
                LoadInformationFromDb();
                crLetterOfAuthorization crLetterOfAuthor = new crLetterOfAuthorization();
                crLetterOfAuthor.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);
                crLetterOfAuth(crLetterOfAuthor);
                crLetterOfAuthor.SetDataSource(dataTableImage);

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crLetterOfAuthor.ExportOptions;

                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crLetterOfAuthor.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (MenuCounter == 26)
            {
                LoadInformationFromDb();
                crServiceRegistration crserviceRegis = new crServiceRegistration();
                crserviceRegis.Load("C:\\CrystalReport1.rpt");
                DataTable dataTableImage = new DataTable();
                dataTableImage = pdfReportBal.GetImage(pdfReportBo);
                crserviceReg(crserviceRegis);
                crserviceRegis.SetDataSource(dataTableImage);
                crvPdfReport.ReportSource = crserviceRegis;

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crserviceRegis.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crserviceRegis.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 27)
            {
                LoadInformationFromDb();
                cr_CDBLPersonalDetail crCDBLpersonalDetail = new cr_CDBLPersonalDetail();
                crCDBLPerosnalDetails(crCDBLpersonalDetail);
               crvPdfReport.ReportSource = crCDBLpersonalDetail;
            }
            else if (MenuCounter == 28)
            {
                LoadInformationFromDb();
                cr_CDBLPersonalDetail crCDBLpersonalDetail = new cr_CDBLPersonalDetail();
                crCDBLpersonalDetail.Load("C:\\CrystalReport1.rpt");
                crCDBLPerosnalDetails(crCDBLpersonalDetail);
                crvPdfReport.ReportSource = crCDBLpersonalDetail;

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crCDBLpersonalDetail.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crCDBLpersonalDetail.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 29)
            {
                LoadInformationFromDb();
                crCDBL_Additional_Detail crCDBLAddition = new crCDBL_Additional_Detail();
                crCDBLNomineeDetails(crCDBLAddition);
                crvPdfReport.ReportSource = crCDBLAddition;
            }
            else if (MenuCounter == 30)
            {
                LoadInformationFromDb();
                crCDBL_Additional_Detail crCDBLAddition = new crCDBL_Additional_Detail();
                crCDBL_POADetails(crCDBLAddition);
                crvPdfReport.ReportSource = crCDBLAddition;
            }
            else if (MenuCounter == 31)
            {
                LoadInformationFromDb();
                crCDBL_Additional_Detail crCDBLAddition = new crCDBL_Additional_Detail();
                crCDBLAddition.Load("C:\\CrystalReport1.rpt");
                crCDBLNomineeDetails(crCDBLAddition);
                crvPdfReport.ReportSource = crCDBLAddition;

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crCDBLAddition.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crCDBLAddition.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (MenuCounter == 32)
            {
                LoadInformationFromDb();
                crCDBL_Additional_Detail crCDBLAddition = new crCDBL_Additional_Detail();
                crCDBLAddition.Load("C:\\CrystalReport1.rpt");
                crCDBL_POADetails(crCDBLAddition);
                crvPdfReport.ReportSource = crCDBLAddition;

                try
                {
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = PathName;
                    CrExportOptions = crCDBLAddition.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    }
                    crCDBLAddition.Export();

                    MessageBox.Show("Form Sccessfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }
    }
}