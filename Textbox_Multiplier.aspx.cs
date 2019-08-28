using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Textbox_Multiplier : System.Web.UI.Page
    {
        int index = 0;
        // Everything done statically... to speed up the process


        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> _musicalInstruments = new List<string>();
            _musicalInstruments.Add("Guitar");
            _musicalInstruments.Add("Piano");
            _musicalInstruments.Add("Drums");
            _musicalInstruments.Add("Bass");
            _musicalInstruments.Add("Kahoon");

            // Assign values at initial stage.
            // If a database is connected, values can be fetched from there.
            // Then comes the concept of Display Member & Value Member. 
            // until then, single values... from lists... to speed up the process.
            if (!IsPostBack)
            {
                MusicalCategories_DropDown.DataSource = _musicalInstruments;
                MusicalCategories_DropDown.DataBind();
                MusicalTeachers_DropDown.Enabled = false;
            }  
            // Never Forget!
        }

        protected void AddNewFieldButton_Click(object sender, EventArgs e)
        {
            index = Panel1.Controls.OfType<TextBox>().ToList().Count+1;   
            CreateTextBox("txtBox_" + index);
        }

        protected void S2DB_Button_Click(object sender, EventArgs e)
        {
            //Required Field VAlidation.
          
            bool flag = true;
            // OPtimise.... 

            index = Panel1.Controls.OfType<TextBox>().ToList().Count;
            // Needs to be calculated again(?) 
            if (index >= 1)
            {
                for (int i = 1; i <= index; i++)
                {
                    if (String.IsNullOrWhiteSpace(FetchValueFromField("txtBox_" + i)))
                    {
                        // Show alert box.. how?
                        // using javascript. invoke it from here?
                        // Like this?
                        // Google it. 
                        Response.Write("Field(s) cannot be empty!<br>");
                        flag = false;
                        break;
                        // Stop Execution
                    }

                }
                if (flag)
                {
                    //Save to Database.
                    // So lazy.
                }

                // else , do nothing. 
                //This should do the trick.
            }
            else
            {
                Response.Write("Atleast One field must be necessary to save!");
            }
        }
        private string FetchValueFromField(string id)
        {
            TextBox txt =  Panel1.FindControl(id) as TextBox;
            return txt.Text;
        }
        private void CreateTextBox(string id)
        {
            //Create new textBox object
            TextBox txt = new TextBox();
            //Assign ID (sent from button click) to uniquely identify
            txt.ID = id;


            //Make it visible
            //Dynamically Add it to the panel.

            //Panel - Container for other Form controls/ Allows for creating new controls programmaticlaly (On the fly)
            Panel1.Controls.Add(txt);

            //Literals are basically strings that are to be added "as is" to the rendering page.
            Literal lt = new Literal();
            lt.Text = "<br />";
            //Break tag(s) added to the panel.
            Panel1.Controls.Add(lt);
        }

        //To persist the controls after submitting, we use postback
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //StackOverflow.
            //Identifies all elements whose ID Contains the following text
            //Stores to list.
            // List stays even after page reload
            // Form controls stay even after page reload.
            // Data persists.
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtBox_")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.CreateTextBox("txtBox_" + i);
                i++;
            }
        }

        protected void RemoveAll_Button_Click(object sender, EventArgs e)
        {
            //Index value needs to be calculated again(?) 
            index = Panel1.Controls.OfType<TextBox>().ToList().Count;
            for (int i = index;  i>0; i--)
            {
                string id = "txtBox_" + i;
                RemoveControl(id);
            }
            //Reset.
            index = 0;
           
        }
        // One Function for removing any kind of control.
        private void RemoveControl(string id)
        {
            Control cntrl = Panel1.FindControl(id);
            if (Panel1.Controls.Contains(cntrl))
                Panel1.Controls.Remove(cntrl);
            // The extra <br> tag has to be removed as well. 
            // Buggy implementation... 

            // Solution = Change sequence. (Done)
            
        }

        // REmove latest TextField.
        protected void RemoveLast_Button_Click(object sender, EventArgs e)
        {
            //this again.. think of a better sol.
            index = Panel1.Controls.OfType<TextBox>().ToList().Count;
            string id = "txtBox_" + index;
            RemoveControl(id);
           
            --index;
            // Never Forget.
        }

        protected void MusicalCategories_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MusicalTeachers_DropDown.Enabled = true;
            // Never Forget!
            switch (MusicalCategories_DropDown.SelectedItem.Text)
            {
                case "Bass":
                    List<string> _bassTeachers = new List<string>();
                    _bassTeachers.Add("Mr. John");
                    _bassTeachers.Add("Mr. Akshay");

                    MusicalTeachers_DropDown.DataSource = _bassTeachers;
                    MusicalTeachers_DropDown.DataBind();
                    break;

                case "Guitar":
                    List<string> _guitarTeachers = new List<string>();
                    _guitarTeachers.Add("Mr.Ramesh");
                    _guitarTeachers.Add("Mr.Suresh");
                    _guitarTeachers.Add("Mr.Suith");
                    _guitarTeachers.Add("Mr.Karthik");
                    MusicalTeachers_DropDown.DataSource = _guitarTeachers;
                    MusicalTeachers_DropDown.DataBind();
                    break;

                case "Kahoon":
                    List<string> _kahoonTeachers = new List<string>();
                    _kahoonTeachers.Add("Mr. Niranjan");
                    MusicalTeachers_DropDown.DataSource = _kahoonTeachers;
                    MusicalTeachers_DropDown.DataBind();
                    break;

                case "Drums":
                    List<string> _drumsTeachers = new List<string>();
                    _drumsTeachers.Add("Mrs.Sushma");
                    _drumsTeachers.Add("Miss Lakshmi");
                    MusicalTeachers_DropDown.DataSource = _drumsTeachers;
                    MusicalTeachers_DropDown.DataBind();

                    break;

                case "Piano":
                    List<string> _pianoTeachers = new List<string>();
                    _pianoTeachers.Add("Mr.Ajay");
                    _pianoTeachers.Add("Mr.Vijay");
                    MusicalTeachers_DropDown.DataSource = _pianoTeachers;
                    MusicalTeachers_DropDown.DataBind();
                    break;
                default: // stays empty.
                    break;
            }
        }
    }
}