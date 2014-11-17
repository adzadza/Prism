namespace Sharp_Prism
{
    partial class MainFaom
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFaom));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьЧерчежToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьЧертежToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиЗеркалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиСтиляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПризмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиЦветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиТочекToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиИсточнакиСветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПроектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PrismContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.стильПризмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точкиПризмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MirrorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.LightcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.настрокйиИсточникаСветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PrismContextMenu.SuspendLayout();
            this.MirrorContextMenu.SuspendLayout();
            this.LightcontextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьЧерчежToolStripMenuItem,
            this.загрузитьЧертежToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // сохранитьЧерчежToolStripMenuItem
            // 
            this.сохранитьЧерчежToolStripMenuItem.Name = "сохранитьЧерчежToolStripMenuItem";
            this.сохранитьЧерчежToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.сохранитьЧерчежToolStripMenuItem.Text = "Сохранить Черчеж";
            this.сохранитьЧерчежToolStripMenuItem.Click += new System.EventHandler(this.сохранитьЧерчежToolStripMenuItem_Click);
            // 
            // загрузитьЧертежToolStripMenuItem
            // 
            this.загрузитьЧертежToolStripMenuItem.Name = "загрузитьЧертежToolStripMenuItem";
            this.загрузитьЧертежToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.загрузитьЧертежToolStripMenuItem.Text = "Загрузить Чертеж";
            this.загрузитьЧертежToolStripMenuItem.Click += new System.EventHandler(this.загрузитьЧертежToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиЗеркалаToolStripMenuItem,
            this.настройкиПризмыToolStripMenuItem,
            this.настройкиИсточнакиСветаToolStripMenuItem,
            this.настройкиПроектаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки ";
            // 
            // настройкиЗеркалаToolStripMenuItem
            // 
            this.настройкиЗеркалаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиСтиляToolStripMenuItem,
            this.настройкиТочекToolStripMenuItem});
            this.настройкиЗеркалаToolStripMenuItem.Name = "настройкиЗеркалаToolStripMenuItem";
            this.настройкиЗеркалаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настройкиЗеркалаToolStripMenuItem.Text = "Настройки Зеркала";
            // 
            // настройкиСтиляToolStripMenuItem
            // 
            this.настройкиСтиляToolStripMenuItem.Name = "настройкиСтиляToolStripMenuItem";
            this.настройкиСтиляToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.настройкиСтиляToolStripMenuItem.Text = "Настройки Стиля";
            this.настройкиСтиляToolStripMenuItem.Click += new System.EventHandler(this.настройкиСтиляToolStripMenuItem_Click);
            // 
            // настройкиТочекToolStripMenuItem
            // 
            this.настройкиТочекToolStripMenuItem.Name = "настройкиТочекToolStripMenuItem";
            this.настройкиТочекToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.настройкиТочекToolStripMenuItem.Text = "Настройки Точек";
            this.настройкиТочекToolStripMenuItem.Click += new System.EventHandler(this.настройкиТочекToolStripMenuItem_Click);
            // 
            // настройкиПризмыToolStripMenuItem
            // 
            this.настройкиПризмыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиЦветаToolStripMenuItem,
            this.настройкиТочекToolStripMenuItem1});
            this.настройкиПризмыToolStripMenuItem.Name = "настройкиПризмыToolStripMenuItem";
            this.настройкиПризмыToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настройкиПризмыToolStripMenuItem.Text = "Настройки Призмы";
            // 
            // настройкиЦветаToolStripMenuItem
            // 
            this.настройкиЦветаToolStripMenuItem.Name = "настройкиЦветаToolStripMenuItem";
            this.настройкиЦветаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.настройкиЦветаToolStripMenuItem.Text = "Настройки Стиля";
            this.настройкиЦветаToolStripMenuItem.Click += new System.EventHandler(this.настройкиЦветаToolStripMenuItem_Click);
            // 
            // настройкиТочекToolStripMenuItem1
            // 
            this.настройкиТочекToolStripMenuItem1.Name = "настройкиТочекToolStripMenuItem1";
            this.настройкиТочекToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.настройкиТочекToolStripMenuItem1.Text = "Настройки Точек";
            this.настройкиТочекToolStripMenuItem1.Click += new System.EventHandler(this.настройкиТочекToolStripMenuItem1_Click);
            // 
            // настройкиИсточнакиСветаToolStripMenuItem
            // 
            this.настройкиИсточнакиСветаToolStripMenuItem.Name = "настройкиИсточнакиСветаToolStripMenuItem";
            this.настройкиИсточнакиСветаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настройкиИсточнакиСветаToolStripMenuItem.Text = "Настройки Источнаки Света ";
            this.настройкиИсточнакиСветаToolStripMenuItem.Click += new System.EventHandler(this.настройкиИсточнакиСветаToolStripMenuItem_Click);
            // 
            // настройкиПроектаToolStripMenuItem
            // 
            this.настройкиПроектаToolStripMenuItem.Name = "настройкиПроектаToolStripMenuItem";
            this.настройкиПроектаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настройкиПроектаToolStripMenuItem.Text = "Настройки Проекта";
            this.настройкиПроектаToolStripMenuItem.Click += new System.EventHandler(this.настройкиПроектаToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(891, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(891, 382);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPaint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MPDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MPMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MPUp);
            // 
            // PrismContextMenu
            // 
            this.PrismContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стильПризмыToolStripMenuItem,
            this.точкиПризмыToolStripMenuItem});
            this.PrismContextMenu.Name = "PrismContextMenu";
            this.PrismContextMenu.Size = new System.Drawing.Size(157, 48);
            // 
            // стильПризмыToolStripMenuItem
            // 
            this.стильПризмыToolStripMenuItem.Name = "стильПризмыToolStripMenuItem";
            this.стильПризмыToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.стильПризмыToolStripMenuItem.Text = "Стиль Призмы";
            this.стильПризмыToolStripMenuItem.Click += new System.EventHandler(this.настройкиЦветаToolStripMenuItem_Click);
            // 
            // точкиПризмыToolStripMenuItem
            // 
            this.точкиПризмыToolStripMenuItem.Name = "точкиПризмыToolStripMenuItem";
            this.точкиПризмыToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.точкиПризмыToolStripMenuItem.Text = "Точки призмы";
            this.точкиПризмыToolStripMenuItem.Click += new System.EventHandler(this.настройкиТочекToolStripMenuItem1_Click);
            // 
            // MirrorContextMenu
            // 
            this.MirrorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.MirrorContextMenu.Name = "PrismContextMenu";
            this.MirrorContextMenu.Size = new System.Drawing.Size(157, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem1.Text = "Стиль Зеркала";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.настройкиСтиляToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem2.Text = "Точки Зеркала";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.настройкиТочекToolStripMenuItem_Click);
            // 
            // LightcontextMenu
            // 
            this.LightcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настрокйиИсточникаСветаToolStripMenuItem});
            this.LightcontextMenu.Name = "PrismContextMenu";
            this.LightcontextMenu.Size = new System.Drawing.Size(221, 26);
            // 
            // настрокйиИсточникаСветаToolStripMenuItem
            // 
            this.настрокйиИсточникаСветаToolStripMenuItem.Name = "настрокйиИсточникаСветаToolStripMenuItem";
            this.настрокйиИсточникаСветаToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.настрокйиИсточникаСветаToolStripMenuItem.Text = "Настроки источника света";
            this.настрокйиИсточникаСветаToolStripMenuItem.Click += new System.EventHandler(this.настройкиИсточнакиСветаToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainFaom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(891, 428);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFaom";
            this.Text = "Призма";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MPDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MPMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MPUp);
            this.Resize += new System.EventHandler(this.MPResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PrismContextMenu.ResumeLayout(false);
            this.MirrorContextMenu.ResumeLayout(false);
            this.LightcontextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьЧерчежToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьЧертежToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиЗеркалаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиСтиляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиПризмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиЦветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиТочекToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem настройкиИсточнакиСветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиПроектаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PrismContextMenu;
        private System.Windows.Forms.ToolStripMenuItem стильПризмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точкиПризмыToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MirrorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip LightcontextMenu;
        private System.Windows.Forms.ToolStripMenuItem настрокйиИсточникаСветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

