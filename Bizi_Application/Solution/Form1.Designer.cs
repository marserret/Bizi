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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.oscarEnter.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.oscarEnter.Location = new System.Drawing.Point(500, 66);
            this.oscarEnter.Multiline = true;
            this.oscarEnter.Name = "oscarEnter";
            this.oscarEnter.Size = new System.Drawing.Size(568, 260);
            this.oscarEnter.TabIndex = 3;
            this.oscarEnter.Text = "Discours prononcé par Oscar";
            // 
            // userRequest
            // 
            this.userRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userRequest.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRequest.ForeColor = System.Drawing.Color.Teal;
            this.userRequest.Location = new System.Drawing.Point(500, 403);
            this.userRequest.Multiline = true;
            this.userRequest.Name = "userRequest";
            this.userRequest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userRequest.Size = new System.Drawing.Size(568, 260);
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
            this.prenomTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.nomTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.ageTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dispoTB
            // 
            this.dispoTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dispoTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dispoTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispoTB.ForeColor = System.Drawing.Color.White;
            this.dispoTB.Location = new System.Drawing.Point(198, 144);
            this.dispoTB.Multiline = true;
            this.dispoTB.Name = "dispoTB";
            this.dispoTB.Size = new System.Drawing.Size(210, 126);
            this.dispoTB.TabIndex = 12;
            this.dispoTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loisirTB
            // 
            this.loisirTB.BackColor = System.Drawing.Color.DarkSlateGray;
            this.loisirTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loisirTB.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loisirTB.ForeColor = System.Drawing.Color.White;
            this.loisirTB.Location = new System.Drawing.Point(86, 144);
            this.loisirTB.Multiline = true;
            this.loisirTB.Name = "loisirTB";
            this.loisirTB.Size = new System.Drawing.Size(106, 127);
            this.loisirTB.TabIndex = 13;
            this.loisirTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label5.BackColor = System.Drawing.Color.Teal;
            this.label5.Font = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(714, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 55);
            this.label5.TabIndex = 24;
            this.label5.Text = "User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Font = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(714, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 55);
            this.label6.TabIndex = 25;
            this.label6.Text = "Oscar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(105, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Prénom";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(229, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Nom";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(339, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Âge";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(114, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Loisirs";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(250, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Disponibilités";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Teal;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(51, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Activité :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Teal;
            this.label13.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(26, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Participant :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Teal;
            this.label14.Font = new System.Drawing.Font("Open Sans Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(60, 402);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "Heure :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Teal;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(500, 337);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(568, 57);
            this.textBox1.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(500, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(568, 57);
            this.textBox2.TabIndex = 35;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 670);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guztiak Bizi ";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

