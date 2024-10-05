using EmployeeNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApplication
{
    
    public partial class frmEmployeeDatabase : Form
    {
        int invalids = 0;// count the number of invalids

        //these variables temporarily hold for invalids
        string empID="";
        string fname="";
        string lname="";
        string pos = "";

        DataTable table = new DataTable("table");
        public frmEmployeeDatabase()
        {
            InitializeComponent();
            
        }
        public void clearTXTBOX() 
        {
            EmployeeIDtxt.Clear();
            FirstNametxt.Clear();
            LastNametxt.Clear();
            Positiontxt.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee1 = new Employee();
            Employee employee2;


            if (EmployeeIDtxt.Text != "" && FirstNametxt.Text != "" && LastNametxt.Text != "" && Positiontxt.Text != "")
            {
                if (EmployeeIDtxt.Text.ToUpper() != "INVALID" && FirstNametxt.Text.ToUpper() != "INVALID" &&
                    LastNametxt.Text.ToUpper() != "INVALID" && Positiontxt.Text.ToUpper() != "INVALID") 
                {
                    //sends data to 'Employee Class' variables using Employee Constructor
                    employee2 = new Employee(EmployeeIDtxt.Text, FirstNametxt.Text, LastNametxt.Text, Positiontxt.Text);
                    //adding data to EmployeeListDatagrid by getting attributes from 'Employee Class'
                    table.Rows.Add(employee2.EmployeeID, employee2.FirstName, employee2.LastName, employee2.Position);
                }
            }
            else 
            {
                invalids++;//count the number of invalids

                //add invalid data to datagrid if doesn't meet the condition
                table.Rows.Add(employee1.EmployeeID, employee1.FirstName, employee1.LastName, employee1.Position);

                //change button location
                button1.Location = new Point(10, 242);
                button2.Location = new Point(109,242);
                button2.Visible = true;
            }
            clearTXTBOX();//clear textboxes after clicking
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmployeeListDataGrid.Rows.Count > 1)// to prevent exception
            {
                //will check if the selected rows equals to invalid
                if (empID.Equals("INVALID") || fname.Equals("INVALID") || lname.Equals("INVALID") || pos.Equals("INVALID")) 
                {
                    //remove invalids
                    foreach (DataGridViewRow row in EmployeeListDataGrid.SelectedRows)
                    {
                        if (EmployeeListDataGrid.Rows.Count > 1)
                        {
                            EmployeeListDataGrid.Rows.Remove(row);
                            invalids--;//decrease the number of invalids if removed
                        }
                    }

                    //empty the variables
                    empID = "";
                    fname = "";
                    lname = "";
                    pos = "";
                }
                
            }

            if (invalids == 0)//check if the invalids equals to 0
            {
                //back to default positions of buttons
                button1.Location = new Point(56, 242);
                button2.Location = new Point(56, 242);
                button2.Visible = false;
            }
 

            
        }

        private void frmEmployeeDatabase_Load(object sender, EventArgs e)
        {
            //adding columns to datagrid
            table.Columns.Add("ID",typeof(String));
            table.Columns.Add("First Name", typeof(String));
            table.Columns.Add("Last Name", typeof(String));
            table.Columns.Add("Position", typeof(String));

            EmployeeListDataGrid.DataSource = table; 
        }

        private void EmployeeListDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get selected index
            int index = e.RowIndex;
            if (index != -1) 
            {
                DataGridViewRow selectedRow = EmployeeListDataGrid.Rows[index];

                //store selected rows value to the specific variables
                empID = selectedRow.Cells[0].Value.ToString();
                fname = selectedRow.Cells[1].Value.ToString();
                lname = selectedRow.Cells[2].Value.ToString();
                pos = selectedRow.Cells[3].Value.ToString();
            }
            

            
        }

        private void EmployeeIDtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }
    }
}
