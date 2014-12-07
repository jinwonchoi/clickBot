using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ControlsNavigationBar = new Elegant.Ui.NavigationBar();
            this.ProductPageToggleButton = new Elegant.Ui.ToggleButton();
            this.UserPageToggleButton = new Elegant.Ui.ToggleButton();
            this.PurchasePageToggleButton = new Elegant.Ui.ToggleButton();
            this.TaskPageToggleButton = new Elegant.Ui.ToggleButton();
            this.ServerInfoToggleButton = new Elegant.Ui.ToggleButton();
            this.SiteLoginInfoToggleButton = new Elegant.Ui.ToggleButton();
            this.IpInfoToggleButton = new Elegant.Ui.ToggleButton();
            this.aquaSkin1 = new SkinSoft.AquaSkin.AquaSkin(this.components);
            this.ControlsSamplePageContainer = new Elegant.Ui.Samples.ControlsSample.ControlsSamplePageContainer();
            this.ControlsNavigationBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlsNavigationBar
            // 
            this.ControlsNavigationBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.ControlsNavigationBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ControlsNavigationBar.Controls.Add(this.ProductPageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.UserPageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.PurchasePageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.TaskPageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.ServerInfoToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.SiteLoginInfoToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.IpInfoToggleButton);
            this.ControlsNavigationBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlsNavigationBar.Id = "cba39524-c60d-4bb0-8dcf-15df5e41b782";
            this.ControlsNavigationBar.Location = new System.Drawing.Point(0, 0);
            this.ControlsNavigationBar.Name = "ControlsNavigationBar";
            this.ControlsNavigationBar.Size = new System.Drawing.Size(173, 730);
            this.ControlsNavigationBar.TabIndex = 0;
            this.ControlsNavigationBar.Text = "ControlsNavigationBar";
            this.ControlsNavigationBar.UseTabToNavigate = false;
            this.ControlsNavigationBar.WrapNavigation = false;
            // 
            // ProductPageToggleButton
            // 
            this.ProductPageToggleButton.Id = "59ba1d57-5ab5-4320-bc65-9f7a5e4a0049";
            this.ProductPageToggleButton.Location = new System.Drawing.Point(2, 2);
            this.ProductPageToggleButton.Name = "ProductPageToggleButton";
            this.ProductPageToggleButton.Pressed = true;
            this.ProductPageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.ProductPageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.ProductPageToggleButton.TabIndex = 18;
            this.ProductPageToggleButton.Text = "惑前包府";
            this.ProductPageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProductPageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // UserPageToggleButton
            // 
            this.UserPageToggleButton.Id = "f0a9456e-c5a3-4ed0-a206-a0ffaa7e8d76";
            this.UserPageToggleButton.Location = new System.Drawing.Point(2, 28);
            this.UserPageToggleButton.Name = "UserPageToggleButton";
            this.UserPageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.UserPageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.UserPageToggleButton.TabIndex = 2;
            this.UserPageToggleButton.Text = "荤侩磊包府";
            this.UserPageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserPageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // PurchasePageToggleButton
            // 
            this.PurchasePageToggleButton.Id = "fc9a67fb-f034-4454-9cf3-f4a21b7d8323";
            this.PurchasePageToggleButton.Location = new System.Drawing.Point(2, 54);
            this.PurchasePageToggleButton.Name = "PurchasePageToggleButton";
            this.PurchasePageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.PurchasePageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.PurchasePageToggleButton.TabIndex = 3;
            this.PurchasePageToggleButton.Text = "惑前备概包府";
            this.PurchasePageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PurchasePageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // TaskPageToggleButton
            // 
            this.TaskPageToggleButton.Id = "d7b589f7-bbac-440c-a65b-4ab0b5e90545";
            this.TaskPageToggleButton.Location = new System.Drawing.Point(2, 80);
            this.TaskPageToggleButton.Name = "TaskPageToggleButton";
            this.TaskPageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.TaskPageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.TaskPageToggleButton.TabIndex = 4;
            this.TaskPageToggleButton.Text = "绊按备概格废累诀包府";
            this.TaskPageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaskPageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // ServerInfoToggleButton
            // 
            this.ServerInfoToggleButton.Id = "bbafe857-bbc0-4d73-967e-c7c8ce63e182";
            this.ServerInfoToggleButton.Location = new System.Drawing.Point(2, 106);
            this.ServerInfoToggleButton.Name = "ServerInfoToggleButton";
            this.ServerInfoToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.ServerInfoToggleButton.Size = new System.Drawing.Size(169, 24);
            this.ServerInfoToggleButton.TabIndex = 5;
            this.ServerInfoToggleButton.Text = "厘厚包府";
            this.ServerInfoToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ServerInfoToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // SiteLoginInfoToggleButton
            // 
            this.SiteLoginInfoToggleButton.Id = "4a05cf36-2371-456c-be2d-f4f9a2328171";
            this.SiteLoginInfoToggleButton.Location = new System.Drawing.Point(2, 132);
            this.SiteLoginInfoToggleButton.Name = "SiteLoginInfoToggleButton";
            this.SiteLoginInfoToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.SiteLoginInfoToggleButton.Size = new System.Drawing.Size(169, 24);
            this.SiteLoginInfoToggleButton.TabIndex = 6;
            this.SiteLoginInfoToggleButton.Text = "荤捞飘拌沥沥焊包府";
            this.SiteLoginInfoToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiteLoginInfoToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // IpInfoToggleButton
            // 
            this.IpInfoToggleButton.Id = "710cc261-1357-45ff-9dcc-49a722370540";
            this.IpInfoToggleButton.Location = new System.Drawing.Point(2, 158);
            this.IpInfoToggleButton.Name = "IpInfoToggleButton";
            this.IpInfoToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.IpInfoToggleButton.Size = new System.Drawing.Size(169, 24);
            this.IpInfoToggleButton.TabIndex = 7;
            this.IpInfoToggleButton.Text = "立加IP包府";
            this.IpInfoToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IpInfoToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // aquaSkin1
            // 
            this.aquaSkin1.AquaStyle = SkinSoft.AquaSkin.AquaStyle.Panther;
            this.aquaSkin1.License = ((SkinSoft.AquaSkin.Licensing.AquaSkinLicense)(resources.GetObject("aquaSkin1.License")));
            this.aquaSkin1.TargetControls = SkinSoft.AquaSkin.TargetControls.Forms;
            // 
            // ControlsSamplePageContainer
            // 
            this.ControlsSamplePageContainer.ControlsSamplePage = null;
            this.ControlsSamplePageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsSamplePageContainer.Location = new System.Drawing.Point(173, 0);
            this.ControlsSamplePageContainer.Name = "ControlsSamplePageContainer";
            this.ControlsSamplePageContainer.Size = new System.Drawing.Size(835, 730);
            this.ControlsSamplePageContainer.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ControlsSamplePageContainer);
            this.Controls.Add(this.ControlsNavigationBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "clickBot 付纳泼 辑厚胶包府";
            this.ControlsNavigationBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NavigationBar ControlsNavigationBar;
        private ControlsSamplePageContainer ControlsSamplePageContainer;
        private SkinSoft.AquaSkin.AquaSkin aquaSkin1;
        private ToggleButton UserPageToggleButton;
        private ToggleButton ProductPageToggleButton;
        private ToggleButton PurchasePageToggleButton;
        private ToggleButton TaskPageToggleButton;
        private ToggleButton ServerInfoToggleButton;
        private ToggleButton SiteLoginInfoToggleButton;
        private ToggleButton IpInfoToggleButton;
    }
}

