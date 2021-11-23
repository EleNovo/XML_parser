using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace xmlPars
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();          

            var col1 = new DataGridViewColumn();
            col1.HeaderText = "ArchiveName";
            col1.CellTemplate = new DataGridViewTextBoxCell();

            var col2 = new DataGridViewColumn();
            col2.HeaderText = "FileName";
            col2.CellTemplate = new DataGridViewTextBoxCell();

            var col3 = new DataGridViewColumn();
            col3.HeaderText = "regNum";
            col3.CellTemplate = new DataGridViewTextBoxCell();

            var col4 = new DataGridViewColumn();
            col4.HeaderText = "contractSubject";
            col4.CellTemplate = new DataGridViewTextBoxCell();

            var col5 = new DataGridViewColumn();
            col5.HeaderText = "protocolDate";
            col5.CellTemplate = new DataGridViewTextBoxCell();

            var col6 = new DataGridViewColumn();
            col6.HeaderText = "signDate";
            col6.CellTemplate = new DataGridViewTextBoxCell();

            var col7 = new DataGridViewColumn();
            col7.HeaderText = "number";
            col7.CellTemplate = new DataGridViewTextBoxCell();

            var col8 = new DataGridViewColumn();
            col8.HeaderText = "shortName";
            col8.CellTemplate = new DataGridViewTextBoxCell();

            Table.Columns.Add(col1);
            Table.Columns.Add(col2);
            Table.Columns.Add(col3);
            Table.Columns.Add(col4);
            Table.Columns.Add(col5);
            Table.Columns.Add(col6);
            Table.Columns.Add(col7);
            Table.Columns.Add(col8);

            Table.AllowUserToAddRows = false;
        }

        private void choiceB_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();           
            open.Filter = "Archive Files (*.zip *.rar)|*.zip;*.rar";
            open.RestoreDirectory = true;
            open.Title = "Выберите файл";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in open.FileNames)
                {
                    string archiveName = Path.GetFileNameWithoutExtension(file);
                    try
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(file))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                                {
                                    using (StreamReader sr = new StreamReader(entry.Open(), System.Text.Encoding.UTF8))
                                    {
                                        sr.ReadLine();

                                        int row = Table.Rows.Add();
                                        Table.Rows[row].Cells[0].Value = archiveName;
                                        Table.Rows[row].Cells[1].Value = Path.GetFileNameWithoutExtension(entry.FullName);

                                        var idFile_serializer = new XmlSerializer(typeof(contract.export));
                                        var idXML = (contract.export)idFile_serializer.Deserialize(new NamespaceIgnorantXmlTextReader(sr));

                                        Table.Rows[row].Cells[2].Value = idXML.contract.customer.regNum;
                                        Table.Rows[row].Cells[3].Value = idXML.contract.contractSubject;
                                        Table.Rows[row].Cells[4].Value = idXML.contract.protocolDate; Table.Rows[row].Cells[5].Value = idXML.contract.signDate;
                                        Table.Rows[row].Cells[6].Value = idXML.contract.number;
                                        Table.Rows[row].Cells[7].Value = idXML.contract.customer.shortName;
                                    }

                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    exportB.Visible = true;
                }
            }

        }

        private void exportB_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel files (*.xls)|*.xls";    //*.xlsx|*.xlsx *.xlsm|*.xlsm
            save.RestoreDirectory = true;
            save.Title = "Сохранить файл";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Table.SelectAll();
                DataObject dObj = Table.GetClipboardContent();
                if (dObj != null)
                    Clipboard.SetDataObject(dObj);
                object misValue = System.Reflection.Missing.Value;

                Excel.Application excApp;
                Excel.Workbook excworkbook;
                Excel.Worksheet excworksheet;

                excApp = new Excel.Application();
                var workbooks = excApp.Workbooks;
                excworkbook = workbooks.Add(misValue);
                var worksheets = excApp.Worksheets;
                excworksheet = worksheets.Add(misValue);
                excworksheet = (Excel.Worksheet)excworkbook.Worksheets.get_Item(1);
                Excel.Range CR = (Excel.Range)excworksheet.Cells[1, 1];
                CR.Select();
                excworksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                
                excworksheet.Columns.EntireColumn.AutoFit();

                Excel.Range delRange = excworksheet.get_Range("A:A").Cells;
                delRange.Delete(Type.Missing);

                excworkbook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                excApp.DisplayAlerts = true;
                excworkbook.Close(true, misValue, misValue);
                excApp.Quit();

                releaseObject(excApp);
                releaseObject(workbooks);
                releaseObject(worksheets);
                releaseObject(excworkbook);
                releaseObject(excworksheet);

                Clipboard.Clear();
                Table.ClearSelection();

                if (File.Exists(save.FileName))
                    System.Diagnostics.Process.Start(save.FileName);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Исключение во время освобождения объекта" + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
