using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CavakazeRenderer
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }
        private void MainWnd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    WorkFlowUtil.FinalizeApplication();
                    Application.Exit();
                    break;

                case Keys.F:
                    DebugLogger.Text = DirectX12_Test.MainWnd().ToString();
                    break;

                case Keys.I:
                    if (commonInfo.isInitialized)
                    {
                        DebugLogger.Text = "Scene已经初始化过了！";
                    }
                    else
                    {
                        WorkFlowUtil.InitializeScene(ref commonInfo);
                        commonInfo.isInitialized = true;

                        DebugLogger.Text = "Scene初始化成功！";
                    }
                    break;
                case Keys.T:
                    DebugLogger.Text = CudaUtil.test().ToString();
                    break;
            }
        }

        private void MainWnd_Shown(object sender, EventArgs e)
        {

        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            commonInfo = new CommonInfo(Width, Height);
            commonInfo.isInitialized = false;
        }

        private void MainWnd_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (commonInfo.isInitialized)
                {
                    commonInfo.currentMouseX = e.X;
                    commonInfo.currentMouseY = e.Y;

                    commonInfo.accumulatedX += commonInfo.currentMouseX - commonInfo.lastMouseX;
                    commonInfo.accumulatedY += commonInfo.currentMouseY - commonInfo.lastMouseY;

                    commonInfo.lastMouseX = commonInfo.currentMouseX;
                    commonInfo.lastMouseY = commonInfo.currentMouseY;

                    //DebugLogger.Text = "X坐标: " + commonInfo.accumulatedX.ToString() + "Y坐标: " + commonInfo.accumulatedY.ToString();

                    commonInfo.scene.camera.Update(ref commonInfo);

                    CudaUtil.SendCamera(commonInfo.scene.camera);
                    WorkFlowUtil.Update(ref commonInfo);
                    switch (commonInfo.swampIdx)
                    {
                        case false: BackgroundImage = commonInfo.frameBuffer1; break;
                        case true: BackgroundImage = commonInfo.frameBuffer0; break;
                    }
                    WorkFlowUtil.RenderScene(ref commonInfo);
                    DebugLogger.Text = commonInfo.DebugInfo;
                }
                else
                {
                    DebugLogger.Text = "Scene还未初始化！还不能进行渲染，请按下I键进行初始化！";
                }
            }
        }

        private void MainWnd_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case 'w':
                    if (commonInfo.isPressingMouseLeft)
                    {
                        commonInfo.scene.camera.MoveForward();
                    }
                    else
                    {
                        DebugLogger.Text = "没有按住鼠标左键，当前按下的方向键无效。";
                    }
                    break;
                case 'a':
                    if (commonInfo.isPressingMouseLeft)
                    {
                        commonInfo.scene.camera.MoveLeft();
                    }
                    else
                    {
                        DebugLogger.Text = "没有按住鼠标左键，当前按下的方向键无效。";
                    }
                    break;
                case 's':
                    if (commonInfo.isPressingMouseLeft)
                    {
                        commonInfo.scene.camera.MoveBack();
                    }
                    else
                    {
                        DebugLogger.Text = "没有按住鼠标左键，当前按下的方向键无效。";
                    }
                    break;
                case 'd':
                    if (commonInfo.isPressingMouseLeft)
                    {
                        commonInfo.scene.camera.MoveRight();
                    }
                    else
                    {
                        DebugLogger.Text = "没有按住鼠标左键，当前按下的方向键无效。";
                    }
                    break;
            }
        }

        private void MainWnd_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    commonInfo.isPressingMouseLeft = true;
                    commonInfo.lastMouseX = e.X;
                    commonInfo.lastMouseY = e.Y;
                    commonInfo.currentMouseX = e.X;
                    commonInfo.currentMouseY = e.Y;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void MainWnd_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    commonInfo.isPressingMouseLeft = false;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }
    }
}
