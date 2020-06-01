using System;


namespace CavakazeRenderer
{
    class WorkFlowUtil
    {
        public static void InitializeScene(ref CommonInfo commonInfo)//该函数初始化的时候只执行一次，是按下I键后启动
        {
            CudaUtil.OpenDebugConsole();

            CudaUtil.InitializeResources(CommonInfo.Width, CommonInfo.Heght,64);

            CudaUtil.AddBufferMap(commonInfo.frame_buffer0_data.Scan0);
            CudaUtil.AddBufferMap(commonInfo.frame_buffer1_data.Scan0);
            CudaUtil.AddBufferMap(commonInfo.picking_buffer_data.Scan0);

            commonInfo.frameBuffer0.UnlockBits(commonInfo.frame_buffer0_data);
            commonInfo.frameBuffer1.UnlockBits(commonInfo.frame_buffer1_data);
            commonInfo.pickingBuffer.UnlockBits(commonInfo.picking_buffer_data);

            Point3[] points = new Point3[3];
            points[0] = new Point3(-1.0f, 0.0f, -15.0f);
            points[1] = new Point3(1.0f, 0.0f, -15.0f);
            points[2] = new Point3(0.5f, 1.0f, -15.0f);

            Point2[] uv = new Point2[3];
            uv[0] = new Point2(0.0f, 0.0f);
            uv[1] = new Point2(1.0f, 0.0f);
            uv[2] = new Point2(0.5f, 1.0f);

            //CudaUtil.AddTriangle(Color.White, points, uv);
            CudaUtil.AddSphere(new Point3(0.0f, 0.0f, -5.0f), Color.White, 2.0f);
            CudaUtil.AddSphere(new Point3(4.0f, 0.0f, -5.0f), Color.White, 2.0f);
            CudaUtil.AddPlane(new Point3(0.0f, -2.0f, 0.0f), Color.White, new Normal(0.0f, 1.0f, 0.0f));

            CudaUtil.AddTexture("C:\\Users\\Hordr\\source\\repos\\CavakazeRenderer\\CavakazeRenderer\\bin\\Debug\\Textures\\albedo.png");
            CudaUtil.AddTexture("C:\\Users\\Hordr\\source\\repos\\CavakazeRenderer\\CavakazeRenderer\\bin\\Debug\\Textures\\normal.png");
            CudaUtil.AddTexture("C:\\Users\\Hordr\\source\\repos\\CavakazeRenderer\\CavakazeRenderer\\bin\\Debug\\Textures\\metallic.png");
            CudaUtil.AddTexture("C:\\Users\\Hordr\\source\\repos\\CavakazeRenderer\\CavakazeRenderer\\bin\\Debug\\Textures\\roughness.png");
            CudaUtil.AddTexture("C:\\Users\\Hordr\\source\\repos\\CavakazeRenderer\\CavakazeRenderer\\bin\\Debug\\Textures\\ao.png");
            CudaUtil.GenerateTextureList();
            CudaUtil.SetPrimitiveDesinyPBRMaterial(0, 0, 1, 2, 3, 4);
            CudaUtil.SetPrimitiveDesinyPBRMaterial(1, 0, 1, 2, 3, 4);
            CudaUtil.SetPrimitiveDesinyPBRMaterial(2, 0, 1, 2, 3, 4);
            CudaUtil.GenerateScene();


        }
        public static void Update(ref CommonInfo commonInfo)//该函数在拖拽住鼠标的时候每一帧执行一次,目前的打算是将该函数主要应用于图元的各种变换，比如旋转平移啥的
        {

        }
        public static void RenderScene(ref CommonInfo commonInfo)//该函数也是在拖拽住鼠标的时候每一帧执行一次，顺序是在Update函数执行完毕的时候才会执行这个函数
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            switch (commonInfo.swampIdx)
            {
                case false:
                    CudaUtil.RenderScene(0, 2);
                    break;
                case true:
                    CudaUtil.RenderScene(1, 2);
                    break;
            }

            commonInfo.swampIdx = !commonInfo.swampIdx;
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            double totalSeconds = timeSpan.TotalSeconds;
            double FPS = 1 / totalSeconds;
            commonInfo.DebugInfo = " Render Overhead: "+ totalSeconds.ToString();
        }

        public static void FinalizeApplication()
        {
            CudaUtil.FreeResources();
        }
    }
}
