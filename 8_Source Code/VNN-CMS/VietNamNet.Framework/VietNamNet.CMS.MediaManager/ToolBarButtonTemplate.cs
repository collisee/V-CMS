using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace VietNamNet.CMS.MediaManager
{
    public class ToolBarButtonTemplate : ITemplate
    {
        private ImageButton searchButton;
        private RadTextBox searchInputBox; // Contains the text for search
        private RadComboBox searchTypeSelector;
        private Label title;
        private RadToolTip tooltip;

        public ToolBarButtonTemplate(string defaultSearchText)
        {
            //input
            searchInputBox = new RadTextBox();
            searchInputBox.EnableViewState = true;
            searchInputBox.ID = "SearchBox1";
            searchInputBox.Width = Unit.Pixel(80);

            if (defaultSearchText != null)
            {
                // use the passed search patern
                searchInputBox.Text = defaultSearchText;
            }

            // label nest to the textbox
            title = new Label();
            title.ID = "SerachBarTitle1";
            title.Text = "Search: ";

            //Combo box
            searchTypeSelector = new RadComboBox();
            searchTypeSelector.ID = "SearchComboBox";
            searchTypeSelector.Width = Unit.Pixel(100);
            searchTypeSelector.Items.Add(new RadComboBoxItem("Contains", "Contains"));
            searchTypeSelector.Items.Add(new RadComboBoxItem("StartsWith", "StartsWith"));
            searchTypeSelector.Items.Add(new RadComboBoxItem("EndsWith", "EndsWith"));
            searchTypeSelector.Items.Add(new RadComboBoxItem("None", "None"));

            // The search button
            searchButton = new ImageButton();
            searchButton.ID = "SearchButton1";
            searchButton.ImageUrl = "~/Images/search.png";
            //searchButton.ImageUrl = "~/Images/LargeIcon/zoom.png";
            searchButton.Height = Unit.Pixel(16);
            searchButton.CssClass = "cpointer pt05";
            searchButton.Click += searchButton_Click;

            // The tootlip 
            tooltip = new RadToolTip();
            tooltip.Load += tooltip_Load;
        }

        #region ITemplate Members

        public void InstantiateIn(Control container)
        {
            // Add the controls to the controls collection ofthe template 

            HtmlGenericControl wrapperDiv = new HtmlGenericControl("DIV");
            wrapperDiv.Controls.Add(title);
            wrapperDiv.Controls.Add(searchInputBox);
            wrapperDiv.Controls.Add(searchTypeSelector);
            wrapperDiv.Controls.Add(searchButton);
            wrapperDiv.Controls.Add(tooltip);
            container.Controls.Add(wrapperDiv);
        }

        #endregion

        private void searchButton_Click(object sender, ImageClickEventArgs e)
        {
            return;
        }

        private void tooltip_Load(object sender, EventArgs e)
        {
            tooltip.TargetControlID = searchInputBox.ClientID;
            tooltip.IsClientID = true;
            tooltip.Text = "H&#227;y ghi th&#244;ng tin c&#7847;n t&#236;m ki&#7871;m";
        }
    }
}