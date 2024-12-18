using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReportViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the Crystal Report
            LoadCrystalReport();
        }

        private void LoadCrystalReport()
        {
            try
            {
                string reportPath = @"C:\Users\Equilap41\Documents\GitHub\HRMS\BBK-HRMS-MVC\HRMS\Reports\M5\rptM5_ListMnthDistribution.rpt";

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("Report file not found at: " + reportPath);
                    return;
                }

                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportPath);

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@i_CompanyCd", "BBK" },
                    { "@i_GroupCd", " " },
                    { "@i_DivisionCd", "" },
                    { "@i_DepartmentCd", "" },
                    { "@i_SectionCd", "" },
                    { "@i_Emp_No", "1763" },
                    { "@i_For_Month", "01/01/2021" },
                    { "@i_Incharger_Emp_No", "1763" },
                    { "@i_Status", "A" },
                };

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    reportDocument.SetParameterValue(param.Key, param.Value);
                }

                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
