namespace Solution
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oscarEnter = new System.Windows.Forms.TextBox();
            this.userRequest = new System.Windows.Forms.TextBox();
            this.prenomTB = new System.Windows.Forms.TextBox();
            this.nomTB = new System.Windows.Forms.TextBox();
            this.ageTB = new System.Windows.Forms.TextBox();
            this.dispoTB = new System.Windows.Forms.TextBox();
            this.loisirTB = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.actTB = new System.Windows.Forms.TextBox();
            this.nbTB = new System.Windows.Forms.TextBox();
            this.heureActTB = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Démarrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(256, 573);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "Analyser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temps restant avant la fin de l\'enregistrement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkCyan;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(211, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "60";
            // 
            // oscarEnter
            // 
            this.oscarEnter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oscarEnter.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oscarEnter.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.oscarEnter.Location = new System.Drawing.Point(663, 29);
            this.oscarEnter.Multiline = true;
            this.oscarEnter.Name = "oscarEnter";
            this.oscarEnter.Size = new System.Drawing.Size(400, 281);
            this.oscarEnter.TabIndex = 3;
            this.oscarEnter.Text = "Discours prononcé par Oscar";
            // 
            // userRequest
            // 
            this.userRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userRequest.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRequest.ForeColor = System.Drawing.Color.DodgerBlue;
            this.userRequest.Location = new System.Drawing.Point(515, 362);
            this.userRequest.Multiline = true;
            this.userRequest.Name = "userRequest";
            this.userRequest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userRequest.Size = new System.Drawing.Size(400, 281);
            this.userRequest.TabIndex = 6;
            this.userRequest.Text = "Discours prononcé par l\'utilisateur";
            // 
            // prenomTB
            // 
            this.prenomTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.prenomTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prenomTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenomTB.ForeColor = System.Drawing.Color.White;
            this.prenomTB.Location = new System.Drawing.Point(86, 83);
            this.prenomTB.Multiline = true;
            this.prenomTB.Name = "prenomTB";
            this.prenomTB.Size = new System.Drawing.Size(106, 38);
            this.prenomTB.TabIndex = 9;
            // 
            // nomTB
            // 
            this.nomTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.nomTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTB.ForeColor = System.Drawing.Color.White;
            this.nomTB.Location = new System.Drawing.Point(198, 83);
            this.nomTB.Multiline = true;
            this.nomTB.Name = "nomTB";
            this.nomTB.Size = new System.Drawing.Size(106, 38);
            this.nomTB.TabIndex = 10;
            // 
            // ageTB
            // 
            this.ageTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ageTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ageTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageTB.ForeColor = System.Drawing.Color.White;
            this.ageTB.Location = new System.Drawing.Point(302, 83);
            this.ageTB.Multiline = true;
            this.ageTB.Name = "ageTB";
            this.ageTB.Size = new System.Drawing.Size(106, 38);
            this.ageTB.TabIndex = 11;
            // 
            // dispoTB
            // 
            this.dispoTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dispoTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dispoTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispoTB.ForeColor = System.Drawing.Color.White;
            this.dispoTB.Location = new System.Drawing.Point(198, 120);
            this.dispoTB.Multiline = true;
            this.dispoTB.Name = "dispoTB";
            this.dispoTB.Size = new System.Drawing.Size(210, 144);
            this.dispoTB.TabIndex = 12;
            // 
            // loisirTB
            // 
            this.loisirTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.loisirTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loisirTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loisirTB.ForeColor = System.Drawing.Color.White;
            this.loisirTB.Location = new System.Drawing.Point(86, 120);
            this.loisirTB.Multiline = true;
            this.loisirTB.Name = "loisirTB";
            this.loisirTB.Size = new System.Drawing.Size(106, 110);
            this.loisirTB.TabIndex = 13;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(23, 573);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 70);
            this.button3.TabIndex = 14;
            this.button3.Text = "Ok Oscar !";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // actTB
            // 
            this.actTB.BackColor = System.Drawing.Color.Teal;
            this.actTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.actTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actTB.ForeColor = System.Drawing.Color.White;
            this.actTB.Location = new System.Drawing.Point(120, 344);
            this.actTB.Name = "actTB";
            this.actTB.Size = new System.Drawing.Size(246, 21);
            this.actTB.TabIndex = 15;
            this.actTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nbTB
            // 
            this.nbTB.BackColor = System.Drawing.Color.Teal;
            this.nbTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nbTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbTB.ForeColor = System.Drawing.Color.White;
            this.nbTB.Location = new System.Drawing.Point(120, 371);
            this.nbTB.Name = "nbTB";
            this.nbTB.Size = new System.Drawing.Size(246, 21);
            this.nbTB.TabIndex = 16;
            this.nbTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // heureActTB
            // 
            this.heureActTB.BackColor = System.Drawing.Color.Teal;
            this.heureActTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heureActTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heureActTB.ForeColor = System.Drawing.Color.White;
            this.heureActTB.Location = new System.Drawing.Point(120, 402);
            this.heureActTB.Name = "heureActTB";
            this.heureActTB.Size = new System.Drawing.Size(246, 21);
            this.heureActTB.TabIndex = 17;
            this.heureActTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 33);
            this.label3.TabIndex = 18;
            this.label3.Text = "Informations recueillies sur l\'utilisateur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 33);
            this.label4.TabIndex = 19;
            this.label4.Text = "Activité qu\'il désire organiser";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 435);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(491, 238);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Teal;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 286);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(491, 151);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox3.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(491, 290);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(933, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 55);
            this.label5.TabIndex = 24;
            this.label5.Text = "User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label6.Location = new System.Drawing.Point(505, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 55);
            this.label6.TabIndex = 25;
            this.label6.Text = "Oscar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 670);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heureActTB);
            this.Controls.Add(this.nbTB);
            this.Controls.Add(this.actTB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.loisirTB);
            this.Controls.Add(this.dispoTB);
            this.Controls.Add(this.ageTB);
            this.Controls.Add(this.nomTB);
            this.Controls.Add(this.prenomTB);
            this.Controls.Add(this.userRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oscarEnter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oscarEnter;
        private System.Windows.Forms.TextBox userRequest;
        private System.Windows.Forms.TextBox prenomTB;
        private System.Windows.Forms.TextBox nomTB;
        private System.Windows.Forms.TextBox ageTB;
        private System.Windows.Forms.TextBox dispoTB;
        private System.Windows.Forms.TextBox loisirTB;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox actTB;
        private System.Windows.Forms.TextBox nbTB;
        private System.Windows.Forms.TextBox heureActTB;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

