using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;
using Syncfusion.Data;
using Syncfusion.DataSource;
using System.Collections.Generic;
using Syncfusion.WinForms.ListView;
using Syncfusion.WinForms.DataGrid.GridFiltering;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;

            this.sfDataGrid1.FilterPopupShown += OnSfDataGrid1_FilterPopupShown;
        }
        private void OnSfDataGrid1_FilterPopupShown(object sender, Syncfusion.WinForms.DataGrid.Events.FilterPopupShownEventArgs e)
        {
            if (e.Column.MappingName == "OrderDate")
            {

                e.Control.CheckListBox.View.GroupDescriptors.Add(new GroupDescriptor()
                {
                    PropertyName = "ActualValue",
                    KeySelector = (object obj1) =>
                    {
                        var item = (obj1 as FilterElement);
                        var dateValue = (DateTime)item.ActualValue;
                        return dateValue.Year.ToString();
                    }
                });
            }
        }

        #endregion
    }
}
