using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.Application.Controls
{
    public class ComboBoxField:BoundField
    {

        // Fields

        public string BusinessObjectName { get; set; }
        public string SelectMethod { get; set; }
        public string DataTextField { get; set; }
        public string DataValueField { get; set; }
        public string IDDataField { get; set; }

        [Localizable(true), DefaultValue("")]
        public virtual string Text
        {
            get
            {
                object obj2 = base.ViewState["Text"];
                if (obj2 != null)
                {
                    return (string)obj2;
                }
                return string.Empty;
            }
            set
            {
                if (!object.Equals(value, base.ViewState["Text"]))
                {
                    base.ViewState["Text"] = value;
                    this.OnFieldChanged();
                }
            }
        }

        private bool _suppressPropertyThrows;

        // Methods
        protected override void CopyProperties(DataControlField newField)
        {
            ((ComboBoxField)newField).Text = this.Text;
            this._suppressPropertyThrows = true;
            ((ComboBoxField)newField)._suppressPropertyThrows = true;
            base.CopyProperties(newField);
            this._suppressPropertyThrows = false;
            ((ComboBoxField)newField)._suppressPropertyThrows = false;
        }

        protected override DataControlField CreateField()
        {
            return new ComboBoxField();
        }

        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
        {
            Control control = null;
            string dataField = this.DataField;
            object obj2 = null; 
            object obj3 = null;
            if (cell.Controls.Count > 0)
            {

                // Get column editor of type DropDownList of current cell 
                control = cell.Controls[0];
                DropDownList box = control as DropDownList;
                if ((box != null) && (includeReadOnly || box.Enabled))
                {
                    obj2 = box.Text;
                    if (obj2 != null)
                    {

                        // extract value from DropDownList
                        ListItem itm = box.Items.FindByValue(obj2.ToString());
                        obj3 = itm.Text;
                    }

                }
            }
            if (obj2 != null)
            {
                if (dictionary.Contains(dataField))
                {
                    dictionary[dataField] = obj2;
                }
                else
                {
                    //put both text and value into the dictionary
                    dictionary.Add(dataField, obj3);
                    dictionary.Add(this.IDDataField, obj2);
                }
            }
        }

        protected override object GetDesignTimeValue()
        {
            return true;
        }

        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            Control child = null;
            Control control2 = null;
            if ((((rowState & DataControlRowState.Edit) != DataControlRowState.Normal) && !this.ReadOnly) || ((rowState & DataControlRowState.Insert) != DataControlRowState.Normal))
            {
                // If data cell is in edit mode, create DropDownList editor for this cell
                // and set data properties.
                DropDownList box = new DropDownList();
                box.DataSource =this.GetDataSource();
                box.DataMember = this.BusinessObjectName;
                box.DataTextField = this.DataTextField;
                box.DataValueField = this.DataValueField;
                box.DataBind();

                box.ToolTip = this.HeaderText;
                child = box;
                if ((this.DataField.Length != 0) && ((rowState & DataControlRowState.Edit) != DataControlRowState.Normal))
                {
                    control2 = box;
                }
            }
            else if (this.DataField.Length != 0)
            {
                control2 = cell;
            }
            if (child != null)
            {
                cell.Controls.Add(child);


            }
            if ((control2 != null) && base.Visible)
            {
                control2.DataBinding += new EventHandler(this.OnDataBindField);
            }

        }

        protected override void OnDataBindField(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Control namingContainer = control.NamingContainer;
            object dataValue = this.GetValue(namingContainer);
            bool encode = (this.SupportsHtmlEncode && this.HtmlEncode) && (control is TableCell);
            string str = this.FormatDataValue(dataValue, encode);
            if (control is TableCell)
            {
                if (str.Length == 0)
                {
                    str = "&nbsp;";
                }
                ((TableCell)control).Text = str;
            }
            else
            {
                //If data cell is in edit mode, set selected value of DropDownList 
                if (dataValue != null)
                {

                    ListItem itm = ((DropDownList)control).Items.FindByText(dataValue.ToString());
                    ((DropDownList)control).Text = itm.Value;
                }


            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetDataSource()
        {
            Type BusinessObjectType = BuildManager.GetType(this.BusinessObjectName, true);
           object bObject =Activator.CreateInstance(BusinessObjectType);
           return BusinessObjectType.GetMethod(this.SelectMethod).Invoke(bObject, null);

        }
      


    }
}
