namespace WinFormsApp_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClearDest_Click(object sender, EventArgs e)
        {
            lstDest.Items.Clear(); // Очищаем коллекцию items
            btnAddSource.Enabled = false;
            btnAddSourseAll.Enabled = false;
            pbDest.Value = 0;
            pgValue();
        }

        private void btnAddDest_Click(object sender, EventArgs e)
        {
            //lstDest.Items.Add(lstSourse.SelectedItems[0]); // Добавляем выделенный Items            
            if (lstSourse.Items.Count == 0)
                btnAddDest.Enabled = false;
            for (int i = 0; i < lstSourse.SelectedItems.Count; i++)
            {
                if (chbDelSourse.Checked)
                    MoveItems(lstSourse, lstDest);
                else
                    lstDest.Items.Add(lstSourse.SelectedItems[i]);
            }
            if (lstDest.Items.Count != 0)
            {
                btnClearDest.Enabled = true;
                btnAddSourseAll.Enabled = true;
                btnAddSource.Enabled = true;
            }
            if (lstSourse.Items.Count == 0)
            {
                btnAddDest.Enabled = false;
                btnAddDestAll.Enabled = false;
            }
            pgValue();
        }

        private void btnAddSource_Click(object sender, EventArgs e)
        {           
            if (lstSourse.Items.Count > 0)
            {
                btnAddDest.Enabled = true;
                btnAddDestAll.Enabled = true;
            }
            for (int i = 0; i < lstDest.SelectedItems.Count; i++)
            {
                if (chbDelSourse.Checked)
                    MoveItems(lstDest, lstSourse);
                else
                    lstDest.Items.Add(lstDest.SelectedItems[i]);
            }
            pgValue();
        }

        private void btnAddDestAll_Click(object sender, EventArgs e)
        {
            if (lstSourse.Items.Count == 0)
                btnAddDestAll.Enabled = false;
            lstDest.Items.AddRange(lstSourse.Items); // Добавляем весь список
            if (chbDelSourse.Checked)
            {
                lstSourse.Items.Clear();
                btnAddDest.Enabled = false;
                btnAddDestAll.Enabled = false;
            }
            if (lstDest.Items.Count != 0)
            {
                btnClearDest.Enabled = true;
                btnAddSourseAll.Enabled = true;
                btnAddSource.Enabled = true;
            }
            pgValue();
        }

        private void btnAddSourseAll_Click(object sender, EventArgs e)
        {
            lstSourse.Items.AddRange(lstDest.Items);
            btnAddDest.Enabled = true;
            btnAddDestAll.Enabled = true;
            if (chbDelSourse.Checked)
            {
                lstDest.Items.Clear();
                btnAddSource.Enabled = false;
                btnAddSourseAll.Enabled = false;
            }
            pgValue();
        }
        private void MoveItems(ListBox Sourse, ListBox Dest)
        {
            for (int i = 0; i < Sourse.SelectedItems.Count;)
            {
                Dest.Items.Add(Sourse.SelectedItems[i]);
                Sourse.Items.Remove(Sourse.SelectedItems[i]);
            }
        }

        private void pgValue() // Доработанный метод (перерасчёт списка > изначальных 5 items)
        {
            int p = lstDest.Items.Count * 20;
            if (p > pbDest.Maximum)
                pbDest.Maximum = p;
            pbDest.Value = p;            
            p = lstSourse.Items.Count * 20;
            if (p > pbSourse.Maximum)
                pbSourse.Maximum = p;
            pbSourse.Value = p;            
        }

        Form form;

        private void btnForm2_Click(object sender, EventArgs e)
        {
            if ((form is null) || (!form.Created))
            {
                form = new Form2(lstDest);
                // form.ShowDialog(); // Только одно окно form2 (модальное окно)
                form.Show(); // Form2 немодальная, можно открыть несколько окон
            }
        }
    }
}
