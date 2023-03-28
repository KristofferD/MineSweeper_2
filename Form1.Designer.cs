namespace MineSweeperAgain
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameBoard = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gameBoard).BeginInit();
            SuspendLayout();
            // 
            // gameBoard
            // 
            gameBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gameBoard.Dock = DockStyle.Fill;
            gameBoard.Location = new Point(0, 0);
            gameBoard.Name = "gameBoard";
            gameBoard.ReadOnly = true;
            gameBoard.RowTemplate.Height = 25;
            gameBoard.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gameBoard.Size = new Size(800, 450);
            gameBoard.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gameBoard);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gameBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gameBoard;
    }
}