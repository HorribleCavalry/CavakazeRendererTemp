namespace CavakazeRenderer
{
    partial class MainWnd
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DebugLogger = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DebugLogger
            // 
            this.DebugLogger.AutoSize = true;
            this.DebugLogger.BackColor = System.Drawing.Color.Transparent;
            this.DebugLogger.Location = new System.Drawing.Point(5, 5);
            this.DebugLogger.Name = "DebugLogger";
            this.DebugLogger.Size = new System.Drawing.Size(443, 12);
            this.DebugLogger.TabIndex = 0;
            this.DebugLogger.Text = "按下I初始化场景。按下空格键生成UV图。按下F打开DirectX12渲染Hello Triangle";
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CavakazeRenderer.Properties.Resources.Game;
            this.ClientSize = new System.Drawing.Size(256, 144);
            this.Controls.Add(this.DebugLogger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWnd";
            this.ShowIcon = false;
            this.Text = "CavaKaze";
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWnd_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWnd_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWnd_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWnd_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWnd_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Bitmap image;//增添了一个image
        private CommonInfo commonInfo;
        private System.Windows.Forms.Label DebugLogger;
    }
}

