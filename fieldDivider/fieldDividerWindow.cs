using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Editor;

namespace fieldDivider
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// Code in this file will:
    ///   Get a reference to the selected layer in the TOC and poputate a combo box named cmbFields with the fiels from the selected layers table
    ///   The user then selected a field in the cmbFields combo box and_
    ///   types in a one character delimeter in the txtDelimiter text box
    ///   When the user clicks the Get Values button, the btnValues_Click method 
    ///     gets the first record in the table
    ///     uses the user-supplied delimeter and separates the values in the user-specified field
    ///     populates the dgvColumns datagrid with the values
    ///   In the datagrid, the user assigns a data type and field name to each delimited value
    ///   The tool will then create a new field for each value using the field names and types specified by the user in the data grid.
    ///   The user clicks the validate button to verify the value in each field is of the data type selected by the user.
    ///   The user then clicks the Make Fields button which will make the fields in the table specified by the user in the datagrid.
    ///   The user then clicks the Populate button which will populate the new fields for each row using the value in the earlier specified field and the user specified delimiter.
    /// </summary>
    public partial class fieldDividerWindow : UserControl
    {
        private IFeatureClass selFC;

        public fieldDividerWindow(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
            setUpDataGrid();            
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private fieldDividerWindow m_windowUI;            

            public AddinImpl()
            {
            }
            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new fieldDividerWindow(this.Hook);
                return m_windowUI.Handle;
            }
            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gets reference to selected layer in TOC and populates drop down box with layers fields
            
            if (cmbFields.Items.Count > 0)
                cmbFields.Items.Clear();
            IMxDocument mxDoc = ArcMap.Application.Document as IMxDocument;
            IContentsView contentView = mxDoc.CurrentContentsView;
            selFC = GetFeatureClassOfSelectedFeatureLayerInContentsView(contentView);

            if (selFC != null)
            {
                IFields fcFields = selFC.Fields;
                IField field = null;

                // On a zero based index, iterate through the fields in the collection.
                for (int i = 0; i < fcFields.FieldCount; i++)
                {
                    field = fcFields.get_Field(i);
                    //cmbFields is a combo box on the form
                    cmbFields.Items.Add(field.AliasName);
                }
            }
        }

        public ESRI.ArcGIS.Geodatabase.IFeatureClass GetFeatureClassOfSelectedFeatureLayerInContentsView(ESRI.ArcGIS.ArcMapUI.IContentsView currentContentsView)
        {
            if (currentContentsView == null)
            {
                return null;
            }
            if (currentContentsView.SelectedItem is ESRI.ArcGIS.Carto.IFeatureLayer)
            {
                ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = (ESRI.ArcGIS.Carto.IFeatureLayer)currentContentsView.SelectedItem; // Explicit Cast
                ESRI.ArcGIS.Geodatabase.IFeatureClass featureClass = featureLayer.FeatureClass;

                return featureClass;
            }
            return null;
        }

        private void btnValues_Click(object sender, EventArgs e)
        {
            if (dgvColumns.RowCount > 0)
            {
                dgvColumns.Rows.Clear();
            }
            
            string fieldName = cmbFields.SelectedItem.ToString();
            IFields fcFieldsFInd = selFC.Fields;
            int fieldInt = fcFieldsFInd.FindField(fieldName);
            //MessageBox.Show(fieldName);
            IFeature firstFeature = selFC.GetFeature(1);
            string FieldValue = firstFeature.get_Value(fieldInt).ToString();
            //MessageBox.Show(FieldValue);
            string delimiter = txtDelimiter.Text;
            string[] split = FieldValue.Split(delimiter.ToCharArray(0,1));
            if (FieldValue.Contains(delimiter))
            {
                MessageBox.Show("There are " + split.Length.ToString() + " delimiters");
            }
                  

            for (int p = 0; p < split.Length; p++)
            {
                dgvColumns.Rows.Add(split[p],"Text");
                                
            }
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            {
                column.Name = "Data Type";
                column.ReadOnly = false;
                //column.Items.AddRange("Text", "Integer", "Double", "Date", "Boolean");
                column.DataSource = new String[]{"Text", "Integer", "Double","Date",};
                //column.Items.Add("Text");
                
                //column.DataPropertyName = ColumnName.TitleOfCourtesy.ToString();
                //column.HeaderText = ColumnName.TitleOfCourtesy.ToString();
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }

        private DataGridViewTextBoxColumn CreateComboTextColumn(string name)
        {
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.Name = name;
            return textColumn;
        }

        private void setUpDataGrid()
        {
            DataGridViewTextBoxColumn textBoxColumnValue;
            textBoxColumnValue = CreateComboTextColumn("Value");
            dgvColumns.Columns.Insert(0, textBoxColumnValue);

            DataGridViewComboBoxColumn comboBoxColumn;

            comboBoxColumn = CreateComboBoxColumn();
            dgvColumns.Columns.Insert(1, comboBoxColumn);
            //dgvColumns.Columns.Add(comboBoxColumn);

            DataGridViewTextBoxColumn textBoxColumnName;
            textBoxColumnName = CreateComboTextColumn("Name");
            dgvColumns.Columns.Insert(2, textBoxColumnName);

        }

        private void btnCreateFields_Click(object sender, EventArgs e)
        {
            int rows = dgvColumns.Rows.Count;
            //MessageBox.Show(rows.ToString());
            int counter;

            for (counter = 0; counter < (dgvColumns.Rows.Count-1); counter++)
            {
                if (dgvColumns.Rows[counter].Cells["Value"].Value.ToString().Length != 0)
                {
                    int humanRow = counter + 1;
                    string cellValue = dgvColumns.Rows[counter].Cells["Value"].Value.ToString();
                    string cellType = dgvColumns.Rows[counter].Cells["Data Type"].Value.ToString();
                    if (validateCells(cellValue, cellType) == false)
                    {
                        MessageBox.Show("Value in row " + humanRow.ToString() + " could not be converted to " + cellType);
                    }
                    else
                    {
                        //MessageBox.Show("Fields are OK");
                        btnMakeFields.Enabled = true;
                    }
                }
            }
        }

        private bool validateCells(string cValue, string cType)
        {
            bool validates;
            int integerResult;
            double doubleResult;
            DateTime dateTimeResult;
            switch (cType)
            {
                case "Integer":
                    {
                        validates = Int32.TryParse(cValue, out integerResult);
                        break;
                    }
                case "Double":
                    {
                        validates = Double.TryParse(cValue, out doubleResult);
                        break;
                    }
                case "Date":
                    {
                        validates = DateTime.TryParse(cValue, out dateTimeResult);
                        break;
                    }
                default:
                    {
                    validates = true;
                    break;
                    }
            }

            return validates;
        }

        private void createFields(string cType, string cName)
        {
            

            IField newField = new FieldClass();
            
            IFieldEdit newFieldEdit = (IFieldEdit)newField;
            newFieldEdit.Name_2 = cName;

            switch (cType)
            {
                case "Integer":
                    {
                        newFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                        break;
                    }
                case "Double":
                    {
                        newFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                        break;
                    }
                case "Date":
                    {
                        newFieldEdit.Type_2 = esriFieldType.esriFieldTypeDate;
                        break;
                    }
                default:
                    {
                        newFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                        newFieldEdit.Length_2 = 255;
                        break;
                    }
            }
            newField = (IField)newFieldEdit;
            selFC.AddField(newField);


        }

        private void btnMakeFields_Click(object sender, EventArgs e)
        {
            ISchemaLock schemaLock = (ISchemaLock)selFC;
            try
            {
                    schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
                    int counter;
                    for (counter = 0; counter < (dgvColumns.Rows.Count - 1); counter++)
                    {
                        if (dgvColumns.Rows[counter].Cells["Value"].Value.ToString().Length != 0)
                        {
                            int humanRow = counter + 1;
                            string cellName = dgvColumns.Rows[counter].Cells["Name"].Value.ToString();
                            string cellType = dgvColumns.Rows[counter].Cells["Data Type"].Value.ToString();
                            createFields(cellType, cellName);
                        }
                    }
                    btnPopulate.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            }

        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                using (ComReleaser comReleaser = new ComReleaser())
                {
                    int counter;
                    int sourceFieldIndex = selFC.FindField(cmbFields.SelectedItem.ToString());

                    IDataset dataSet = (IDataset)selFC;
                    IWorkspace wSpace = dataSet.Workspace;
                    
                    UID uid = new UIDClass();
                    uid.Value = "esriEditor.Editor";
                    IEditor editor = ArcMap.Application.FindExtensionByCLSID(uid) as IEditor;
                    //Check to see if a workspace is already being edited.
                    if (editor.EditState == esriEditState.esriStateNotEditing)
                    {
                        editor.StartEditing(wSpace);
                        //return true;
                    }
                    editor.StartOperation();
                    
                    for (counter = 0; counter < (dgvColumns.Rows.Count - 1); counter++)
                    {
                        IFeatureCursor updateCursor = selFC.Search(null, false);
                        comReleaser.ManageLifetime(updateCursor);

                        int nameFieldIndex = selFC.FindField(dgvColumns.Rows[counter].Cells["Name"].Value.ToString());
                        string cellType = dgvColumns.Rows[counter].Cells["Data Type"].Value.ToString();
                        IFeature row = null;
                        while ((row = updateCursor.NextFeature()) != null)
                        {
                            string FieldValue = row.get_Value(sourceFieldIndex).ToString();
                            string delimiter = txtDelimiter.Text;
                            string[] split = FieldValue.Split(delimiter.ToCharArray(0, 1));
                            string thisValue = split[counter];

                            int integerResult;
                            double doubleResult;
                            DateTime dateTimeResult;

                            switch (cellType)
                            {
                                case "Integer":
                                    {
                                        if (Int32.TryParse(thisValue, out integerResult))
                                        {
                                            row.set_Value(nameFieldIndex, integerResult);
                                            row.Store();
                                        }
                                        break;
                                    }
                                case "Double":
                                    {
                                        if (double.TryParse(thisValue, out doubleResult))
                                        {
                                            row.set_Value(nameFieldIndex, doubleResult);
                                            row.Store();
                                        }
                                        break;
                                    }
                                case "Date":
                                    {
                                        if (DateTime.TryParse(thisValue, out dateTimeResult))
                                        {
                                            row.set_Value(nameFieldIndex, dateTimeResult);
                                            row.Store();
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        row.set_Value(nameFieldIndex, thisValue);
                                        row.Store();
                                        break;
                                    }
                            }
                            //feature.Store();
                        }
                    }
                    editor.StopOperation("Attribute update");
                    editor.StopEditing(true);
                }
                MessageBox.Show("Finished");
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Data.ToString());
            }
        }
        //delete if using a transaction
        public bool StartEditing(ESRI.ArcGIS.Geodatabase.IWorkspace workspaceToEdit)
        {
            //Get a reference to the editor.
            UID uid = new UIDClass();
            uid.Value = "esriEditor.Editor";
            IEditor editor = ArcMap.Application.FindExtensionByCLSID(uid) as IEditor;
            //Check to see if a workspace is already being edited.
            if (editor.EditState == esriEditState.esriStateNotEditing)
            {
                editor.StartEditing(workspaceToEdit);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
