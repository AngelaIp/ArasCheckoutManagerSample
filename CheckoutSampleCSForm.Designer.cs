namespace CheckoutSampleCS
{
	partial class CheckoutSampleCSForm
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
            this.urlLbl = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.dbLbl = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.syncCheckoutBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.asyncCheckoutBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.thLbl = new System.Windows.Forms.Label();
            this.thCount = new System.Windows.Forms.NumericUpDown();
            this.sfLbl = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxDocuments = new System.Windows.Forms.ListBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.btnGetDatabases = new System.Windows.Forms.Button();
            this.lblRes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbQueryAction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.btnRunSearch = new System.Windows.Forms.Button();
            this.btnSelectAllFiles = new System.Windows.Forms.Button();
            this.btnDeselectAllFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlLbl
            // 
            this.urlLbl.AutoSize = true;
            this.urlLbl.Location = new System.Drawing.Point(12, 16);
            this.urlLbl.Name = "urlLbl";
            this.urlLbl.Size = new System.Drawing.Size(32, 13);
            this.urlLbl.TabIndex = 0;
            this.urlLbl.Text = "URL:";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(78, 12);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(320, 20);
            this.textBoxURL.TabIndex = 1;
            // 
            // dbLbl
            // 
            this.dbLbl.AutoSize = true;
            this.dbLbl.Location = new System.Drawing.Point(12, 41);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(56, 13);
            this.dbLbl.TabIndex = 2;
            this.dbLbl.Text = "Database:";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(736, 12);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(112, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // syncCheckoutBtn
            // 
            this.syncCheckoutBtn.Enabled = false;
            this.syncCheckoutBtn.Location = new System.Drawing.Point(736, 68);
            this.syncCheckoutBtn.Name = "syncCheckoutBtn";
            this.syncCheckoutBtn.Size = new System.Drawing.Size(112, 23);
            this.syncCheckoutBtn.TabIndex = 5;
            this.syncCheckoutBtn.Text = "Sync Checkout";
            this.syncCheckoutBtn.UseVisualStyleBackColor = true;
            this.syncCheckoutBtn.Click += new System.EventHandler(this.syncCheckoutBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(736, 124);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(112, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // asyncCheckoutBtn
            // 
            this.asyncCheckoutBtn.Location = new System.Drawing.Point(736, 96);
            this.asyncCheckoutBtn.Name = "asyncCheckoutBtn";
            this.asyncCheckoutBtn.Size = new System.Drawing.Size(112, 23);
            this.asyncCheckoutBtn.TabIndex = 7;
            this.asyncCheckoutBtn.Text = "Async Checkout";
            this.asyncCheckoutBtn.UseVisualStyleBackColor = true;
            this.asyncCheckoutBtn.Click += new System.EventHandler(this.asyncCheckoutBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 567);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(833, 16);
            this.progressBar.TabIndex = 8;
            // 
            // thLbl
            // 
            this.thLbl.AutoSize = true;
            this.thLbl.Location = new System.Drawing.Point(6, 249);
            this.thLbl.Name = "thLbl";
            this.thLbl.Size = new System.Drawing.Size(49, 13);
            this.thLbl.TabIndex = 9;
            this.thLbl.Text = "Threads:";
            // 
            // thCount
            // 
            this.thCount.Location = new System.Drawing.Point(107, 245);
            this.thCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.thCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thCount.Name = "thCount";
            this.thCount.Size = new System.Drawing.Size(82, 20);
            this.thCount.TabIndex = 10;
            this.thCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sfLbl
            // 
            this.sfLbl.AutoSize = true;
            this.sfLbl.Location = new System.Drawing.Point(299, 307);
            this.sfLbl.Name = "sfLbl";
            this.sfLbl.Size = new System.Drawing.Size(0, 13);
            this.sfLbl.TabIndex = 11;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(78, 64);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(116, 20);
            this.textBoxLogin.TabIndex = 12;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(270, 63);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(128, 20);
            this.textBoxPassword.TabIndex = 13;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(107, 217);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(120, 20);
            this.textBoxDestination.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Destination Folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Select CAD Items:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Select Files:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Result:";
            // 
            // listBoxDocuments
            // 
            this.listBoxDocuments.FormattingEnabled = true;
            this.listBoxDocuments.Location = new System.Drawing.Point(15, 323);
            this.listBoxDocuments.Name = "listBoxDocuments";
            this.listBoxDocuments.Size = new System.Drawing.Size(199, 238);
            this.listBoxDocuments.TabIndex = 21;
            this.listBoxDocuments.SelectedIndexChanged += new System.EventHandler(this.listBoxDocuments_SelectedIndexChanged);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(220, 323);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(217, 238);
            this.listBoxFiles.TabIndex = 22;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(443, 323);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(402, 238);
            this.textBoxResult.TabIndex = 23;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(78, 37);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(320, 21);
            this.cmbDatabase.TabIndex = 24;
            this.cmbDatabase.TextChanged += new System.EventHandler(this.cmbDatabase_TextChanged);
            // 
            // btnGetDatabases
            // 
            this.btnGetDatabases.Location = new System.Drawing.Point(404, 37);
            this.btnGetDatabases.Name = "btnGetDatabases";
            this.btnGetDatabases.Size = new System.Drawing.Size(26, 23);
            this.btnGetDatabases.TabIndex = 25;
            this.btnGetDatabases.Text = "...";
            this.btnGetDatabases.UseVisualStyleBackColor = true;
            this.btnGetDatabases.Click += new System.EventHandler(this.btnGetDatabases_Click);
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(6, 72);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(195, 13);
            this.lblRes.TabIndex = 27;
            this.lblRes.Text = "Resolution (GetResolvedStructure Only)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxItemID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbQueryAction);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbResolution);
            this.groupBox1.Controls.Add(this.lblRes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.thLbl);
            this.groupBox1.Controls.Add(this.thCount);
            this.groupBox1.Controls.Add(this.textBoxDestination);
            this.groupBox1.Location = new System.Drawing.Point(472, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 274);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // textBoxItemID
            // 
            this.textBoxItemID.Location = new System.Drawing.Point(9, 188);
            this.textBoxItemID.Name = "textBoxItemID";
            this.textBoxItemID.Size = new System.Drawing.Size(218, 20);
            this.textBoxItemID.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Item ID";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Location = new System.Drawing.Point(9, 140);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(218, 21);
            this.cmbSearchType.TabIndex = 32;
            this.cmbSearchType.TextChanged += new System.EventHandler(this.cmbSearchType_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Item Search";
            // 
            // cmbQueryAction
            // 
            this.cmbQueryAction.FormattingEnabled = true;
            this.cmbQueryAction.Location = new System.Drawing.Point(9, 44);
            this.cmbQueryAction.Name = "cmbQueryAction";
            this.cmbQueryAction.Size = new System.Drawing.Size(218, 21);
            this.cmbQueryAction.TabIndex = 30;
            this.cmbQueryAction.TextChanged += new System.EventHandler(this.cmbQueryAction_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Query Method";
            // 
            // cmbResolution
            // 
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(9, 92);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(218, 21);
            this.cmbResolution.TabIndex = 28;
            this.cmbResolution.TextChanged += new System.EventHandler(this.cmbResolution_TextChanged);
            // 
            // btnRunSearch
            // 
            this.btnRunSearch.Location = new System.Drawing.Point(736, 40);
            this.btnRunSearch.Name = "btnRunSearch";
            this.btnRunSearch.Size = new System.Drawing.Size(112, 23);
            this.btnRunSearch.TabIndex = 29;
            this.btnRunSearch.Text = "Run Search";
            this.btnRunSearch.UseVisualStyleBackColor = true;
            this.btnRunSearch.Click += new System.EventHandler(this.btnRunSearch_Click);
            // 
            // btnSelectAllFiles
            // 
            this.btnSelectAllFiles.Location = new System.Drawing.Point(739, 261);
            this.btnSelectAllFiles.Name = "btnSelectAllFiles";
            this.btnSelectAllFiles.Size = new System.Drawing.Size(109, 23);
            this.btnSelectAllFiles.TabIndex = 30;
            this.btnSelectAllFiles.Text = "Select All Files";
            this.btnSelectAllFiles.UseVisualStyleBackColor = true;
            this.btnSelectAllFiles.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAllFiles
            // 
            this.btnDeselectAllFiles.Location = new System.Drawing.Point(739, 290);
            this.btnDeselectAllFiles.Name = "btnDeselectAllFiles";
            this.btnDeselectAllFiles.Size = new System.Drawing.Size(109, 23);
            this.btnDeselectAllFiles.TabIndex = 31;
            this.btnDeselectAllFiles.Text = "Deselect All Files";
            this.btnDeselectAllFiles.UseVisualStyleBackColor = true;
            this.btnDeselectAllFiles.Click += new System.EventHandler(this.btnDeselectAllFiles_Click);
            // 
            // CheckoutSampleCSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 595);
            this.Controls.Add(this.btnDeselectAllFiles);
            this.Controls.Add(this.btnSelectAllFiles);
            this.Controls.Add(this.btnRunSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetDatabases);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.listBoxDocuments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.sfLbl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.asyncCheckoutBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.syncCheckoutBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.dbLbl);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.urlLbl);
            this.Name = "CheckoutSampleCSForm";
            this.Text = "Checkout Manager Sample";
            ((System.ComponentModel.ISupportInitialize)(this.thCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label urlLbl;
		private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label dbLbl;
		private System.Windows.Forms.Button loginBtn;
		private System.Windows.Forms.Button syncCheckoutBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button asyncCheckoutBtn;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label thLbl;
		private System.Windows.Forms.NumericUpDown thCount;
		private System.Windows.Forms.Label sfLbl;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListBox listBoxDocuments;
		private System.Windows.Forms.ListBox listBoxFiles;
		private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Button btnGetDatabases;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.ComboBox cmbQueryAction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxItemID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRunSearch;
        private System.Windows.Forms.Button btnSelectAllFiles;
        private System.Windows.Forms.Button btnDeselectAllFiles;
	}
}

