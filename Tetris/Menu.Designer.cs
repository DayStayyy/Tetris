namespace Tetris
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.PlayButton = new System.Windows.Forms.Button();
            this.Option = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.Tuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayButton.BackgroundImage")));
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayButton.Location = new System.Drawing.Point(318, 113);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(77, 71);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "\r\nPLAY";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Option
            // 
            this.Option.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Option.BackgroundImage")));
            this.Option.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Option.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Option.Location = new System.Drawing.Point(21, 265);
            this.Option.Name = "Option";
            this.Option.Size = new System.Drawing.Size(55, 75);
            this.Option.TabIndex = 1;
            this.Option.Text = "OPTION";
            this.Option.UseVisualStyleBackColor = true;
            this.Option.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Quit
            // 
            this.Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Quit.BackgroundImage")));
            this.Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Quit.Location = new System.Drawing.Point(568, 338);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(93, 32);
            this.Quit.TabIndex = 2;
            this.Quit.Text = "QUIT";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Tuto
            // 
            this.Tuto.BackColor = System.Drawing.Color.Transparent;
            this.Tuto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Tuto.BackgroundImage")));
            this.Tuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tuto.Location = new System.Drawing.Point(203, 281);
            this.Tuto.Name = "Tuto";
            this.Tuto.Size = new System.Drawing.Size(99, 31);
            this.Tuto.TabIndex = 3;
            this.Tuto.Text = "Tuto";
            this.Tuto.UseVisualStyleBackColor = false;
            this.Tuto.Click += new System.EventHandler(this.Tuto_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 433);
            this.Controls.Add(this.Tuto);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Option);
            this.Controls.Add(this.PlayButton);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button Option;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Tuto;
    }
}

