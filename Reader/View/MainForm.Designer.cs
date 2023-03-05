namespace Reader.View
{
    partial class MainForm
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
            ConnectionComContainer = new GroupBox();
            ConnectionComId = new ComboBox();
            ConnectionComBusAddress = new ComboBox();
            ConnectionComComNumber = new ComboBox();
            ConnectionComBaudRate = new ComboBox();
            ConnectionComConnect = new Button();
            ConnectionComDisconnect = new Button();
            ConnectionIpContainer = new GroupBox();
            ConnectionIpId = new ComboBox();
            ConnectionIpProtocol = new ComboBox();
            ConnectionIpHostName = new TextBox();
            ConnectionIpSocketPort = new TextBox();
            ConnectionIpConnect = new Button();
            ConnectionIpDisconnect = new Button();
            SettingHwContainer = new GroupBox();
            SettingHwPower = new ComboBox();
            SettingHwTagFilter = new ComboBox();
            SettingHwBuzzer = new ComboBox();
            SettingHwAdvanced = new Button();
            SettingSwContainer = new GroupBox();
            SettingSwActivator = new ComboBox();
            SettingSwTagFilter = new ComboBox();
            SettingSwRssi1 = new ComboBox();
            SettingSwRssi2 = new ComboBox();
            SettingSwSound = new CheckBox();
            SettingSwMysql = new CheckBox();
            ReadContainer = new GroupBox();
            ReadStart = new Button();
            ReadStop = new Button();
            ReadReset = new Button();
            LogDeviceContainer = new GroupBox();
            LogDeviceListView = new ListView();
            LogDeviceListViewColumnNull = new ColumnHeader();
            LogDeviceListViewColumnId = new ColumnHeader();
            LogDeviceListViewColumnTime = new ColumnHeader();
            LogDeviceListViewColumnValue = new ColumnHeader();
            LogTransponderContainer = new GroupBox();
            LogTransponderListView = new ListView();
            LogTransponderListViewColumnNull = new ColumnHeader();
            LogTransponderListViewColumnId = new ColumnHeader();
            LogTransponderListViewColumnActivator = new ColumnHeader();
            LogTransponderListViewColumnNumber = new ColumnHeader();
            LogTransponderListViewColumnValue = new ColumnHeader();
            LogTransponderListViewColumnRssi1 = new ColumnHeader();
            LogTransponderListViewColumnRssi2 = new ColumnHeader();
            LogTransponderListViewColumnBattery = new ColumnHeader();
            ConnectionComContainer.SuspendLayout();
            ConnectionIpContainer.SuspendLayout();
            SettingHwContainer.SuspendLayout();
            SettingSwContainer.SuspendLayout();
            ReadContainer.SuspendLayout();
            LogDeviceContainer.SuspendLayout();
            LogTransponderContainer.SuspendLayout();
            SuspendLayout();
            // 
            // ConnectionComContainer
            // 
            ConnectionComContainer.Controls.Add(ConnectionComId);
            ConnectionComContainer.Controls.Add(ConnectionComBusAddress);
            ConnectionComContainer.Controls.Add(ConnectionComComNumber);
            ConnectionComContainer.Controls.Add(ConnectionComBaudRate);
            ConnectionComContainer.Controls.Add(ConnectionComConnect);
            ConnectionComContainer.Controls.Add(ConnectionComDisconnect);
            ConnectionComContainer.Location = new Point(8, 6);
            ConnectionComContainer.Name = "ConnectionComContainer";
            ConnectionComContainer.Size = new Size(480, 52);
            ConnectionComContainer.TabIndex = 0;
            ConnectionComContainer.TabStop = false;
            // 
            // ConnectionComId
            // 
            ConnectionComId.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionComId.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionComId.Location = new Point(10, 18);
            ConnectionComId.Name = "ConnectionComId";
            ConnectionComId.Size = new Size(70, 24);
            ConnectionComId.TabIndex = 1;
            ConnectionComId.TabStop = false;
            ConnectionComId.DrawItem += ConnectionComId_DrawItem;
            // 
            // ConnectionComBusAddress
            // 
            ConnectionComBusAddress.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionComBusAddress.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionComBusAddress.Location = new Point(86, 18);
            ConnectionComBusAddress.Name = "ConnectionComBusAddress";
            ConnectionComBusAddress.Size = new Size(70, 24);
            ConnectionComBusAddress.TabIndex = 2;
            ConnectionComBusAddress.TabStop = false;
            ConnectionComBusAddress.DrawItem += ConnectionComBusAddress_DrawItem;
            // 
            // ConnectionComComNumber
            // 
            ConnectionComComNumber.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionComComNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionComComNumber.Location = new Point(162, 18);
            ConnectionComComNumber.Name = "ConnectionComComNumber";
            ConnectionComComNumber.Size = new Size(70, 24);
            ConnectionComComNumber.TabIndex = 3;
            ConnectionComComNumber.TabStop = false;
            ConnectionComComNumber.DrawItem += ConnectionComComNumber_DrawItem;
            // 
            // ConnectionComBaudRate
            // 
            ConnectionComBaudRate.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionComBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionComBaudRate.Location = new Point(238, 18);
            ConnectionComBaudRate.Name = "ConnectionComBaudRate";
            ConnectionComBaudRate.Size = new Size(70, 24);
            ConnectionComBaudRate.TabIndex = 4;
            ConnectionComBaudRate.TabStop = false;
            ConnectionComBaudRate.DrawItem += ConnectionComBaudRate_DrawItem;
            // 
            // ConnectionComConnect
            // 
            ConnectionComConnect.Location = new Point(314, 17);
            ConnectionComConnect.Name = "ConnectionComConnect";
            ConnectionComConnect.Size = new Size(75, 26);
            ConnectionComConnect.TabIndex = 5;
            ConnectionComConnect.TabStop = false;
            ConnectionComConnect.UseVisualStyleBackColor = true;
            // 
            // ConnectionComDisconnect
            // 
            ConnectionComDisconnect.Location = new Point(395, 17);
            ConnectionComDisconnect.Name = "ConnectionComDisconnect";
            ConnectionComDisconnect.Size = new Size(75, 26);
            ConnectionComDisconnect.TabIndex = 6;
            ConnectionComDisconnect.TabStop = false;
            ConnectionComDisconnect.UseVisualStyleBackColor = true;
            // 
            // ConnectionIpContainer
            // 
            ConnectionIpContainer.Controls.Add(ConnectionIpId);
            ConnectionIpContainer.Controls.Add(ConnectionIpProtocol);
            ConnectionIpContainer.Controls.Add(ConnectionIpHostName);
            ConnectionIpContainer.Controls.Add(ConnectionIpSocketPort);
            ConnectionIpContainer.Controls.Add(ConnectionIpConnect);
            ConnectionIpContainer.Controls.Add(ConnectionIpDisconnect);
            ConnectionIpContainer.Location = new Point(8, 64);
            ConnectionIpContainer.Name = "ConnectionIpContainer";
            ConnectionIpContainer.Size = new Size(480, 52);
            ConnectionIpContainer.TabIndex = 7;
            ConnectionIpContainer.TabStop = false;
            // 
            // ConnectionIpId
            // 
            ConnectionIpId.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionIpId.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionIpId.Location = new Point(10, 18);
            ConnectionIpId.Name = "ConnectionIpId";
            ConnectionIpId.Size = new Size(70, 24);
            ConnectionIpId.TabIndex = 8;
            ConnectionIpId.TabStop = false;
            ConnectionIpId.DrawItem += ConnectionIpId_DrawItem;
            // 
            // ConnectionIpProtocol
            // 
            ConnectionIpProtocol.DrawMode = DrawMode.OwnerDrawFixed;
            ConnectionIpProtocol.DropDownStyle = ComboBoxStyle.DropDownList;
            ConnectionIpProtocol.Location = new Point(86, 18);
            ConnectionIpProtocol.Name = "ConnectionIpProtocol";
            ConnectionIpProtocol.Size = new Size(70, 24);
            ConnectionIpProtocol.TabIndex = 9;
            ConnectionIpProtocol.TabStop = false;
            ConnectionIpProtocol.DrawItem += ConnectionIpProtocol_DrawItem;
            // 
            // ConnectionIpHostName
            // 
            ConnectionIpHostName.Location = new Point(162, 18);
            ConnectionIpHostName.MaxLength = 15;
            ConnectionIpHostName.Name = "ConnectionIpHostName";
            ConnectionIpHostName.Size = new Size(95, 23);
            ConnectionIpHostName.TabIndex = 10;
            ConnectionIpHostName.TabStop = false;
            ConnectionIpHostName.TextAlign = HorizontalAlignment.Center;
            // 
            // ConnectionIpSocketPort
            // 
            ConnectionIpSocketPort.Location = new Point(263, 18);
            ConnectionIpSocketPort.MaxLength = 5;
            ConnectionIpSocketPort.Name = "ConnectionIpSocketPort";
            ConnectionIpSocketPort.Size = new Size(45, 23);
            ConnectionIpSocketPort.TabIndex = 11;
            ConnectionIpSocketPort.TabStop = false;
            ConnectionIpSocketPort.TextAlign = HorizontalAlignment.Center;
            // 
            // ConnectionIpConnect
            // 
            ConnectionIpConnect.Location = new Point(314, 17);
            ConnectionIpConnect.Name = "ConnectionIpConnect";
            ConnectionIpConnect.Size = new Size(75, 26);
            ConnectionIpConnect.TabIndex = 12;
            ConnectionIpConnect.TabStop = false;
            ConnectionIpConnect.UseVisualStyleBackColor = true;
            // 
            // ConnectionIpDisconnect
            // 
            ConnectionIpDisconnect.Location = new Point(395, 17);
            ConnectionIpDisconnect.Name = "ConnectionIpDisconnect";
            ConnectionIpDisconnect.Size = new Size(75, 26);
            ConnectionIpDisconnect.TabIndex = 13;
            ConnectionIpDisconnect.TabStop = false;
            ConnectionIpDisconnect.UseVisualStyleBackColor = true;
            // 
            // SettingHwContainer
            // 
            SettingHwContainer.Controls.Add(SettingHwPower);
            SettingHwContainer.Controls.Add(SettingHwTagFilter);
            SettingHwContainer.Controls.Add(SettingHwBuzzer);
            SettingHwContainer.Controls.Add(SettingHwAdvanced);
            SettingHwContainer.Location = new Point(8, 122);
            SettingHwContainer.Name = "SettingHwContainer";
            SettingHwContainer.Size = new Size(480, 52);
            SettingHwContainer.TabIndex = 14;
            SettingHwContainer.TabStop = false;
            // 
            // SettingHwPower
            // 
            SettingHwPower.DrawMode = DrawMode.OwnerDrawFixed;
            SettingHwPower.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingHwPower.FormattingEnabled = true;
            SettingHwPower.Location = new Point(10, 18);
            SettingHwPower.Name = "SettingHwPower";
            SettingHwPower.Size = new Size(70, 24);
            SettingHwPower.TabIndex = 15;
            SettingHwPower.TabStop = false;
            SettingHwPower.DrawItem += SettingHwPower_DrawItem;
            // 
            // SettingHwTagFilter
            // 
            SettingHwTagFilter.DrawMode = DrawMode.OwnerDrawFixed;
            SettingHwTagFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingHwTagFilter.FormattingEnabled = true;
            SettingHwTagFilter.Location = new Point(86, 18);
            SettingHwTagFilter.Name = "SettingHwTagFilter";
            SettingHwTagFilter.Size = new Size(70, 24);
            SettingHwTagFilter.TabIndex = 16;
            SettingHwTagFilter.TabStop = false;
            SettingHwTagFilter.DrawItem += SettingHwTagFilter_DrawItem;
            // 
            // SettingHwBuzzer
            // 
            SettingHwBuzzer.DrawMode = DrawMode.OwnerDrawFixed;
            SettingHwBuzzer.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingHwBuzzer.FormattingEnabled = true;
            SettingHwBuzzer.Location = new Point(162, 18);
            SettingHwBuzzer.Name = "SettingHwBuzzer";
            SettingHwBuzzer.Size = new Size(70, 24);
            SettingHwBuzzer.TabIndex = 17;
            SettingHwBuzzer.TabStop = false;
            SettingHwBuzzer.DrawItem += SettingHwBuzzer_DrawItem;
            // 
            // SettingHwAdvanced
            // 
            SettingHwAdvanced.Location = new Point(238, 17);
            SettingHwAdvanced.Name = "SettingHwAdvanced";
            SettingHwAdvanced.Size = new Size(232, 26);
            SettingHwAdvanced.TabIndex = 18;
            SettingHwAdvanced.TabStop = false;
            SettingHwAdvanced.UseVisualStyleBackColor = true;
            // 
            // SettingSwContainer
            // 
            SettingSwContainer.Controls.Add(SettingSwActivator);
            SettingSwContainer.Controls.Add(SettingSwTagFilter);
            SettingSwContainer.Controls.Add(SettingSwRssi1);
            SettingSwContainer.Controls.Add(SettingSwRssi2);
            SettingSwContainer.Controls.Add(SettingSwSound);
            SettingSwContainer.Controls.Add(SettingSwMysql);
            SettingSwContainer.Location = new Point(8, 180);
            SettingSwContainer.Name = "SettingSwContainer";
            SettingSwContainer.Size = new Size(480, 52);
            SettingSwContainer.TabIndex = 19;
            SettingSwContainer.TabStop = false;
            // 
            // SettingSwActivator
            // 
            SettingSwActivator.DrawMode = DrawMode.OwnerDrawFixed;
            SettingSwActivator.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingSwActivator.FormattingEnabled = true;
            SettingSwActivator.Location = new Point(10, 18);
            SettingSwActivator.Name = "SettingSwActivator";
            SettingSwActivator.Size = new Size(70, 24);
            SettingSwActivator.TabIndex = 20;
            SettingSwActivator.TabStop = false;
            SettingSwActivator.DrawItem += SettingSwActivator_DrawItem;
            // 
            // SettingSwTagFilter
            // 
            SettingSwTagFilter.DrawMode = DrawMode.OwnerDrawFixed;
            SettingSwTagFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingSwTagFilter.FormattingEnabled = true;
            SettingSwTagFilter.Location = new Point(86, 18);
            SettingSwTagFilter.Name = "SettingSwTagFilter";
            SettingSwTagFilter.Size = new Size(70, 24);
            SettingSwTagFilter.TabIndex = 21;
            SettingSwTagFilter.TabStop = false;
            SettingSwTagFilter.DrawItem += SettingSwTagFilter_DrawItem;
            // 
            // SettingSwRssi1
            // 
            SettingSwRssi1.DrawMode = DrawMode.OwnerDrawFixed;
            SettingSwRssi1.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingSwRssi1.FormattingEnabled = true;
            SettingSwRssi1.Location = new Point(162, 18);
            SettingSwRssi1.Name = "SettingSwRssi1";
            SettingSwRssi1.Size = new Size(70, 24);
            SettingSwRssi1.TabIndex = 22;
            SettingSwRssi1.TabStop = false;
            SettingSwRssi1.DrawItem += SettingSwRssi1_DrawItem;
            // 
            // SettingSwRssi2
            // 
            SettingSwRssi2.DrawMode = DrawMode.OwnerDrawFixed;
            SettingSwRssi2.DropDownStyle = ComboBoxStyle.DropDownList;
            SettingSwRssi2.FormattingEnabled = true;
            SettingSwRssi2.Location = new Point(238, 18);
            SettingSwRssi2.Name = "SettingSwRssi2";
            SettingSwRssi2.Size = new Size(70, 24);
            SettingSwRssi2.TabIndex = 23;
            SettingSwRssi2.TabStop = false;
            SettingSwRssi2.DrawItem += SettingSwRssi2_DrawItem;
            // 
            // SettingSwSound
            // 
            SettingSwSound.Appearance = Appearance.Button;
            SettingSwSound.Location = new Point(314, 17);
            SettingSwSound.Name = "SettingSwSound";
            SettingSwSound.Size = new Size(75, 26);
            SettingSwSound.TabIndex = 24;
            SettingSwSound.TabStop = false;
            SettingSwSound.TextAlign = ContentAlignment.MiddleCenter;
            SettingSwSound.UseVisualStyleBackColor = true;
            SettingSwSound.Paint += SettingSwSound_Paint;
            // 
            // SettingSwMysql
            // 
            SettingSwMysql.Appearance = Appearance.Button;
            SettingSwMysql.Location = new Point(395, 17);
            SettingSwMysql.Name = "SettingSwMysql";
            SettingSwMysql.Size = new Size(75, 26);
            SettingSwMysql.TabIndex = 25;
            SettingSwMysql.TabStop = false;
            SettingSwMysql.TextAlign = ContentAlignment.MiddleCenter;
            SettingSwMysql.UseVisualStyleBackColor = true;
            SettingSwMysql.Paint += SettingSwMysql_Paint;
            // 
            // ReadContainer
            // 
            ReadContainer.Controls.Add(ReadStart);
            ReadContainer.Controls.Add(ReadStop);
            ReadContainer.Controls.Add(ReadReset);
            ReadContainer.Location = new Point(8, 238);
            ReadContainer.Name = "ReadContainer";
            ReadContainer.Size = new Size(480, 51);
            ReadContainer.TabIndex = 26;
            ReadContainer.TabStop = false;
            // 
            // ReadStart
            // 
            ReadStart.Location = new Point(10, 17);
            ReadStart.Name = "ReadStart";
            ReadStart.Size = new Size(150, 25);
            ReadStart.TabIndex = 27;
            ReadStart.TabStop = false;
            ReadStart.UseVisualStyleBackColor = true;
            // 
            // ReadStop
            // 
            ReadStop.Location = new Point(166, 17);
            ReadStop.Name = "ReadStop";
            ReadStop.Size = new Size(150, 25);
            ReadStop.TabIndex = 28;
            ReadStop.TabStop = false;
            ReadStop.UseVisualStyleBackColor = true;
            // 
            // ReadReset
            // 
            ReadReset.Location = new Point(322, 17);
            ReadReset.Name = "ReadReset";
            ReadReset.Size = new Size(148, 25);
            ReadReset.TabIndex = 29;
            ReadReset.TabStop = false;
            ReadReset.UseVisualStyleBackColor = true;
            // 
            // LogDeviceContainer
            // 
            LogDeviceContainer.Controls.Add(LogDeviceListView);
            LogDeviceContainer.Location = new Point(8, 295);
            LogDeviceContainer.Name = "LogDeviceContainer";
            LogDeviceContainer.Size = new Size(480, 251);
            LogDeviceContainer.TabIndex = 30;
            LogDeviceContainer.TabStop = false;
            // 
            // LogDeviceListView
            // 
            LogDeviceListView.Columns.AddRange(new ColumnHeader[] { LogDeviceListViewColumnNull, LogDeviceListViewColumnId, LogDeviceListViewColumnTime, LogDeviceListViewColumnValue });
            LogDeviceListView.FullRowSelect = true;
            LogDeviceListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            LogDeviceListView.Location = new Point(10, 18);
            LogDeviceListView.Name = "LogDeviceListView";
            LogDeviceListView.ShowItemToolTips = true;
            LogDeviceListView.Size = new Size(460, 223);
            LogDeviceListView.TabIndex = 31;
            LogDeviceListView.TabStop = false;
            LogDeviceListView.UseCompatibleStateImageBehavior = false;
            LogDeviceListView.View = System.Windows.Forms.View.Details;
            LogDeviceListView.ColumnWidthChanged += LogDeviceListView_ColumnWidthChanged;
            // 
            // LogDeviceListViewColumnId
            // 
            LogDeviceListViewColumnId.TextAlign = HorizontalAlignment.Center;
            // 
            // LogDeviceListViewColumnTime
            // 
            LogDeviceListViewColumnTime.TextAlign = HorizontalAlignment.Center;
            // 
            // LogDeviceListViewColumnValue
            // 
            LogDeviceListViewColumnValue.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderContainer
            // 
            LogTransponderContainer.Controls.Add(LogTransponderListView);
            LogTransponderContainer.Location = new Point(494, 6);
            LogTransponderContainer.Name = "LogTransponderContainer";
            LogTransponderContainer.Size = new Size(561, 540);
            LogTransponderContainer.TabIndex = 32;
            LogTransponderContainer.TabStop = false;
            // 
            // LogTransponderListView
            // 
            LogTransponderListView.Columns.AddRange(new ColumnHeader[] { LogTransponderListViewColumnNull, LogTransponderListViewColumnId, LogTransponderListViewColumnActivator, LogTransponderListViewColumnNumber, LogTransponderListViewColumnValue, LogTransponderListViewColumnRssi1, LogTransponderListViewColumnRssi2, LogTransponderListViewColumnBattery });
            LogTransponderListView.FullRowSelect = true;
            LogTransponderListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            LogTransponderListView.Location = new Point(10, 18);
            LogTransponderListView.Name = "LogTransponderListView";
            LogTransponderListView.Size = new Size(541, 512);
            LogTransponderListView.TabIndex = 33;
            LogTransponderListView.TabStop = false;
            LogTransponderListView.UseCompatibleStateImageBehavior = false;
            LogTransponderListView.View = System.Windows.Forms.View.Details;
            LogTransponderListView.ColumnWidthChanged += LogTransponderListView_ColumnWidthChanged;
            // 
            // LogTransponderListViewColumnId
            // 
            LogTransponderListViewColumnId.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnActivator
            // 
            LogTransponderListViewColumnActivator.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnNumber
            // 
            LogTransponderListViewColumnNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnValue
            // 
            LogTransponderListViewColumnValue.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnRssi1
            // 
            LogTransponderListViewColumnRssi1.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnRssi2
            // 
            LogTransponderListViewColumnRssi2.TextAlign = HorizontalAlignment.Center;
            // 
            // LogTransponderListViewColumnBattery
            // 
            LogTransponderListViewColumnBattery.TextAlign = HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 554);
            Controls.Add(ConnectionComContainer);
            Controls.Add(ConnectionIpContainer);
            Controls.Add(SettingHwContainer);
            Controls.Add(SettingSwContainer);
            Controls.Add(ReadContainer);
            Controls.Add(LogDeviceContainer);
            Controls.Add(LogTransponderContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            ConnectionComContainer.ResumeLayout(false);
            ConnectionIpContainer.ResumeLayout(false);
            ConnectionIpContainer.PerformLayout();
            SettingHwContainer.ResumeLayout(false);
            SettingSwContainer.ResumeLayout(false);
            ReadContainer.ResumeLayout(false);
            LogDeviceContainer.ResumeLayout(false);
            LogTransponderContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ConnectionComContainer;
        private ComboBox ConnectionComId;
        private ComboBox ConnectionComBusAddress;
        private ComboBox ConnectionComComNumber;
        private ComboBox ConnectionComBaudRate;
        private Button ConnectionComConnect;
        private Button ConnectionComDisconnect;
        private GroupBox ConnectionIpContainer;
        private ComboBox ConnectionIpId;
        private ComboBox ConnectionIpProtocol;
        private TextBox ConnectionIpHostName;
        private TextBox ConnectionIpSocketPort;
        private Button ConnectionIpConnect;
        private Button ConnectionIpDisconnect;
        private GroupBox SettingHwContainer;
        public ComboBox SettingHwPower;
        public ComboBox SettingHwTagFilter;
        public ComboBox SettingHwBuzzer;
        private Button SettingHwAdvanced;
        private GroupBox SettingSwContainer;
        private ComboBox SettingSwActivator;
        private ComboBox SettingSwTagFilter;
        private ComboBox SettingSwRssi1;
        private ComboBox SettingSwRssi2;
        private CheckBox SettingSwSound;
        private CheckBox SettingSwMysql;
        private GroupBox ReadContainer;
        private Button ReadStart;
        private Button ReadStop;
        private Button ReadReset;
        private GroupBox LogDeviceContainer;
        private ListView LogDeviceListView;
        private ColumnHeader LogDeviceListViewColumnNull;
        private ColumnHeader LogDeviceListViewColumnId;
        private ColumnHeader LogDeviceListViewColumnTime;
        private ColumnHeader LogDeviceListViewColumnValue;
        private GroupBox LogTransponderContainer;
        private ListView LogTransponderListView;
        private ColumnHeader LogTransponderListViewColumnNull;
        private ColumnHeader LogTransponderListViewColumnId;
        private ColumnHeader LogTransponderListViewColumnActivator;
        private ColumnHeader LogTransponderListViewColumnNumber;
        private ColumnHeader LogTransponderListViewColumnValue;
        private ColumnHeader LogTransponderListViewColumnRssi1;
        private ColumnHeader LogTransponderListViewColumnRssi2;
        private ColumnHeader LogTransponderListViewColumnBattery;
    }
}