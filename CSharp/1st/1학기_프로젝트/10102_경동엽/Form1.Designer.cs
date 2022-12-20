
namespace _10102_경동엽
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OutLine1 = new System.Windows.Forms.PictureBox();
            this.outLine2 = new System.Windows.Forms.PictureBox();
            this.Line1 = new System.Windows.Forms.PictureBox();
            this.Line2 = new System.Windows.Forms.PictureBox();
            this.Line3 = new System.Windows.Forms.PictureBox();
            this.Line4 = new System.Windows.Forms.PictureBox();
            this.Car = new System.Windows.Forms.PictureBox();
            this.RamBo1 = new System.Windows.Forms.PictureBox();
            this.RamBo2 = new System.Windows.Forms.PictureBox();
            this.coin1 = new System.Windows.Forms.PictureBox();
            this.coin2 = new System.Windows.Forms.PictureBox();
            this.coin3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.coinCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamBo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamBo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OutLine1
            // 
            this.OutLine1.BackColor = System.Drawing.Color.White;
            this.OutLine1.Location = new System.Drawing.Point(-2, -7);
            this.OutLine1.Name = "OutLine1";
            this.OutLine1.Size = new System.Drawing.Size(19, 471);
            this.OutLine1.TabIndex = 0;
            this.OutLine1.TabStop = false;
            // 
            // outLine2
            // 
            this.outLine2.BackColor = System.Drawing.Color.White;
            this.outLine2.Location = new System.Drawing.Point(367, -7);
            this.outLine2.Name = "outLine2";
            this.outLine2.Size = new System.Drawing.Size(19, 471);
            this.outLine2.TabIndex = 1;
            this.outLine2.TabStop = false;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.White;
            this.Line1.Location = new System.Drawing.Point(181, 34);
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(17, 91);
            this.Line1.TabIndex = 2;
            this.Line1.TabStop = false;
            this.Line1.Click += new System.EventHandler(this.Line1_Click);
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.White;
            this.Line2.Location = new System.Drawing.Point(181, 169);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(17, 91);
            this.Line2.TabIndex = 3;
            this.Line2.TabStop = false;
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.White;
            this.Line3.Location = new System.Drawing.Point(181, 309);
            this.Line3.Name = "Line3";
            this.Line3.Size = new System.Drawing.Size(17, 91);
            this.Line3.TabIndex = 4;
            this.Line3.TabStop = false;
            // 
            // Line4
            // 
            this.Line4.BackColor = System.Drawing.Color.White;
            this.Line4.Location = new System.Drawing.Point(181, 444);
            this.Line4.Name = "Line4";
            this.Line4.Size = new System.Drawing.Size(17, 91);
            this.Line4.TabIndex = 5;
            this.Line4.TabStop = false;
            // 
            // Car
            // 
            this.Car.Image = ((System.Drawing.Image)(resources.GetObject("Car.Image")));
            this.Car.Location = new System.Drawing.Point(204, 374);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(34, 63);
            this.Car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Car.TabIndex = 6;
            this.Car.TabStop = false;
            // 
            // RamBo1
            // 
            this.RamBo1.Image = ((System.Drawing.Image)(resources.GetObject("RamBo1.Image")));
            this.RamBo1.Location = new System.Drawing.Point(72, 67);
            this.RamBo1.Name = "RamBo1";
            this.RamBo1.Size = new System.Drawing.Size(67, 42);
            this.RamBo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RamBo1.TabIndex = 7;
            this.RamBo1.TabStop = false;
            // 
            // RamBo2
            // 
            this.RamBo2.Image = ((System.Drawing.Image)(resources.GetObject("RamBo2.Image")));
            this.RamBo2.Location = new System.Drawing.Point(284, 134);
            this.RamBo2.Name = "RamBo2";
            this.RamBo2.Size = new System.Drawing.Size(67, 42);
            this.RamBo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RamBo2.TabIndex = 8;
            this.RamBo2.TabStop = false;
            // 
            // coin1
            // 
            this.coin1.Image = ((System.Drawing.Image)(resources.GetObject("coin1.Image")));
            this.coin1.Location = new System.Drawing.Point(42, 134);
            this.coin1.Name = "coin1";
            this.coin1.Size = new System.Drawing.Size(68, 69);
            this.coin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.coin1.TabIndex = 9;
            this.coin1.TabStop = false;
            // 
            // coin2
            // 
            this.coin2.Image = ((System.Drawing.Image)(resources.GetObject("coin2.Image")));
            this.coin2.Location = new System.Drawing.Point(130, 243);
            this.coin2.Name = "coin2";
            this.coin2.Size = new System.Drawing.Size(68, 69);
            this.coin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.coin2.TabIndex = 10;
            this.coin2.TabStop = false;
            // 
            // coin3
            // 
            this.coin3.Image = ((System.Drawing.Image)(resources.GetObject("coin3.Image")));
            this.coin3.Location = new System.Drawing.Point(260, 40);
            this.coin3.Name = "coin3";
            this.coin3.Size = new System.Drawing.Size(68, 69);
            this.coin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.coin3.TabIndex = 11;
            this.coin3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("궁서체", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(59, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 64);
            this.label1.TabIndex = 12;
            this.label1.Text = "GameOver";
            this.label1.Visible = false;
            // 
            // coinCounter
            // 
            this.coinCounter.AutoSize = true;
            this.coinCounter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.coinCounter.Font = new System.Drawing.Font("궁서체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.coinCounter.Location = new System.Drawing.Point(23, 9);
            this.coinCounter.Name = "coinCounter";
            this.coinCounter.Size = new System.Drawing.Size(127, 24);
            this.coinCounter.TabIndex = 16;
            this.coinCounter.Text = "coins : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.coinCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coin3);
            this.Controls.Add(this.coin2);
            this.Controls.Add(this.coin1);
            this.Controls.Add(this.RamBo2);
            this.Controls.Add(this.RamBo1);
            this.Controls.Add(this.Car);
            this.Controls.Add(this.Line4);
            this.Controls.Add(this.Line3);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.Line1);
            this.Controls.Add(this.outLine2);
            this.Controls.Add(this.OutLine1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.OutLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Line4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamBo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamBo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox OutLine1;
        private System.Windows.Forms.PictureBox outLine2;
        private System.Windows.Forms.PictureBox Line1;
        private System.Windows.Forms.PictureBox Line2;
        private System.Windows.Forms.PictureBox Line3;
        private System.Windows.Forms.PictureBox Line4;
        private System.Windows.Forms.PictureBox Car;
        private System.Windows.Forms.PictureBox RamBo1;
        private System.Windows.Forms.PictureBox RamBo2;
        private System.Windows.Forms.PictureBox coin1;
        private System.Windows.Forms.PictureBox coin2;
        private System.Windows.Forms.PictureBox coin3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label coinCounter;
    }
}

