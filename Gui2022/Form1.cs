using System.CodeDom.Compiler;

namespace Gui2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        private int Rows = 10; // readonly in memory variable that compiler does not allow you to change
        private int Columns = 8; // const - Compile time const 

        private Button[,] buttons;

        event EventHandler<EventArgs> OnTickerChangedValue;

        /// <summary>
        /// GUI via programming (not designer)
        /// </summary>
        private void InitializeComponent2()
        {
            buttons = new Button[Rows, Columns];
            for (int r = 0;r<Rows; r++)
            for (int c = 0; c < Columns; c++)
            {
                buttons[r, c] = new Button();
                var b = buttons[r, c];
                b.Dock = System.Windows.Forms.DockStyle.Fill;
                b.TabIndex = 2; // TODO
                b.UseVisualStyleBackColor = true;
                b.Click += ButtonPressed;
                b.Tag = new Point(c, r);

             //   OnTickerChangedValue += ConsiderBuyOrSellStock;
            }

//            OnTickerChangedValue(null,null);

            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
                       // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = Columns;
            for (int c = 0; c < Columns; c++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F/Columns));
            }
            for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Columns; c++)
            {
                this.tableLayoutPanel1.Controls.Add(buttons[r,c], c, r);
            }

            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            this.tableLayoutPanel1.RowCount = Rows;
            for (int r = 0; r < Rows; r++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F/Rows));
            }
            
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1296, 890);
            this.tableLayoutPanel1.TabIndex = 6;
           

            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //private void ConsiderBuyOrSellStock(object? sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void ButtonPressed(object? sender, EventArgs e)
        {
            Console.WriteLine();
        }

        private int inc;

        // NonAsync
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    new Thread( () => SlowOperation()).Start();
        //}

        //Async vs Blocking Call
        private async void button1_Click(object sender, EventArgs e)
        {
            await SlowOperationAsync(); // C# returns to the caller
            // when SlowOperationAsync finishes UI-thread returns to this line
        }


        private async Task SlowOperationAsync()
        {
            await Task.Delay(5000);
            //if (!InvokeRequired) // NOT needed since async runs on current = UI thread
            //{
                UpdateButton1(); // Blocking Call = thread does not progress until complete
            //}
            //else
            //{
            //    BeginInvoke(UpdateButton1);
            //}
        }

        private void SlowOperation()
        { 
            Thread.Sleep(5000); // current thread to sleep
            if (!InvokeRequired)
            {
                UpdateButton1(); // Blocking Call = thread does not progress until complete
            }
            else
            {
                BeginInvoke(UpdateButton1);
            }
        }

        private void UpdateButton1()
        {
            button1.Text = new Random().Next(1000) + "";
        }
    }
}