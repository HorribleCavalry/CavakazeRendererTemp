using System;
using System.Runtime.InteropServices;

namespace CavakazeRenderer
{
    class CudaUtil
    {
        static private int frame_buffer_size = 0;

        #region Console
        /// <summary>
        /// 打开控制台
        /// </summary>
        [DllImport("CudaAPI", EntryPoint = "OpenDebugConsole", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenDebugConsole();
        #endregion

        #region Initialize Necessary Resources on CUDA
        [DllImport("CudaAPI", EntryPoint = "initializeResources", CallingConvention = CallingConvention.Cdecl)]
        unsafe private static extern bool initializeResources(int _width, int _height,int _depth);
        /// <summary>
        /// 指定渲染流程中的长与宽，并初始化必要的资源
        /// </summary>
        /// <param name="_width"></param>
        /// <param name="_height"></param>
        public static bool InitializeResources(int _width, int _height, int _depth)
        {
            frame_buffer_size = _width * _height;
            bool result = false;
            unsafe
            {
                result= initializeResources(_width, _height, _depth);
            }
            return result;
        }
        #endregion

        #region Buffer Map Add & Free
        [DllImport("CudaAPI", EntryPoint = "addBufferMap", CallingConvention = CallingConvention.Cdecl)]
        unsafe private static extern int addBufferMap(BufferMap* bufferMap);
        /// <summary>
        /// 向C端添加BufferMap的指针, 用于Render Scene操作
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int AddBufferMap(IntPtr bufferMap)
        {
            int result = -1;
            unsafe
            {
                result=addBufferMap((BufferMap*)bufferMap);
            }
            return result;
        }

        #endregion

        #region Free Resources
        [DllImport("CudaAPI", EntryPoint = "freeResources", CallingConvention = CallingConvention.Cdecl)]
        unsafe private static extern bool freeResources();
        /// <summary>
        /// 回收各种资源
        /// </summary>
        public static bool FreeResources()
        {
            bool result = false;
            unsafe
            {
                result= freeResources();
            }
            return result;
        }
        #endregion

        #region Texture
        [DllImport("CudaAPI", EntryPoint = "addTexture", CallingConvention = CallingConvention.Cdecl)]
        unsafe private static extern int addTexture(string path);
        public static int AddTexture(string path)
        {
            int result=-1; 
            unsafe
            {
                result= addTexture(path);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "generateTextureList", CallingConvention = CallingConvention.Cdecl)]
        unsafe private static extern bool generateTextureList();
        public static bool GenerateTextureList()
        {
            bool result = false;
            unsafe
            {
                result = generateTextureList();
            }
            return result;
        }
        #endregion

        #region Primitive or Camera add, delete and change
        [DllImport("CudaAPI", EntryPoint = "AddSphere", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AddSphere(float c_x, float c_y, float c_z, float r, float g, float b, float a, float radius);
        /// <summary>
        /// 根据参数添加球体
        /// </summary>
        /// <param name="centre"></param>
        /// <param name="materialColor"></param>
        /// <param name="radius"></param>
        public static int AddSphere(Point3 centre, Color materialColor, float radius)
        {
            int currentIndex=-1;
            unsafe
            {
                currentIndex = AddSphere(
                    centre.x, centre.y, centre.z,
                    materialColor.r, materialColor.g, materialColor.b, materialColor.a,
                    radius
                    );
            }
            return currentIndex;
        }
        /// <summary>
        /// 添加默认的球体
        /// </summary>
        public static int AddSphere()
        {
            int currentIndex = -1;
            currentIndex = AddSphere(new Point3(0.0f,0.0f,-5.0f), Color.Red, 1.0f);
            return currentIndex;
        }

        [DllImport("CudaAPI", EntryPoint = "AddTriangle", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AddTriangle(float r, float g, float b, float a, float point0_x, float point0_y, float point0_z, float point1_x, float point1_y, float point1_z, float point2_x, float point2_y, float point2_z, float uv0_u, float uv0_v, float uv1_u, float uv1_v, float uv2_u, float uv2_v);
        /// <summary>
        /// 根据参数添加Triangle
        /// </summary>
        /// <param name="centre"></param>
        /// <param name="materialColor"></param>
        /// <param name="points"></param>
        public static int AddTriangle(Color materialColor, Point3[] points, Point2[] uv)
        {
            int currentIndex = -1;
            unsafe
            {
                currentIndex = AddTriangle(
                    materialColor.r, materialColor.g, materialColor.b, materialColor.a,
                    points[0].x, points[0].y, points[0].z,
                    points[1].x, points[1].y, points[1].z,
                    points[2].x, points[2].y, points[2].z,
                    uv[0].x, uv[0].y,
                    uv[1].x, uv[1].y,
                    uv[2].x, uv[2].y
                    );
            }
            return currentIndex;
        }
        /// <summary>
        /// 添加默认的Triangle
        /// </summary>
        public static int AddTriangle()
        {
            int currentIndex = -1;
            Point3[] points = new Point3[3];
            points[0] = new Point3(1.0f, 0.0f, -5.0f);
            points[1] = new Point3(0.0f, 1.0f, -5.0f);
            points[2] = new Point3(-1.0f, 0.0f, -5.0f);
            Point2[] uv= new Point2[3];
            uv[0] = new Point2(0.0f, 0.0f);
            uv[1] = new Point2(1.0f, 0.0f);
            uv[2] = new Point2(0.5f, 1.0f);
            currentIndex = AddTriangle(new Color(), points, uv);
            return currentIndex;
        }

        [DllImport("CudaAPI", EntryPoint = "AddPlane", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AddPlane(float c_x, float c_y, float c_z, float r, float g, float b, float a, float normal_x, float normal_y, float normal_z);
        /// <summary>
        /// 根据参数添加Plane
        /// </summary>
        /// <param name="centre"></param>
        /// <param name="materialColor"></param>
        /// <param name="normal"></param>
        public static int AddPlane(Point3 centre, Color materialColor, Normal normal)
        {
            int currentIndex = -1;
            unsafe
            {
                currentIndex =  AddPlane(
                    centre.x, centre.y, centre.z,
                    materialColor.r, materialColor.g, materialColor.b, materialColor.a,
                    normal.x, normal.y, normal.z
                    );
            }
            return currentIndex;
        }
        /// <summary>
        /// 添加默认的Plane
        /// </summary>
        public static int AddPlane()
        {
            int currentIndex = -1;
            currentIndex = AddPlane(new Point3(),new Color(),new Normal());
            return currentIndex;
        }

        /// <summary>
        /// 向GPU发送Camera的相关信息
        /// </summary>
        /// <param name="position_x"></param>
        /// <param name="position_y"></param>
        /// <param name="position_z"></param>
        /// <param name="rotation_x"></param>
        /// <param name="rotation_y"></param>
        /// <param name="rotation_z"></param>
        /// <param name="rotation_w"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fov"></param>
        /// <param name="aspectRatio"></param>
        /// <param name="viewDistance"></param>
        /// <param name="sampler"></param>
        [DllImport("CudaAPI", EntryPoint = "SendCamera", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SendCamera(
        float position_x, float position_y, float position_z,
        float rotation_x, float rotation_y, float rotation_z, float rotation_w,
        float fov, float aspectRatio, float viewDistance, int sampler);
        public static bool SendCamera(Camera camera)
        {
            bool result = false;
            unsafe
            {
                result = SendCamera(
    camera.position.x, camera.position.y, camera.position.z,
    camera.rotation.imaginaryPart.x, camera.rotation.imaginaryPart.y, camera.rotation.imaginaryPart.z, camera.rotation.realPart,
    camera.fov, camera.aspectRatio, camera.viewDistance, 0);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "deletePrimitive", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool deletePrimitive(int index);
        /// <summary>
        /// 删除在该index下的primitive
        /// </summary>
        /// <param name="index"></param>
        public static bool DeletePrimitive(int index)
        {
            bool result = false;
            unsafe
            {
                result= deletePrimitive(index);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitive", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitive(
            int index,
            Primitive_type type,
            float c_x, float c_y, float c_z,
            float r, float g, float b, float a,
            float n_x, float n_y, float n_z,
            float radius,
            float p0_x, float p0_y, float p0_z,
            float p1_x, float p1_y, float p1_z,
            float p2_x, float p2_y, float p2_z,
            float uv0_u, float uv0_v,
            float uv1_u, float uv1_v,
            float uv2_u, float uv2_v
            );
        /// <summary>
        /// 修改某个结点处的Primitive并使之变为Default
        /// </summary>
        /// <param name="index"></param>
        /// <param name="primitive"></param>
        public static bool ChangePrimitive(int index, Primitive primitive)
        {
            bool result = false;
            unsafe
            {
                result= changePrimitive(
                    index,
                    Primitive_type.Default,//type
                    primitive.centre.x, primitive.centre.y, primitive.centre.z,//centre
                    primitive.materialColor.r, primitive.materialColor.g, primitive.materialColor.b, primitive.materialColor.a,//materialColor
                    0.0f, 1.0f, 0.0f,//Normal
                    0.0f,//radius
                    0.0f, 0.0f, 0.0f,//p0
                    0.0f, 0.0f, 0.0f,//p1
                    0.0f, 0.0f, 0.0f, //p2
                    0,0,
                    0,0,
                    0,0
                    );
            }
            return result;
        }
        /// <summary>
        /// 修改某个结点处的Primitive并使之变为Sphere
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sphere"></param>
        public static bool ChangePrimitive(int index, Sphere sphere)
        {
            bool result = false;
            unsafe
            {
                result= changePrimitive(
                    index,
                    Primitive_type.Sphere,//type
                    sphere.centre.x, sphere.centre.y, sphere.centre.z,//centre
                    sphere.materialColor.r, sphere.materialColor.g, sphere.materialColor.b, sphere.materialColor.a,//materialColor
                    0.0f, 1.0f, 0.0f,//Normal
                    sphere.radius,//radius
                    0.0f, 0.0f, 0.0f,//p0
                    0.0f, 0.0f, 0.0f,//p1
                    0.0f, 0.0f, 0.0f,//p2
                    0, 0,
                    0, 0,
                    0, 0
                    );
            }
            return result;
        }
        /// <summary>
        /// 修改某个结点处的Primitive并使之变为Triangle
        /// </summary>
        /// <param name="index"></param>
        /// <param name="triangle"></param>
        public static bool ChangePrimitive(int index, Triangle triangle)
        {
            bool result = false;
            unsafe
            {
                result=changePrimitive(
                    index,
                    Primitive_type.Triangle,//type
                    triangle.centre.x, triangle.centre.y, triangle.centre.z,//centre
                    triangle.materialColor.r, triangle.materialColor.g, triangle.materialColor.b, triangle.materialColor.a,//materialColor
                    triangle.normal.x, triangle.normal.y, triangle.normal.z,//Normal
                    0.0f,//radius
                    triangle.points[0].x, triangle.points[0].y, triangle.points[0].z,//p0
                    triangle.points[1].x, triangle.points[1].y, triangle.points[1].z,//p1
                    triangle.points[2].x, triangle.points[2].y, triangle.points[2].z, //p2
                    triangle.uv[0].x, triangle.uv[0].y,
                    triangle.uv[1].x, triangle.uv[1].y,
                    triangle.uv[2].x, triangle.uv[2].y
                    );
            }
            return result;
        }
        /// <summary>
        /// 修改某个结点处的Primitive并使之变为Plane
        /// </summary>
        /// <param name="index"></param>
        /// <param name="plane"></param>
        public static bool ChangePrimitive(int index, Plane plane)
        {
            bool result=false;
            unsafe
            {
                result = changePrimitive(
                    index,
                    Primitive_type.Plane,//type
                    plane.centre.x, plane.centre.y, plane.centre.z,//centre
                    plane.materialColor.r, plane.materialColor.g, plane.materialColor.b, plane.materialColor.a,//materialColor
                    plane.normal.x, plane.normal.y, plane.normal.z,//Normal
                    0.0f,//radius
                    0.0f, 0.0f, 0.0f,//p0
                    0.0f, 0.0f, 0.0f,//p1
                    0.0f, 0.0f, 0.0f, //p2
                    0,0,
                    0,0,
                    0,0
                    );
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveType", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveType(int index, Primitive_type type);
        /// <summary>
        /// 修改图元的类型
        /// </summary>
        /// <param name="index"></param>
        /// <param name="type"></param>
        public static bool ChangePrimitiveType(int index, Primitive_type type)
        {
            bool result = false;
            unsafe
            {
                result=changePrimitiveType(index, type);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveCentre", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveCentre(int index, float c_x, float c_y, float c_z);
        /// <summary>
        /// 修改图元的质心
        /// </summary>
        /// <param name="index"></param>
        /// <param name="centre"></param>
        public static bool ChangePrimitiveCentre(int index, Point3 centre)
        {
            bool result = false;
            unsafe
            {
                result= changePrimitiveCentre(index, centre.x,centre.y,centre.z);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveColor", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveColor(int index, float r, float g, float b,float a);
        /// <summary>
        /// 修改图元的颜色
        /// </summary>
        /// <param name="index"></param>
        /// <param name="materialColor"></param>
        public static bool ChangePrimitiveColor(int index, Color materialColor)
        {
            bool restult = false;
            unsafe
            {
                restult= changePrimitiveColor(index, materialColor.r, materialColor.g, materialColor.b,materialColor.a);
            }
            return restult;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveNormal", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveNormal(int index, float x, float y, float z);
        /// <summary>
        /// 修改平面的法线朝向
        /// </summary>
        /// <param name="index"></param>
        /// <param name="normal"></param>
        public static bool ChangePrimitiveNormal(int index, Normal normal)
        {
            bool result = false;
            unsafe
            {
                result= changePrimitiveNormal(index, normal.x,normal.y,normal.z);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveRadius", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveRadius(int index, float radius);
        /// <summary>
        /// 修改球的半径
        /// </summary>
        /// <param name="index"></param>
        /// <param name="radius"></param>
        public static bool ChangePrimitiveRadius(int index, float radius)
        {
            bool result = false;
            unsafe
            {
                result=changePrimitiveRadius(index, radius);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitivePoints", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitivePoints(int index,
            float p0_x, float p0_y, float p0_z,
            float p1_x, float p1_y, float p1_z,
            float p2_x, float p2_y, float p2_z
            );
        /// <summary>
        /// 修改三角形的三个顶点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="points"></param>
        public static bool ChangePrimitivePoints(int index, Point3[] points)
        {
            bool result = false;
            unsafe
            {
                result=changePrimitivePoints(index, 
                    points[0].x,points[0].y,points[0].z,
                    points[1].x,points[1].y,points[1].z,
                    points[2].x,points[2].y,points[2].z
                    );
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "changePrimitiveUV", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool changePrimitiveUV(int index,
        float uv0_u, float uv0_v,
        float uv1_u, float uv1_v,
        float uv2_u, float uv2_v
    );
        public static bool ChangePrimitiveUV(int index, Point2[] uv)
        {
            bool result = false;
            unsafe
            {
                result=changePrimitiveUV(index,
                    uv[0].x, uv[0].y,
                    uv[1].x, uv[1].y,
                    uv[2].x, uv[2].y
                    );
            }
            return result;
        }

        #endregion

        #region Check primitive
        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveType", CallingConvention = CallingConvention.Cdecl)]
        private static extern Primitive_type checkPrimitiveType(int index);
        /// <summary>
        /// 查看在该index下图元的类型
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Primitive_type CheckPrimitiveType(int index)
        {
            unsafe
            {
                return checkPrimitiveType(index);
            }
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveCentre", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitiveCentre(int index,int c_idx);
        /// <summary>
        /// 查看在该index下图元的类质心
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Point3 CheckPrimitiveCentre(int index)
        {
            Point3 result = new Point3();
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0: result.x = checkPrimitiveCentre(index, i);break;
                    case 1: result.y = checkPrimitiveCentre(index, i);break;
                    case 2: result.z = checkPrimitiveCentre(index, i);break;
                }
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveColor", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitiveColor(int index, int c_idx);
        /// <summary>
        /// 查看在该index下的materialColor
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Color CheckPrimitiveColor(int index)
        {
            Color result = new Color();
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0: result.r = checkPrimitiveColor(index, i); break;
                    case 1: result.g = checkPrimitiveColor(index, i); break;
                    case 2: result.b = checkPrimitiveColor(index, i); break;
                    case 3: result.a = checkPrimitiveColor(index, i); break;
                }
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveNormal", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitiveNormal(int index, int n_idx);
        /// <summary>
        /// 查看在该index下的normal
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Normal CheckPrimitiveNormal(int index)
        {
            Normal result = new Normal();
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0: result.x = checkPrimitiveNormal(index, i); break;
                    case 1: result.y = checkPrimitiveNormal(index, i); break;
                    case 2: result.z = checkPrimitiveNormal(index, i); break;
                }
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveRadius", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitiveRadius(int index);
        /// <summary>
        /// 查看在该index下的radius
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static float CheckPrimitiveRadius(int index)
        {
            unsafe
            {
                return checkPrimitiveRadius(index);
            }
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitivePoints", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitivePoints(int index, int p_idx);
        /// <summary>
        /// 查看在该index下的radius
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Point3[] CheckPrimitivePoints(int index)
        {
            Point3[] result = new Point3[3];
            result[0] = new Point3();
            result[1] = new Point3();
            result[2] = new Point3();
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0: result[0].x = checkPrimitivePoints(index, i); break;
                    case 1: result[0].y = checkPrimitivePoints(index, i); break;
                    case 2: result[0].z = checkPrimitivePoints(index, i); break;

                    case 3: result[1].x = checkPrimitivePoints(index, i); break;
                    case 4: result[1].y = checkPrimitivePoints(index, i); break;
                    case 5: result[1].z = checkPrimitivePoints(index, i); break;

                    case 6: result[2].x = checkPrimitivePoints(index, i); break;
                    case 7: result[2].y = checkPrimitivePoints(index, i); break;
                    case 8: result[2].z = checkPrimitivePoints(index, i); break;
                }
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "checkPrimitiveUV", CallingConvention = CallingConvention.Cdecl)]
        private static extern float checkPrimitiveUV(int index, int u_idx);
        /// <summary>
        /// 查看在该index下的radius
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Point2[] CheckPrimitiveUV(int index)
        {
            Point2[] result = new Point2[3];
            result[0] = new Point2();
            result[1] = new Point2();
            result[2] = new Point2();
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0: result[0].x = checkPrimitivePoints(index, i); break;
                    case 1: result[0].y = checkPrimitivePoints(index, i); break;

                    case 2: result[1].x = checkPrimitivePoints(index, i); break;
                    case 3: result[1].y = checkPrimitivePoints(index, i); break;

                    case 4: result[2].x = checkPrimitivePoints(index, i); break;
                    case 5: result[2].y = checkPrimitivePoints(index, i); break;
                }
            }
            return result;
        }

        #endregion

        #region material
        [DllImport("CudaAPI", EntryPoint = "setPrimitiveBlinPhongMaterial", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool setPrimitiveBlinPhongMaterial(int _primitive_index, int _Albedo_index, int _Normal_index, int _Roughness_index, int _AO_index);
        public static bool SetPrimitiveBlinPhongMaterial(int _primitive_index, int _Albedo_index, int _Normal_index, int _Roughness_index, int _AO_index)
        {
            bool result = false;
            unsafe
            {
                result = setPrimitiveBlinPhongMaterial(_primitive_index, _Albedo_index, _Normal_index, _Roughness_index, _AO_index);
            }
            return result;
        }

        [DllImport("CudaAPI", EntryPoint = "setPrimitiveDesinyPBRMaterial", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool setPrimitiveDesinyPBRMaterial(int _primitive_index, int _Albedo_index, int _Normal_index, int _Metallic_index, int _Roughness_index, int _AO_index);
        public static bool SetPrimitiveDesinyPBRMaterial(int _primitive_index, int _Albedo_index, int _Normal_index, int _Metallic_index, int _Roughness_index, int _AO_index)
        {
            bool result =false;
            unsafe
            {
                result = setPrimitiveDesinyPBRMaterial(_primitive_index, _Albedo_index, _Normal_index, _Metallic_index, _Roughness_index, _AO_index);
            }
            return result;
        }
        #endregion

        #region Generate scene
        [DllImport("CudaAPI", EntryPoint = "generateScene", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool generateScene();
        /// <summary>
        /// GenerateScene()应该在每一次场景中的图元的数量改动时执行一次，因为需要重新给GPU分配内存。
        /// 但是修改某个图元的数据时不需要执行。
        /// </summary>
        public static bool GenerateScene()
        {
            bool result = false;
            unsafe
            {
                result=generateScene();
            }
            return result;
        }

        #endregion

        #region Render
        [DllImport("CudaAPI", EntryPoint = "renderScene", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool renderScene(int frame_buffer_index, int picking_buffer_index);
        /// <summary>
        /// 指定一张Frame Buffer用于渲染最终图片，指定一张Picking Buffer用于快速拾取
        /// </summary>
        /// <param name="frame_buffer_index"></param>
        /// <param name="picking_buffer_index"></param>
        public static bool RenderScene(int frame_buffer_index, int picking_buffer_index)
        {
            bool result = false;
            unsafe
            {
                result=renderScene(frame_buffer_index, picking_buffer_index);
            }
            return result;
        }
        #endregion

        #region Debug&Test
        [DllImport("CudaAPI", EntryPoint = "test", CallingConvention = CallingConvention.Cdecl)]
        public static extern int test();
        /// <summary>
        /// Debug&Test用的，不用管
        /// </summary>
        /// <returns></returns>
        public static int Test()
        {
            return test();
        }
        #endregion
    }

    public enum Primitive_type
    {
        Default,
        Sphere,
        Triangle,
        Plane
    }
    public struct BufferMap
    {
        byte r, g, b;
    };
}
