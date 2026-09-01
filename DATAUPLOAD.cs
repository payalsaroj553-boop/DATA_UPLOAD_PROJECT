using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;

namespace DATA_UPLOAD_PROJECT
{
    public partial class Dataupload : Form
    {
        string conStr = @"Data Source=.\SQLEXPRESS;
                          Initial Catalog=DataUploadDB;
                          Integrated Security=True";

        DataTable dt = new DataTable();

        public Dataupload()
        {
            InitializeComponent();

        }

        private void SaveErrorLog(
     SqlConnection con,
     string tableName,
     DataRow row,
     string errorMessage)
        {
            SqlCommand cmd =
                new SqlCommand(
                "USP_INSERT_ERRORLOG", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@CompainTable", tableName);

            cmd.Parameters.AddWithValue(
                "@MasterID",
                Convert.ToInt32(row["ID"]));

            cmd.Parameters.AddWithValue(
                "@Name",
                row["Name"].ToString());

            cmd.Parameters.AddWithValue(
                "@MobileNo",
                row["MobileNo"].ToString());

            cmd.Parameters.AddWithValue(
                "@ACNo",
                row["ACNo"].ToString());

            cmd.Parameters.AddWithValue(
                "@Remarks",
                row["Remarks"].ToString());

            cmd.Parameters.AddWithValue(
                "@ErrorMessage",
                errorMessage);

            cmd.ExecuteNonQuery();

        }
        // Browse Excel File
        private void btnbrowes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel Files|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtexcel.Text = ofd.FileName;

                    string conExcel = "";

                    if (Path.GetExtension(ofd.FileName).ToLower() == ".xls")
                    {
                        conExcel =
                        @"Provider=Microsoft.Jet.OLEDB.4.0;
                Data Source=" + ofd.FileName +
                        @";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                    }
                    else
                    {
                        conExcel =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source=" + ofd.FileName +
                        @";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                    }

                    OleDbConnection con = new OleDbConnection(conExcel);

                    con.Open();

                    DataTable schema = con.GetOleDbSchemaTable(
                                       OleDbSchemaGuid.Tables,
                                       null);

                    string sheetName =
                        schema.Rows[0]["TABLE_NAME"].ToString();

                    OleDbDataAdapter da =
                        new OleDbDataAdapter(
                        "SELECT * FROM [" + sheetName + "]",
                        con);

                    dt = new DataTable();

                    da.Fill(dt);

                    con.Close();

                    MessageBox.Show("Excel File Loaded Successfully", "Warning",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Upload Excel Data into MASTER Table
        private void btnupload_Click(object sender, EventArgs e)
        {
              if (string.IsNullOrWhiteSpace(txtexcel.Text))
    {
        MessageBox.Show("Please Browse Excel File First",
            "Warning",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        return;
    }

    if (dt == null || dt.Rows.Count == 0)
    {
        MessageBox.Show("Please select Excel file first.");
        return;
    }

    progressBar1.Visible = true;
    progressBar1.Minimum = 0;
    progressBar1.Maximum = dt.Rows.Count;
    progressBar1.Value = 0;

    int count = 0;
    int rowNo = 2; // Excel row starts after header

    try
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();

            // Delete old data
            using (SqlCommand cmdTruncate = new SqlCommand("USP_TRUNCATE_MASTER", con))
            {
                cmdTruncate.CommandType = CommandType.StoredProcedure;
                cmdTruncate.ExecuteNonQuery();
            }

            foreach (DataRow row in dt.Rows)
            {
                // Skip completely blank rows
                if (row.ItemArray.All(x => string.IsNullOrWhiteSpace(x.ToString())))
                {
                    rowNo++;
                    continue;
                }

                // Skip if Name or Mobile is blank
                if (string.IsNullOrWhiteSpace(row[0].ToString()) ||
                    string.IsNullOrWhiteSpace(row[1].ToString()))
                {
                    rowNo++;
                    continue;
                }

                try
                {
                    using (SqlCommand cmd = new SqlCommand("USP_INSERT_MASTER", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", row[0].ToString().Trim());
                        cmd.Parameters.AddWithValue("@MobileNo", row[1].ToString().Trim());
                        cmd.Parameters.AddWithValue("@ACNo", row[2].ToString().Trim());
                        cmd.Parameters.AddWithValue("@Month", row[3].ToString().Trim());

                        int year = 0;
                        int.TryParse(row[4].ToString(), out year);
                        cmd.Parameters.AddWithValue("@Year", year);

                        cmd.Parameters.AddWithValue("@LangCode", row[5].ToString().Trim());
                        cmd.Parameters.AddWithValue("@CampaignName", row[6].ToString().Trim());

                        decimal totalAmt = 0;
                        decimal.TryParse(row[7].ToString(), out totalAmt);
                        cmd.Parameters.AddWithValue("@TotalAmt", totalAmt);

                        decimal overdueAmt = 0;
                        decimal.TryParse(row[8].ToString(), out overdueAmt);
                        cmd.Parameters.AddWithValue("@OverdueAmt", overdueAmt);

                        decimal lastPaidAmt = 0;
                        decimal.TryParse(row[9].ToString(), out lastPaidAmt);
                        cmd.Parameters.AddWithValue("@LastPaidAmt", lastPaidAmt);

                        cmd.Parameters.AddWithValue("@Address", row[10].ToString().Trim());
                        cmd.Parameters.AddWithValue("@Country", row[11].ToString().Trim());
                        cmd.Parameters.AddWithValue("@City", row[12].ToString().Trim());
                        cmd.Parameters.AddWithValue("@State", row[13].ToString().Trim());
                        cmd.Parameters.AddWithValue("@Remarks", row[14].ToString().Trim());

                        cmd.Parameters.AddWithValue("@CreatedBy", Environment.UserName);

                        cmd.ExecuteNonQuery();
                    }

                    count++;

                    progressBar1.Value = count;

                    lblProgress.Text = ((count * 100) / dt.Rows.Count) + "%";

                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error at Excel Row : " + rowNo +
                        "\n\n" + ex.Message,
                        "Upload Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                rowNo++;
            }
        }

        progressBar1.Value = progressBar1.Maximum;
        lblProgress.Text = "100%";

        MessageBox.Show("Data Uploaded Successfully",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        cmbcompain.Enabled = true;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Upload Error : " + ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
        private void btnsubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtexcel.Text))
            {
                MessageBox.Show("Please Browse Excel File First");
                return;
            }

            if (cmbcompain.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Compain Table First");
                return;
            }

            string tableName =
     cmbcompain.Text.Trim().ToUpper();

            // Procedure Name Select
            string spName = "";

            if (tableName == "TEMP1")
            {
                spName = "USP_INSERT_TEMP1";
            }
            else if (tableName == "TEMP2")
            {
                spName = "USP_INSERT_TEMP2";
            }
            else if (tableName == "TEMP3")
            {
                spName = "USP_INSERT_TEMP3";
            }

            if (string.IsNullOrEmpty(spName))
            {
                MessageBox.Show(
                    "Invalid Table Selected : " + tableName);
                return;
            }

            int successCount = 0;
            int duplicateCount = 0;
            int invalidMobileCount = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // MASTER Data Read
                    SqlCommand cmdSelect =
           new SqlCommand(
           "USP_GET_MASTER_DATA", con);

                    cmdSelect.CommandType =
                        CommandType.StoredProcedure;

                    DataTable dtMaster = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);

                    da.Fill(dtMaster);

                    foreach (DataRow row in dtMaster.Rows)
                    {
                        string mobile = row["MobileNo"].ToString().Trim();
                        string acNo = row["ACNo"].ToString().Trim();

                        long temp;

                        if (mobile.Length != 10 ||
                            !long.TryParse(mobile, out temp))
                        {
                            invalidMobileCount++;

                            SaveErrorLog(
                                con,
                                tableName,
                                row,
                                "Invalid Mobile Number");

                            continue;
                        }

                        // Duplicate Check
                        SqlCommand cmdCheck =
                            new SqlCommand(
                            @"SELECT COUNT(*)
          FROM " + tableName + @"
          WHERE ACNo=@ACNo", con);

                        cmdCheck.Parameters.AddWithValue(
                            "@ACNo", acNo);

                        int count =
                            Convert.ToInt32(
                            cmdCheck.ExecuteScalar());

                        if (count > 0)
                        {
                            duplicateCount++;

                            SaveErrorLog(
                                con,
                                tableName,
                                row,
                                "Duplicate ACNo");

                            continue;
                        }


                        //--------------------------------------------------
                        // Insert Into TEMP Table
                        //--------------------------------------------------

                        SqlCommand cmdInsert =
                            new SqlCommand(spName, con);

                        cmdInsert.CommandType =
                            CommandType.StoredProcedure;

                        cmdInsert.Parameters.AddWithValue(
                            "@MasterID",
                            Convert.ToInt32(row["ID"]));

                        cmdInsert.Parameters.AddWithValue(
                            "@Name",
                            row["Name"].ToString());

                        cmdInsert.Parameters.AddWithValue(
                            "@MobileNo",
                            mobile);

                        cmdInsert.Parameters.AddWithValue(
                            "@ACNo",
                            acNo);

                        cmdInsert.Parameters.AddWithValue(
                            "@Remarks",
                            row["Remarks"].ToString());

                        cmdInsert.Parameters.AddWithValue(
      "@CreatedBy",
      Environment.UserName);

                        try
                        {
                            cmdInsert.ExecuteNonQuery();

                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            SaveErrorLog(
                                con,
                                tableName,
                                row,
                                ex.Message);
                        }
                    }

                    MessageBox.Show(
                        successCount + " Record(s) inserted successfully.\n\n" +
                        duplicateCount + " Duplicate Record(s).\n\n" +
                        invalidMobileCount + " Invalid Mobile Number(s).",
                        "Result",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error : " + ex.Message);
            }
        }

        private void Dataupload_Load(object sender, EventArgs e)
        {
            //btnupload.Enabled = false;
            //btnsubmit.Enabled = false;

            cmbcompain.Text = "Select Table ";
            cmbcompain.Enabled = false;

            progressBar1.Visible = false;
            lblProgress.Text = "";
            progressBar1.Style = ProgressBarStyle.Continuous;
           // progressBar1.Style = ProgressBarStyle.Marquee;

        }



        private void txtexcel_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(
       "Please click Browse button to select Excel file.",
       "Information",
       MessageBoxButtons.OK,
       MessageBoxIcon.Information);

            btnbrowes.Focus();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("USP_Masterdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                     SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

                    // HTML Generate
                    StringBuilder html = new StringBuilder();

                    html.Append("<html>");
                    html.Append("<head>");

                    html.Append("<style>");
                    html.Append("body{font-family:Arial;}");
                    html.Append("table{width:100%;border-collapse:collapse;}");
                    html.Append("th,td{border:1px solid black;padding:8px;text-align:center;}");
                    html.Append("th{background:#4CAF50;color:white;}");
                    html.Append("</style>");

                    html.Append("</head>");
                    html.Append("<body>");

                    html.Append("<h2 align='center'>Master Table Data</h2>");

                    html.Append("<table>");

                    // Column Header
                    html.Append("<tr>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        html.Append("<th>" + col.ColumnName + "</th>");
                    }
                    html.Append("</tr>");

                    // Data Rows
                    foreach (DataRow row in dt.Rows)
                    {
                        html.Append("<tr>");

                        foreach (var item in row.ItemArray)
                        {
                            html.Append("<td>" + item.ToString() + "</td>");
                        }

                        html.Append("</tr>");
                    }

                    html.Append("</table>");
                    html.Append("</body>");
                    html.Append("</html>");

                    // Show HTML in WebBrowser
                    webBrowser1.DocumentText = html.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    
