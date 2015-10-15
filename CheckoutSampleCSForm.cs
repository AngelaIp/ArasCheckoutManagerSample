using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Aras.IOM;
using Aras.IOME;


public enum CheckoutManagerState
{
	idle = 0,
	running = 1,
	paused = 2,
}


namespace CheckoutSampleCS
{
	public partial class CheckoutSampleCSForm : Form
	{

        static string _db = Properties.Settings.Default.Database;
        static string _password = Properties.Settings.Default.Password;
        static string _url = Properties.Settings.Default.Url;
        static string _user = Properties.Settings.Default.User;
        static string _itemID = Properties.Settings.Default.ItemID;
        static string _destination = Properties.Settings.Default.Destination;
        static decimal _threads = Properties.Settings.Default.Threads;
        static HttpServerConnection _conn = null;

        CheckoutManager m_cmgr;
        Innovator m_inn;
        int m_failed_count;
        CheckoutManagerState m_status;
        Item m_pDoc;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        List<listResolution> structureResolution = new List<listResolution> { 
                                                        new listResolution("As Saved"), 
                                                        new listResolution("Released"), 
                                                        new listResolution("Current") 
                                                    };

        List<listQuaryAction> quaryAction = new List<listQuaryAction> { 
                                                        new listQuaryAction("PE_GetResolvedStructure"),
                                                        new listQuaryAction("GetItemRepeatConfig")
                                                    };



        List<listSearchType> searchType = new List<listSearchType>{ 
                                                        new listSearchType("Single"), 
                                                        new listSearchType("All")
                                                    };

        static string _requestCADsingle = @"<AML>
                                    <Item type='CAD' action='get' id='{0}' select='id,item_number'>
                                    </Item>
                                </AML>";

        static string _requestCADall = @"<AML>
                                    <Item type='CAD' action='get' select='id,item_number'>
                                    </Item>
                                </AML>";

        static string _getItemRepeatConfig = @"<AML>
                                        <Item type='CAD' id='{0}' action='GetItemRepeatConfig' select='*'>
                                            <Relationships>
                                                <Item type='CAD Structure' select='*' repeatProp='related_id' repeatTimes='0' />
                                            </Relationships>
                                            <native_file>
                                                <Item type='File' select='filename' action='get'>
                                                    <Relationships>
                                                        <Item type='Located' select='related_id(id, vault_url)' />
                                                    </Relationships>
                                                </Item>
                                            </native_file>
                                        </Item>
                                    </AML>";



//        static string _getResolvedStructure = @"<AML>
//        	                                        <Item type='CAD' id='{0}' action='PE_GetResolvedStructure' resolution='{1}' select='native_file,external_id,cax_fil_old_name,cax_fil_old_path,cax_fil_path,cax_flag,external_owner,is_template,is_standard,cax_timestamp,cax_type,config_id,keyed_name,major_rev,generation,locked_by_id'>
//        		                                        <Relationships>
//        			                                        <Item type='CAD Structure' select='*' repeatProp='related_id' repeatTimes='0' />
//        		                                        </Relationships>
//        		                                        <native_file>
//        			                                        <Item type='File' select='filename' action='get'>
//        				                                        <Relationships>
//        					                                        <Item type='Located' select='file_version,related_id(id, vault_url)' />
//        				                                        </Relationships>
//        			                                        </Item>
//        		                                        </native_file>
//        	                                        </Item>
//                                                </AML>";




        static string _getResolvedStructure = @"<AML>
	                                        <Item type='CAD' id='{0}' action='PE_GetResolvedStructure' resolution='{1}' select='native_file,external_id,cax_fil_old_name,cax_fil_old_path,cax_fil_path,cax_flag,external_owner,is_template,is_standard,cax_timestamp,cax_type,config_id,keyed_name,major_rev,generation,locked_by_id'>
		                                        <native_file>
			                                        <Item type='File' select='filename'>
				                                        <Relationships>
					                                        <Item type='Located' select='file_version,related_id(id, vault_url)' />
				                                        </Relationships>
			                                        </Item>
		                                        </native_file>
		                                        <Relationships>
			                                        <Item type='CAD Structure' repeatProp='related_id' repeatTimes='0' select='related_id, external_id, external_owner, external_type' />
			                                        <Item type='CAD File' select='related_id'>
				                                        <related_id>
					                                        <Item type='File' select='filename'>
						                                        <Relationships>
							                                        <Item type='Located' select='file_version,related_id(id, vault_url)' />
						                                        </Relationships>
					                                        </Item>
				                                        </related_id>
			                                        </Item>
		                                        </Relationships>
	                                        </Item>
                                        </AML>";

		public CheckoutSampleCSForm()
		{
			InitializeComponent();
			SetInitialState();
		}

		private void SetInitialState()
		{
            textBoxURL.Text = _url;
            cmbDatabase.Text = _db;
            textBoxLogin.Text = _user;
            textBoxPassword.Text = _password;
            textBoxDestination.Text = _destination;
            textBoxItemID.Text = _itemID;
            thCount.Value = _threads;

            cmbResolution.DataSource = structureResolution;
            cmbResolution.DisplayMember = "Name";
            cmbResolution.ValueMember = "Name";

            cmbQueryAction.DataSource = quaryAction;
            cmbQueryAction.DisplayMember = "Name";
            cmbQueryAction.ValueMember = "Name";

            cmbSearchType.DataSource = searchType;
            cmbSearchType.DisplayMember = "Name";
            cmbSearchType.ValueMember = "Name";

			loginBtn.Enabled = true;
			syncCheckoutBtn.Enabled = false;
			cancelBtn.Enabled = false;
			asyncCheckoutBtn.Enabled = false;
			sfLbl.Visible = false;
            btnRunSearch.Enabled = false;

			progressBar.Visible = true;
			progressBar.Minimum = 0;
			progressBar.Maximum = 100;

			m_status = CheckoutManagerState.idle;
			m_failed_count = 0;
		}

        private void btnGetDatabases_Click(object sender, EventArgs e)
        {
            //Attempt Login
            _user = textBoxLogin.Text;
            _password = textBoxPassword.Text;
            _url = textBoxURL.Text;
            _db = cmbDatabase.Text;

            //write config file
            saveConfig();


            //get dbs from test connection
            try
            {
                _conn = IomFactory.CreateHttpServerConnection(_url, _db, _user, _password);
                string[] databases = _conn.GetDatabases();
                for (int i = 0; i < databases.Length; i++)
                {
                    cmbDatabase.Items.Add(databases[i]);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //reset
        private void connLogout()
        {
            //make sure there is a connection object (this event is called when form is first displayed)
            if (_conn != null)
            {
                _conn.Logout();
                loginBtn.Enabled = true;
                syncCheckoutBtn.Enabled = false;
                cancelBtn.Enabled = false;
                asyncCheckoutBtn.Enabled = false;
                sfLbl.Visible = false;

                setupSearch(false);

                btnRunSearch.Enabled = false;
            }
        }

		private void loginBtn_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

            _conn = IomFactory.CreateHttpServerConnection(textBoxURL.Text, cmbDatabase.Text, textBoxLogin.Text, textBoxPassword.Text);
            Item result = _conn.Login();
			if (result.isError())
			{
				MessageBox.Show(string.Format("Login failed with error: {0}", result.getErrorString()), "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            this.m_inn = IomFactory.CreateInnovator(_conn);

            btnRunSearch.Enabled = true;
			loginBtn.Enabled = false;
		}

        /// <summary>
        /// Saves the values entered into the form so that they are available for the next session.
        /// </summary>
        private void saveConfig()
        {
            Properties.Settings.Default.User = textBoxLogin.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.Database = cmbDatabase.Text;
            Properties.Settings.Default.Url = textBoxURL.Text;
            Properties.Settings.Default.ItemID = textBoxItemID.Text;
            Properties.Settings.Default.Destination = textBoxDestination.Text;
            Properties.Settings.Default.Threads = thCount.Value;

            Properties.Settings.Default.Save();
        }

		private void syncCheckoutBtn_Click(object sender, EventArgs e)
		{

            int numberOfThreads = (int)thCount.Value;
            string targetFolder = textBoxDestination.Text;

            //Strat the timer
            sw.Start();

            textBoxResult.Clear();
            
            string files = GetFiles();

			Item configuration = m_inn.newItem();
			configuration.loadAML(files);

			// get checkout manager
			CheckoutManager checkoutManager2 = new CheckoutManager(configuration);

			// Lock all items in the configuration (!File, !Vault, !Located)
			// NOTE: In this particular example this call could be skipped as the configuration the way it's built does NOT have any items that have to be locked.
			Item lockResult = checkoutManager2.Lock();
			if (lockResult.isError())
			{
				MessageBox.Show(lockResult.getErrorString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			progressBar.Value = 0;

			// Download files synchronously
            System.Collections.Hashtable downloadResults = checkoutManager2.DownloadFiles(targetFolder, numberOfThreads);

			ProcessResult(downloadResults, configuration);
		}

		string GetFiles()
		{
			string bstrFiles = "<AML>";

			Item pFiles = m_pDoc.getItemsByXPath("//Item[@type='File']");
			for (int i = 0; i < pFiles.getItemCount(); i++)
			{
				if (listBoxFiles.SelectedIndices.Contains(i))
				{
					Item pItem = pFiles.getItemByIndex(i);

					string bstrXml = pItem.node.OuterXml;
					bstrFiles += bstrXml;
				}
			}

			bstrFiles += "</AML>";
			return bstrFiles;
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			m_cmgr.DownloadFilesCancelAsync();
			cancelBtn.Enabled = false;
			asyncCheckoutBtn.Enabled = false;
			syncCheckoutBtn.Enabled = true;
			this.m_status = CheckoutManagerState.idle;
		}

		private void asyncCheckoutBtn_Click(object sender, EventArgs e)
		{
            textBoxResult.Clear();

            if (this.m_status == CheckoutManagerState.idle)
			{
				string files = GetFiles();

				// Create configuration
				Item configuration = m_inn.newItem();
				configuration.loadAML(files);

				// Create Aras.IOME.CheckoutManager
				m_cmgr = new CheckoutManager(configuration);

				// Lock all items in the configuration (!File, !Vault, !Located)
				Item lockResult = m_cmgr.Lock();

				if (lockResult.isError())
				{
					MessageBox.Show(lockResult.getErrorString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				int numberOfThreads = (int)thCount.Value;
				string targetFolder = textBoxDestination.Text;

				// Event handlers are attached to Aras.IOME.CheckoutManager events.
				m_cmgr.DownloadFileCompleted += new Aras.IOME.DownloadFileCompletedEventHandler(HandleDownloadFileCompleted);
				m_cmgr.DownloadFilesCompleted += new Aras.IOME.DownloadFilesCompletedEventHandler(HandleDownloadFilesCompleted);
				m_cmgr.DownloadFilesProgressChanged += new Aras.IOME.DownloadFilesProgressChangedEventHandler(HandleDownloadFileProgressChanged);

				this.m_failed_count = 0;
				progressBar.Value = 0;

				// Begin download files asynchronously
				m_cmgr.DownloadFilesAsync(targetFolder, numberOfThreads);

				// Toggle button state
				cancelBtn.Enabled = true;
				asyncCheckoutBtn.Text = "Pause";
				this.m_status = CheckoutManagerState.running;
			}
			else if (this.m_status == CheckoutManagerState.running)
			{
				m_cmgr.DownloadFilesPauseAsync();
				cancelBtn.Enabled = false;
				asyncCheckoutBtn.Text = "Resume";
				this.m_status = CheckoutManagerState.paused;
			}
			else if (this.m_status == CheckoutManagerState.paused)
			{
				m_cmgr.DownloadFilesResumeAsync();
				cancelBtn.Enabled = true;
				asyncCheckoutBtn.Text = "Pause";
				this.m_status = CheckoutManagerState.running;
			}
		}

		void GetDocuments()
		{
            string request = "";
            string searchType = cmbSearchType.Text;
            string itemID = textBoxItemID.Text;

            if (searchType == "Single" && !string.IsNullOrEmpty(itemID))
            {
                request = _requestCADsingle;
                request = string.Format(request, itemID);
            }
            else
            {
                request = _requestCADall;
            }

			Item pReq = this.m_inn.newItem("foo", "foo");

			pReq.loadAML(request);

			Item result = pReq.apply();
			if (result.isError()) 
			{ 
				MessageBox.Show(string.Format("ERROR: {0}", result.getErrorString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			BindingList<ListItem> ble = new BindingList<ListItem>();
			for (int i = 0; i < result.getItemCount(); i++)
			{
				Item pItem = result.getItemByIndex(i);
				string id = pItem.getProperty("id");
				string name = pItem.getProperty("item_number");

				ble.Add(new ListItem(name, id));
			}

			listBoxDocuments.DataSource = ble;
            syncCheckoutBtn.Enabled = true;
		}

		private void listBoxDocuments_SelectedIndexChanged(object sender, EventArgs e)
		{
            Cursor.Current = Cursors.WaitCursor; 
            
            string request = "";
            string resolution = cmbResolution.Text;
            string queryAction = cmbQueryAction.Text;

            ListItem li = (ListItem)listBoxDocuments.SelectedItem;
            string szDoc = li.id;

            switch (queryAction)
            {
                case "GetItemRepeatConfig":
                    request = _getItemRepeatConfig;
                    request = string.Format(request, szDoc);
                    break;
                case "PE_GetResolvedStructure":
                    request = _getResolvedStructure;
                    request = string.Format(request, szDoc, resolution);
                    break;
            }

			Item pReq = this.m_inn.newItem("foo", "foo");
			pReq.loadAML(request);

			this.m_pDoc = pReq.apply();
			if (m_pDoc.isError())
			{
				MessageBox.Show(string.Format("ERROR: {0}", m_pDoc.getErrorString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Item pFiles = m_pDoc.getItemsByXPath("//Item[@type='File']");

			listBoxFiles.DataSource = null;

			BindingList<ListItem> ble = new BindingList<ListItem>();

			for (int i = 0; i < pFiles.getItemCount(); i++)
			{
				Item pItem = pFiles.getItemByIndex(i);
				string id = pItem.getProperty("id");
				string name = pItem.getProperty("filename");

				ble.Add(new ListItem(name, id));
			}

			listBoxFiles.DataSource = ble;
            setupSearch(true);
		}

        /// <summary>
        /// Handle syncCheckout
        /// </summary>
		void ProcessResult(System.Collections.Hashtable downloadResults, Item configuration)
		{
			string szText = textBoxResult.Text;

			Item files = configuration.getItemsByXPath("//Item[@type='File']");

            //Stop the timer
            sw.Stop();

			if (files.getItemCount() == 0)
			{
				MessageBox.Show("Nothing checked out. Completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
                MessageBox.Show("Completed export to " + textBoxDestination.Text, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			// Process results
			for (int fileIndex = 0; fileIndex < files.getItemCount(); fileIndex++)
			{
				Item file = files.getItemByIndex(fileIndex);
				string strName = file.getProperty("filename");

				Aras.IOME.DownloadResult downloadFileResult = (Aras.IOME.DownloadResult)(downloadResults[file.getID()]);

				// If error happaned during file checkout
				if (downloadFileResult.Result.isError())
				{
					string strError = downloadFileResult.Result.getErrorString();
					szText = szText + "Exception: " + strName + "\r\n " + strError + "\r\n";
					continue;
				}

				// Check that file was checked out without Fault
				if (downloadFileResult.Result.isError())
				{
					string strError = downloadFileResult.Result.getErrorString();
					szText = szText + "Fault: " + strName + "\r\n " + strError + "\r\n";
					continue;
				}

				szText = szText + "Success: " + strName + "\r\n";
			}

            szText = szText + "Time taken: " + sw.Elapsed.TotalSeconds + "s - " + sw.Elapsed.TotalMinutes + "m " + "\r\n";
			textBoxResult.Text = szText;
		}

        /// <summary>
        /// Handle asyncCheckout
        /// </summary>
		private void HandleDownloadFileCompleted(object sender, DownloadFileCompletedEventArgs e)
		{
			// Exception was thrown during invokation, result is unavailable
			if (e.Error != null)
			{
				string szError = "DownloadFilesProgressChanged: " + e.Error.ToString() + "\r\n\r\n";
				textBoxResult.Text = szError;
				m_failed_count++;
				return;
			}

			string fileId = e.UserState.ToString();

			// Operation was cancelled, result is unavailable
			if (e.Cancelled)
			{
				return;
			}

			Item file = e.Result;
			if (file.isError())
			{
				string szError = "Fault: File '" + fileId + "'\r\n " + file.getErrorString() + "\r\n";
				textBoxResult.Text = szError;
				return;
			}

			string name = file.getProperty("filename");

			string resultText = textBoxResult.Text;
			resultText = resultText + "Success: " + name + "\r\n";
			textBoxResult.Text = resultText;
		}

        /// <summary>
        /// Handle syncCheckout
        /// </summary>
		private void HandleDownloadFilesCompleted(object sender, DownloadFilesCompletedEventArgs e)
		{
			// Toggle button state
			cancelBtn.Enabled = false;
			asyncCheckoutBtn.Text = "Async Download";
			this.m_status = CheckoutManagerState.idle;

			// If download was cancelled then e->Cancelled is true
			if (e.Cancelled)
			{
				progressBar.Value = 0;
				MessageBox.Show("Cancelled.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// If general Exception(which is not related to File) happenned during download
			if (e.Error != null)
			{
				string error = "DownloadFilesProgressChanged: " + e.Error.ToString();
				MessageBox.Show(error, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        /// <summary>
        /// Handle syncCheckout
        /// </summary>
		// Implementation of DownloadFilesProgressChangedHandler declared in CheckoutManagerEventSink.h
		public void HandleDownloadFileProgressChanged(object sender, DownloadFilesProgressChangedEventArgs e)
		{
			// Change progress bar state
			progressBar.Value = e.ProgressPercentage;
		}

        private void cmbDatabase_TextChanged(object sender, EventArgs e)
        {
            connLogout();
        }

        private void btnRunSearch_Click(object sender, EventArgs e)
        {
            GetDocuments();
            saveConfig();

            setupSearch(true);
        }

        private void cmbSearchType_TextChanged(object sender, EventArgs e)
        {
            setupSearch(false);
        }

        private void cmbQueryAction_TextChanged(object sender, EventArgs e)
        {
            setupSearch(false);
        }

        private void cmbResolution_TextChanged(object sender, EventArgs e)
        {
            setupSearch(false);
        }

        private void setupSearch(bool display)
        {
            syncCheckoutBtn.Enabled = display;
            asyncCheckoutBtn.Enabled = display;
            btnSelectAllFiles.Enabled = display;
            listBoxDocuments.Enabled = display;
            listBoxFiles.Enabled = display;
            textBoxResult.Enabled = display;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxFiles.Items.Count; i++)
            {
                listBoxFiles.SetSelected(i, true);
            }
        }

        private void btnDeselectAllFiles_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxFiles.Items.Count; i++)
            {
                listBoxFiles.SetSelected(i, false);
            }
        }
	}

	class ListItem
	{
		private string listName;
		private string listId;

		public ListItem(string itemName, string itemId)
		{
			listName = itemName;
			listId = itemId;
		}

		public override string ToString()
		{
			return listName;
		}

		public string id
		{
			get { return listId; }
		}

		public string name
		{
			get { return listName; }
		}
	}

    public class listResolution
    {
        public string Name { get; set; }
        public listResolution(string _name)
        {
            Name = _name;
        }
    }

    public class listQuaryAction
    {
        public string Name { get; set; }
        public listQuaryAction(string _name)
        {
            Name = _name;
        }
    }

    public class listSearchType
    {
        public string Name { get; set; }
        public listSearchType(string _name)
        {
            Name = _name;
        }
    }
}
