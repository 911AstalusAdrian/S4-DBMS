namespace Lab1Solution
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvChildrenTable = new System.Windows.Forms.DataGridView();
            this.dgvParentTable = new System.Windows.Forms.DataGridView();
            this.btnDisplayChildren = new System.Windows.Forms.Button();
            this.btnAddChildren = new System.Windows.Forms.Button();
            this.btnUpdateChildren = new System.Windows.Forms.Button();
            this.btnRemoveChildren = new System.Windows.Forms.Button();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblChildren = new System.Windows.Forms.Label();
            this.tbParentID = new System.Windows.Forms.TextBox();
            this.tbRoomID = new System.Windows.Forms.TextBox();
            this.tbRoomCap = new System.Windows.Forms.TextBox();
            this.tbRoomType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildrenTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChildrenTable
            // 
            this.dgvChildrenTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChildrenTable.Location = new System.Drawing.Point(749, 12);
            this.dgvChildrenTable.Name = "dgvChildrenTable";
            this.dgvChildrenTable.Size = new System.Drawing.Size(624, 276);
            this.dgvChildrenTable.TabIndex = 0;
            // 
            // dgvParentTable
            // 
            this.dgvParentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParentTable.Location = new System.Drawing.Point(12, 12);
            this.dgvParentTable.Name = "dgvParentTable";
            this.dgvParentTable.Size = new System.Drawing.Size(624, 276);
            this.dgvParentTable.TabIndex = 1;
            // 
            // btnDisplayChildren
            // 
            this.btnDisplayChildren.Location = new System.Drawing.Point(218, 359);
            this.btnDisplayChildren.Name = "btnDisplayChildren";
            this.btnDisplayChildren.Size = new System.Drawing.Size(196, 56);
            this.btnDisplayChildren.TabIndex = 3;
            this.btnDisplayChildren.Text = "Display Children Records";
            this.btnDisplayChildren.UseVisualStyleBackColor = true;
            this.btnDisplayChildren.Click += new System.EventHandler(this.btnDisplayChildren_Click);
            // 
            // btnAddChildren
            // 
            this.btnAddChildren.Location = new System.Drawing.Point(749, 374);
            this.btnAddChildren.Name = "btnAddChildren";
            this.btnAddChildren.Size = new System.Drawing.Size(196, 56);
            this.btnAddChildren.TabIndex = 4;
            this.btnAddChildren.Text = "Add Children";
            this.btnAddChildren.UseVisualStyleBackColor = true;
            this.btnAddChildren.Click += new System.EventHandler(this.btnAddChildren_Click);
            // 
            // btnUpdateChildren
            // 
            this.btnUpdateChildren.Location = new System.Drawing.Point(962, 374);
            this.btnUpdateChildren.Name = "btnUpdateChildren";
            this.btnUpdateChildren.Size = new System.Drawing.Size(196, 56);
            this.btnUpdateChildren.TabIndex = 5;
            this.btnUpdateChildren.Text = "Update Children";
            this.btnUpdateChildren.UseVisualStyleBackColor = true;
            this.btnUpdateChildren.Click += new System.EventHandler(this.btnUpdateChildren_Click);
            // 
            // btnRemoveChildren
            // 
            this.btnRemoveChildren.Location = new System.Drawing.Point(1177, 374);
            this.btnRemoveChildren.Name = "btnRemoveChildren";
            this.btnRemoveChildren.Size = new System.Drawing.Size(196, 56);
            this.btnRemoveChildren.TabIndex = 6;
            this.btnRemoveChildren.Text = "Remove Children";
            this.btnRemoveChildren.UseVisualStyleBackColor = true;
            this.btnRemoveChildren.Click += new System.EventHandler(this.btnRemoveChildren_Click);
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(277, 301);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(68, 13);
            this.lblParent.TabIndex = 7;
            this.lblParent.Text = "Parent Table";
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.Location = new System.Drawing.Point(1049, 301);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(75, 13);
            this.lblChildren.TabIndex = 8;
            this.lblChildren.Text = "Children Table";
            // 
            // tbParentID
            // 
            this.tbParentID.Location = new System.Drawing.Point(261, 333);
            this.tbParentID.Name = "tbParentID";
            this.tbParentID.Size = new System.Drawing.Size(100, 20);
            this.tbParentID.TabIndex = 9;
            this.tbParentID.Text = "ParentID";
            this.tbParentID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRoomID
            // 
            this.tbRoomID.Location = new System.Drawing.Point(801, 333);
            this.tbRoomID.Name = "tbRoomID";
            this.tbRoomID.Size = new System.Drawing.Size(100, 20);
            this.tbRoomID.TabIndex = 10;
            this.tbRoomID.Text = "RoomID";
            this.tbRoomID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRoomCap
            // 
            this.tbRoomCap.Location = new System.Drawing.Point(1012, 333);
            this.tbRoomCap.Name = "tbRoomCap";
            this.tbRoomCap.Size = new System.Drawing.Size(100, 20);
            this.tbRoomCap.TabIndex = 11;
            this.tbRoomCap.Text = "Room Capacity";
            this.tbRoomCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRoomType
            // 
            this.tbRoomType.Location = new System.Drawing.Point(1226, 333);
            this.tbRoomType.Name = "tbRoomType";
            this.tbRoomType.Size = new System.Drawing.Size(100, 20);
            this.tbRoomType.TabIndex = 12;
            this.tbRoomType.Text = "Room Type";
            this.tbRoomType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 485);
            this.Controls.Add(this.tbRoomType);
            this.Controls.Add(this.tbRoomCap);
            this.Controls.Add(this.tbRoomID);
            this.Controls.Add(this.tbParentID);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.btnRemoveChildren);
            this.Controls.Add(this.btnUpdateChildren);
            this.Controls.Add(this.btnAddChildren);
            this.Controls.Add(this.btnDisplayChildren);
            this.Controls.Add(this.dgvParentTable);
            this.Controls.Add(this.dgvChildrenTable);
            this.Name = "Form1";
            this.Text = "Lab 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChildrenTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChildrenTable;
        private System.Windows.Forms.DataGridView dgvParentTable;
        private System.Windows.Forms.Button btnDisplayChildren;
        private System.Windows.Forms.Button btnAddChildren;
        private System.Windows.Forms.Button btnUpdateChildren;
        private System.Windows.Forms.Button btnRemoveChildren;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.TextBox tbParentID;
        private System.Windows.Forms.TextBox tbRoomID;
        private System.Windows.Forms.TextBox tbRoomCap;
        private System.Windows.Forms.TextBox tbRoomType;
    }
}

