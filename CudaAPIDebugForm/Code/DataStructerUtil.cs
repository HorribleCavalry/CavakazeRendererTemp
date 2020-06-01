using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavakazeRenderer
{
    #region Basic Data Structure
    public class Vec3
    {
        public float x, y, z;
        public Vec3()
        {
            x = y = z = 0.0f;
        }
        public Vec3(float a, float b, float c)
        {
            x = a;
            y = b;
            z = c;
        }

        public Vec3(Point3 point)
        {
            x = point.x;
            y = point.y;
            z = point.z;
        }

        public Vec3(Vec3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        public float this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                else if (i == 1)
                    return y;
                else
                    return z;
            }
            set
            {
                if (i == 0)
                    x = value;
                else if (i == 1)
                    y = value;
                else
                    z = value;
            }
        }

        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            Vec3 p = new Vec3();
            p[0] = a[0] + b[0];
            p[1] = a[1] + b[1];
            p[2] = a[2] + b[2];
            return p;
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            Vec3 v = new Vec3();
            v[0] = a[0] - b[0];
            v[1] = a[1] - b[1];
            v[2] = a[2] - b[2];
            return v;
        }

        public static Vec3 operator *(Vec3 a, float index)
        {
            Vec3 p = new Vec3();
            p[0] = a[0] * index;
            p[1] = a[1] * index;
            p[2] = a[2] * index;
            return p;
        }
        public static Vec3 operator *(float index, Vec3 a)
        {
            Vec3 p = new Vec3();
            p[0] = a[0] * index;
            p[1] = a[1] * index;
            p[2] = a[2] * index;
            return p;
        }

        public static Vec3 operator /(Vec3 a, float index)
        {
            if (index == 0)
            {
                //报错
            }
            float inv = 1 / index;
            Vec3 p = new Vec3();
            p[0] = a[0] * inv;
            p[1] = a[1] * inv;
            p[2] = a[2] * inv;
            return p;
        }

        public float length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public void normalize()
        {
            float i = length();
            if (i == 0)
            {
                // 报错
            }
            float inv = 1 / i;
            x = x * inv;
            y = y * inv;
            z = z * inv;
        }

        public static float dot(Vec3 a, Vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vec3 cross(Vec3 a, Vec3 b)
        {
            return new Vec3((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x));
        }

    }

    public class Normal
    {
        public float x, y, z;
        public Normal()
        {
            x = 0.0f;
            y = 1.0f;
            z = 0.0f;
        }
        public Normal(float _x,float _y,float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    public class Point2
    {
        public float x, y;
        public Point2()
        {
            x = y = 0.0f;
        }
        public Point2(float _x,float _y)
        {
            x = _x;
            y = _y;
        }
    }

    public class Point3
    {
        public float x, y, z;
        public Point3()
        {
            x = y = z = 0;
        }
        public Point3(float a, float b, float c)
        {
            x = a;
            y = b;
            z = c;
        }
        public Point3(Point3 point)
        {
            x = point.x;
            y = point.y;
            z = point.z;
        }
        public Point3(Vec3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        public float this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                else if (i == 1)
                    return y;
                else
                    return z;
            }
            set
            {
                if (i == 0)
                    x = value;
                else if (i == 1)
                    y = value;
                else
                    z = value;
            }
        }
        public static Point3 operator +(Point3 a, Vec3 b)
        {
            Point3 p = new Point3();
            p[0] = a[0] + b[0];
            p[1] = a[1] + b[1];
            p[2] = a[2] + b[2];
            return p;
        }
        public static Point3 operator -(Point3 a, Vec3 b)
        {
            Point3 p = new Point3();
            p[0] = a[0] - b[0];
            p[1] = a[1] - b[1];
            p[2] = a[2] - b[2];
            return p;
        }

        public static Vec3 operator -(Point3 a, Point3 b)
        {
            Vec3 v = new Vec3();
            v[0] = a[0] - b[0];
            v[1] = a[1] - b[1];
            v[2] = a[2] - b[2];
            return v;
        }

        public static Point3 operator *(Point3 a, float index)
        {
            Point3 p = new Point3();
            p[0] = a[0] * index;
            p[1] = a[1] * index;
            p[2] = a[2] * index;
            return p;
        }

        public static Point3 operator /(Point3 a, float index)
        {
            if (index == 0)
            {
                //报错
            }
            float inv = 1 / index;
            Point3 p = new Point3();
            p[0] = a[0] / index;
            p[1] = a[1] / index;
            p[2] = a[2] / index;
            return p;
        }

    }

    public class Vec4
    {
        public Vec4()
        {
            x = y = z = w = 0;
        }
        public Vec4(float a, float b, float c, float d)
        {
            x = a;
            y = b;
            c = z;
            d = w;
        }
        public Vec4(Vec4 v1)
        {
            x = v1.x;
            y = v1.y;
            z = v1.z;
            w = v1.w;
        }
        public float this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                else if (i == 1)
                    return y;
                else if (i == 2)
                    return z;
                else if (i == 3)
                    return w;
                else
                    return 0; // 这里是报错

            }
            set
            {
                if (i == 0)
                    x = value;
                else if (i == 1)
                    y = value;
                else if (i == 2)
                    z = value;
                else if (i == 3)
                    w = value;
                else
                    return; // 这里其实应该是一句报错的语句
            }
        }
        public static Vec4 operator +(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);

        }
        public static Vec4 operator -(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }
        public static Vec4 operator *(Vec4 v1, Vec4 v2)
        {
            return new Vec4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        }
        public static Vec4 operator /(Vec4 v1, Vec4 v2)
        {
            if (v2.x == 0 || v2.y == 0 || v2.z == 0 || v2.w == 0)
            {
                //报错
            }
            return new Vec4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);
        }
        public static float dot(Vec4 v1, Vec4 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w;
        }

        //public static Vec4 operator*(Transform t,Vec4 v)
        //{
        //    Vec4 result = new Vec4();

        //}

        public float x, y, z, w;
    }

    public class Mat4
    {
        float[,] a = new float[4, 4];
        public Mat4(Vec4 v, Vec4 b, Vec4 c, Vec4 d)
        {
            for (int i = 0; i < 4; ++i)
            {
                a[i, 0] = v[i];
                a[i, 1] = b[i];
                a[i, 2] = c[i];
                a[i, 3] = d[i];
            }
        }

        public Mat4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12,
            float m13, float m14, float m15, float m16)
        {
            a[0, 0] = m1;
            a[0, 1] = m2;
            a[0, 2] = m3;
            a[0, 3] = m4;
            a[1, 0] = m5;
            a[1, 1] = m6;
            a[1, 2] = m7;
            a[1, 3] = m8;
            a[2, 0] = m9;
            a[2, 1] = m10;
            a[2, 2] = m11;
            a[2, 3] = m12;
            a[3, 0] = m13;
            a[3, 1] = m14;
            a[3, 2] = m15;
            a[3, 3] = m16;
        }

        public Mat4()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                        a[i, j] = 1;
                    else
                        a[i, j] = 0;
                    ;
                }
            }
        }

        public Mat4(float[] numbers)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    a[i, j] = numbers[4 * i + j];
                }
            }
        }

        Mat4(Vec4[] vecs)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    a[i, j] = vecs[i][j];
                }
            }
        }

        public float this[int i, int j]
        {
            get
            {
                return a[i, j];
            }
            set
            {
                a[i, j] = value;
            }
        }

        public Vec4 row(int i)
        {
            return new Vec4(a[i, 0], a[i, 1], a[i, 2], a[i, 3]);
        }

        public Vec4 column(int j)
        {
            return new Vec4(a[0, j], a[1, j], a[2, j], a[3, j]);
        }

        public static Mat4 operator +(Mat4 a, Mat4 b)
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 0; ++j)
                {
                    mat[i, j] = a[i, j] + b[i, j];
                }
            }
            return mat;
        }

        public static Mat4 operator -(Mat4 a, Mat4 b)
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 0; ++j)
                {
                    mat[i, j] = a[i, j] - b[i, j];
                }
            }
            return mat;
        }

        public static Mat4 operator *(Mat4 a, Mat4 b)
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    mat[i, j] = Vec4.dot(a.row(i), b.column(j));
                }
            return mat;
        }

        public static Mat4 operator *(Mat4 a, float b)
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    mat[i, j] *= b;
                }
            }
            return mat;
        }

        public static Mat4 operator /(Mat4 a, float b)
        {
            Mat4 mat = new Mat4();
            if (b == 0)
            {
                //报错
            }
            float inv = 1 / b;
            mat = a * inv;
            return mat;
        }

        public static Mat4 operator *(float b, Mat4 a)
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    mat[i, j] *= b;
                }
            }
            return mat;
        }

        public static Vec4 operator *(Mat4 a, Vec4 v)
        {
            Vec4 result = new Vec4();
            for (int i = 0; i < 4; ++i)
            {
                result[i] = Vec4.dot(a.row(i), v);
            }
            return result;
        }

        public static Vec4 operator *(Vec4 v, Mat4 a)
        {
            Vec4 result = new Vec4();
            for (int i = 0; i < 4; ++i)
            {
                result[i] = Vec4.dot(a.column(i), v);
            }
            return result;
        }

        public Mat4 transpose()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = i; j < 4; ++j)
                {
                    a[i, j] = a[i, j] + a[j, i];
                    a[j, i] = a[i, j] - a[j, i];
                    a[i, j] -= a[j, i];
                }
            }
            return this;
        }

        public Mat4 getTranspose()
        {
            Mat4 mat = new Mat4();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    mat[i, j] = a[j, i];
                }
            }
            return mat;
        }

        public Mat4 inverse()
        {
            Mat4 mat = this.getInverse();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    a[i, j] = mat[i, j];
                }
            }
            return this;
        }

        public Mat4 getInverse()
        {
            float f01 = a[2, 2] * a[3, 3] - a[2, 3] * a[3, 2];
            float f02 = a[2, 3] * a[3, 1] - a[2, 1] * a[3, 3];
            float f03 = a[2, 1] * a[3, 2] - a[2, 2] * a[3, 1];
            float f04 = a[2, 3] * a[3, 0] - a[2, 0] * a[3, 3];
            float f05 = a[2, 0] * a[3, 2] - a[2, 2] * a[3, 0];
            float f06 = a[2, 0] * a[3, 1] - a[2, 1] * a[3, 0];
            float f07 = a[2, 3] * a[3, 1] - a[2, 1] * a[3, 3];
            float f08 = a[1, 2] * a[3, 3] - a[1, 3] * a[3, 2];
            float f09 = a[1, 3] * a[3, 1] - a[1, 1] * a[3, 3];
            float f10 = a[1, 1] * a[3, 2] - a[1, 2] * a[3, 1];
            float f11 = a[1, 3] * a[3, 0] - a[1, 0] * a[3, 3];
            float f12 = a[1, 0] * a[3, 2] - a[1, 2] * a[3, 0];
            float f13 = a[1, 0] * a[3, 1] - a[1, 1] * a[3, 0];
            float f14 = a[1, 2] * a[2, 3] - a[1, 3] * a[2, 2];
            float f15 = a[1, 3] * a[2, 1] - a[1, 1] * a[2, 3];
            float f16 = a[1, 1] * a[2, 2] - a[1, 2] * a[2, 1];
            float f17 = a[1, 3] * a[2, 0] - a[1, 0] * a[2, 3];
            float f18 = a[1, 0] * a[2, 2] - a[1, 2] * a[2, 0];
            float f19 = a[1, 0] * a[2, 1] - a[1, 1] * a[2, 0];

            Mat4 adjoint = new Mat4();
            adjoint[0, 0] = a[1, 1] * f01 + a[1, 2] * f02 + a[1, 3] * f03;
            adjoint[1, 0] = -(a[1, 0] * f01 + a[1, 2] * f04 + a[1, 3] * f05);
            adjoint[2, 0] = a[1, 0] * -f02 + a[1, 1] * f04 + a[1, 3] * f06;
            adjoint[3, 0] = -(a[1, 0] * f03 + a[1, 1] * -f05 + a[1, 2] * f06);
            adjoint[0, 1] = -(a[0, 1] * f01 + a[0, 2] * f07 + a[0, 3] * f03);
            adjoint[1, 1] = a[0, 0] * f01 + a[0, 2] * f04 + a[0, 3] * f05;
            adjoint[2, 1] = -(a[0, 0] * -f07 + a[0, 1] * f04 + a[0, 3] * f06);
            adjoint[3, 1] = a[0, 0] * f03 + a[0, 1] * -f05 + a[0, 2] * f06;
            adjoint[0, 2] = a[0, 1] * f08 + a[0, 2] * f09 + a[0, 3] * f10;
            adjoint[1, 2] = -(a[0, 0] * f08 + a[0, 2] * f11 + a[0, 3] * f12);
            adjoint[2, 2] = a[0, 0] * -f09 + a[0, 1] * f11 + a[0, 3] * f13;
            adjoint[3, 2] = -(a[0, 0] * f10 + a[0, 1] * -f12 + a[0, 2] * f13);
            adjoint[0, 3] = -(a[0, 1] * f14 + a[0, 2] * f15 + a[0, 3] * f16);
            adjoint[1, 3] = a[0, 0] * f14 + a[0, 2] * f17 + a[0, 3] * f18;
            adjoint[2, 3] = -(a[0, 0] * -f15 + a[0, 1] * f17 + a[0, 3] * f19);
            adjoint[3, 3] = a[0, 0] * f16 + a[0, 1] * -f18 + a[0, 2] * f19;
            float det = a[0, 0] * adjoint[0, 0] + a[0, 1] * adjoint[1, 0] + a[0, 2] * adjoint[2, 0] + a[0, 3] * adjoint[3, 0];
            float invdet = 1.0f / det;
            return adjoint * invdet;

        }
    }

    public class Quaternion
    {
        public Vec3 imaginaryPart = new Vec3();
        public float realPart;
        public Quaternion()
        {
            imaginaryPart.x = 0.0f;
            imaginaryPart.y = 0.0f;
            imaginaryPart.z = 1.0f;
            realPart = 0.0f;
        }

        public Quaternion(Vec3 axis, float theta)
        {
            axis.normalize();
            imaginaryPart = (float)Math.Sin(0.5f * theta) * axis;
            realPart = (float)Math.Cos(0.5f * theta);
        }
        public Quaternion(float x,float y,float z,float w)
        {
            imaginaryPart = new Vec3(x, y, z);
            realPart = w;
        }

        public Quaternion(Vec3 v)
        {
            imaginaryPart.x = v.x;
            imaginaryPart.y = v.y;
            imaginaryPart.z = v.z;
            realPart = 0.0f;
        }
        public Quaternion(Point3 p)
        {
            imaginaryPart.x = p.x;
            imaginaryPart.y = p.y;
            imaginaryPart.z = p.z;
            realPart = 0.0f;
        }

        public Quaternion inv()
        {
            return new Quaternion(-imaginaryPart.x, -imaginaryPart.y, -imaginaryPart.z,realPart);
        }
        public static Quaternion operator *(Quaternion q, Quaternion p)
        {
            Quaternion temp = new Quaternion();
            temp.imaginaryPart = q.realPart * p.imaginaryPart + p.realPart * q.imaginaryPart + Vec3.cross(q.imaginaryPart, p.imaginaryPart);
            temp.realPart = q.realPart* p.realPart - Vec3.dot(q.imaginaryPart, p.imaginaryPart);
            return temp;
        }
        public static Quaternion operator *(Quaternion q, Point3 _p)
        {
            Quaternion p = new Quaternion(_p);
            Quaternion result = q * p;
            return result;
        }
        public void rotatePoint(ref Point3 p)
        {
            Quaternion temp= this * p * this.inv();
            p = new Point3(temp.imaginaryPart);
        }

    }

    public class Transform
    {
        Transform()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) m[i, j] = 1.0f;
                    else m[i, j] = 0.0f;
                }
            }
        }
        Transform(Mat4 m1)
        {
            m = m1;
            inv = m.getInverse();
        }

        public static Transform translate(Vec3 vector)
        {
            Mat4 mat = new Mat4();
            mat[0, 3] = vector.x;
            mat[1, 3] = vector.y;
            mat[2, 3] = vector.z;
            return new Transform(mat);
        }

        public static Transform rorate_x(float degree)
        {
            Mat4 mat = new Mat4();
            float cosa = (float)Math.Cos(degree);
            float sina = (float)Math.Sin(degree);
            mat[1, 2] = -sina;
            mat[1, 1] = cosa;
            mat[2, 1] = sina;
            mat[2, 2] = cosa;

            return new Transform(mat);
        }

        public static Transform rotate_y(float degree)
        {
            Mat4 mat = new Mat4();
            float cosa = (float)Math.Cos(degree);
            float sina = (float)Math.Sin(degree);
            mat[1, 2] = -sina;
            mat[1, 1] = cosa;
            mat[2, 1] = sina;
            mat[2, 2] = cosa;
            return new Transform(mat);
        }

        public static Transform rotate_z(float degree)
        {
            Mat4 mat = new Mat4();
            float cosa = (float)Math.Cos(degree);
            float sina = (float)Math.Sin(degree);
            mat[0, 0] = cosa;
            mat[0, 1] = -sina;
            mat[1, 0] = sina;
            mat[1, 1] = cosa;

            return new Transform(mat);
        }

        public static Transform rotate(Vec3 axis, float degree)
        {
            axis.normalize();
            Mat4 m1 = new Mat4();
            float cosa = (float)Math.Cos(degree);
            float sina = (float)-Math.Sin(degree);
            float ncosa = 1 - cosa;
            float xy = axis.x * axis.y;
            float xz = axis.x * axis.z;
            float yz = axis.y * axis.z;
            m1[0, 0] = cosa + (axis.x * axis.x) * ncosa;
            m1[0, 1] = xy * ncosa - axis.z * sina;
            m1[0, 2] = xz * ncosa + axis.y * sina;
            m1[0, 3] = 0;
            m1[1, 0] = xy * ncosa + axis.z * sina;
            m1[1, 1] = cosa + axis.y * axis.y * ncosa;
            m1[1, 2] = yz * ncosa - axis.x * sina;
            m1[1, 3] = 0;
            m1[2, 0] = xz * ncosa - axis.y * sina;
            m1[2, 1] = yz * ncosa + axis.x * sina;
            m1[2, 2] = axis.z * axis.z * ncosa + cosa;
            m1[2, 3] = 0;
            m1[3, 0] = 0;
            m1[3, 1] = 0;
            m1[3, 2] = 0;
            m1[3, 3] = 1;

            return new Transform(m1);
        }

        public static Transform scale(float x, float y, float z)
        {
            Mat4 mat = new Mat4();
            mat[0, 0] = x;
            mat[1, 1] = y;
            mat[2, 2] = z;
            return new Transform(mat);
        }


        /// <summary>
        /// 这个主要是用于将局部坐标系转到世界坐标系
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="x">局部坐标系x轴对应的世界坐标系的坐标</param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Transform toWorld(Point3 pos, Vec3 x, Vec3 y, Vec3 z)
        {
            Vec4[] r = new Vec4[3];
            Vec4[] t = new Vec4[3];
            t[0] = new Vec4(1, 0, 0, pos[0]);
            t[1] = new Vec4(0, 1, 0, pos[1]);
            t[2] = new Vec4(0, 0, 1, pos[2]);
            r[0] = new Vec4(x.x, x.y, x.z, 0);
            r[1] = new Vec4(y.x, y.y, y.z, 0);
            r[2] = new Vec4(z.x, z.y, z.z, 0);
            Mat4 rotate = new Mat4(r[0], r[1], r[2], new Vec4(0, 0, 0, 1));
            Mat4 translate = new Mat4(t[0], t[1], t[2], new Vec4(0, 0, 0, 1));
            Mat4 m = rotate.transpose() * translate;
            return new Transform(m);
        }

        public static Transform operator *(Transform a, Transform b)
        {
            Mat4 m1 = a.m * b.m;
            return new Transform(m1);
        }

        public static Point3 operator *(Transform a, Point3 p)
        {
            Vec4 v = new Vec4(p.x, p.y, p.z, 1);
            Vec4 result = a.m * v;
            if (result.w == 0)
            {
                //报错
                return new Point3();
            }
            else
            {
                float inv = 1 / result.w;
                return new Point3(result.x * inv, result.y * inv, result.z * inv);
            }
        }

        public static Vec3 operator *(Transform a, Vec3 v)
        {
            Vec4 v1 = new Vec4(v.x, v.y, v.z, 0);
            Vec4 result = a.m * v1;
            return new Vec3(result.x, result.y, result.z);
        }

        public Transform inverse()
        {
            Mat4 temp = m;
            m = inv;
            inv = temp;
            return this;
        }

        public Transform getInverse()
        {
            return new Transform(inv);
        }


        Mat4 m, inv;
    }

    public class Ray
    {
        public Ray()
        {
            origin = new Point3(0, 0, 0);
            direction = new Vec3(0, 0, -1);
        }
        public Ray(Point3 _origin, Vec3 _direction)
        {
            origin = _origin;
            direction = _direction;
        }
        public Point3 origin;
        public Vec3 direction;
        public Vec3 normal;
        public float t;
        public void GetEndPoint()
        {
            origin = origin + t * direction;
        }
    }

    public enum Sampler
    {
        regular
    }

    public class Camera
    {
        public float rotateScale = 0.005f;
        public float moveScale = 0.1f;
        public Point3 position;
        public Vec3 forward;
        public Vec3 right;
        public Vec3 up;
        public float phi = (float)Math.PI;
        public float theta = 0.5f * (float)Math.PI;
        public Quaternion rotation=new Quaternion();
        public float fov = (1.0f / 3.0f) * CommonInfo.PI;
        public float aspectRatio = 16.0f / 9.0f;
        public float viewDistance = 5.0f;
        Sampler sampler = Sampler.regular;
        public Camera()
        {
            position = new Point3();
            forward = new Vec3(0, 0, -1);
            right = new Vec3(1, 0, 0);
            up = new Vec3(0, 1, 0);
            aspectRatio = (float)CommonInfo.Width / (float)CommonInfo.Heght;
        }
        public void Update(ref CommonInfo commonInfo)
        {
            aspectRatio = (float)CommonInfo.Width / (float)CommonInfo.Heght;

            phi = -rotateScale * commonInfo.accumulatedX + (float)Math.PI;
            theta = rotateScale * commonInfo.accumulatedY + 0.5f * (float)Math.PI;
            if (theta <= 0.00001f)
            {
                theta = 0.00001f;
                commonInfo.accumulatedY = -(int)((0.5f * CommonInfo.PI)/rotateScale);
            }
            else if (theta >= CommonInfo.PI)
            {
                theta = CommonInfo.PI;
                commonInfo.accumulatedY = (int)((0.5f * (float)CommonInfo.PI) / rotateScale);
            }
            forward = new Vec3((float)(Math.Sin(theta) * Math.Sin(phi)), (float)(Math.Cos(theta)), (float)(Math.Sin(theta) * Math.Cos(phi)));
            right = new Vec3(Vec3.cross(new Vec3(forward.x, 0, forward.z), forward));
            right.normalize();

            Quaternion rotationPhi = new Quaternion(new Vec3(0.0f, 1.0f, 0.0f), phi);
            float axisTheta = phi + 0.5f * (float)Math.PI;
            Vec3 rotateThetaAxis = new Vec3((float)Math.Sin(axisTheta), 0.0f, (float)Math.Cos(axisTheta));
            Quaternion rotationTheta = new Quaternion(rotateThetaAxis, theta);
            rotation = rotationTheta*rotationPhi;
        }
        public void MoveForward()
        {
            position += moveScale * forward;
        }
        public void MoveBack()
        {
            position -= moveScale * forward;

        }
        public void MoveLeft()
        {
            position -= moveScale * right;
        }
        public void MoveRight()
        {
            position += moveScale * right;
        }
        public void SendToCuda()
        {
            CudaUtil.SendCamera(
                position.x, position.y, position.z,
                rotation.imaginaryPart.x, rotation.imaginaryPart.y, rotation.imaginaryPart.z, rotation.realPart,
                fov, aspectRatio, viewDistance, (int)Sampler.regular);
        }
    }

    public class CommonInfo
    {
        public static readonly float PI = 3.14158f;

        public bool swampIdx = false;

        public bool isInitialized = false;
        public bool isPressingMouseLeft = false;

        public int currentMouseX = 0;
        public int currentMouseY = 0;
        public int lastMouseX = 0;
        public int lastMouseY = 0;
        public int accumulatedX = 0;
        public int accumulatedY = 0;
        //public int mouseX = 0;
        //public int mouseY = 0;

        public Scene scene;

        public static int Width;
        public static int Heght;
        public System.Drawing.Bitmap frameBuffer0;
        public System.Drawing.Bitmap frameBuffer1;
        public System.Drawing.Bitmap pickingBuffer;
        
        public System.Drawing.Imaging.BitmapData frame_buffer0_data;
        public System.Drawing.Imaging.BitmapData frame_buffer1_data;
        public System.Drawing.Imaging.BitmapData picking_buffer_data;

        public string DebugInfo;
        //public CommonInfo()
        //{
        //    Width = 1280;
        //    Heght = 720;
        //    scene = new Scene();
        //    frameBuffer0 = new System.Drawing.Bitmap(Width, Heght, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    frameBuffer1 = new System.Drawing.Bitmap(Width, Heght, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    pickingBuffer = new System.Drawing.Bitmap(Width, Heght, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        //    frame_buffer0_data = frameBuffer0.LockBits(new System.Drawing.Rectangle(0, 0, frameBuffer0.Width, frameBuffer0.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    frame_buffer1_data = frameBuffer1.LockBits(new System.Drawing.Rectangle(0, 0, frameBuffer1.Width, frameBuffer1.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    picking_buffer_data = pickingBuffer.LockBits(new System.Drawing.Rectangle(0, 0, pickingBuffer.Width, pickingBuffer.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //}
        public CommonInfo(int width, int height)
        {
            Width = width;
            Heght = height;
            scene = new Scene();
            frameBuffer0 = new System.Drawing.Bitmap(Width, Heght,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            frameBuffer1 = new System.Drawing.Bitmap(Width, Heght, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pickingBuffer = new System.Drawing.Bitmap(Width, Heght, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            frame_buffer0_data = frameBuffer0.LockBits(new System.Drawing.Rectangle(0, 0, frameBuffer0.Width, frameBuffer0.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            frame_buffer1_data = frameBuffer1.LockBits(new System.Drawing.Rectangle(0, 0, frameBuffer1.Width, frameBuffer1.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            picking_buffer_data = pickingBuffer.LockBits(new System.Drawing.Rectangle(0, 0, pickingBuffer.Width, pickingBuffer.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

    }
    #endregion
    #region Materials
    public class BRDF
    {

    }
    public class Material
    {

    }
    public class Texture
    {

    }
    public class Color
    {
        public Color()
        {
            r = g = b = 0.0f;
            a = 1.0f;
        }
        public Color(float _r,float _g,float _b,float _a)
        {
            r = _r;
            g = _g;
            b = _b;
            a = _a;
        }
        public float r = 0.0f, g = 0.0f, b = 0.0f, a = 0.0f;
        public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    
    #endregion
    #region Primitives
    public abstract class Primitive
    {
        public Point3 centre;
        public Color materialColor;
        public Primitive_type type = Primitive_type.Default;
        public Primitive()
        {
            centre = new Point3();
            materialColor = new Color();
        }
        public abstract bool HitTest(ref Ray ray);
        public abstract void AddToCuda();
    }

    public class Sphere : Primitive
    {
        public float radius { get; }
        public Sphere()
        {
            radius = 1;
        }
        public Sphere(Point3 _centre, float _radius)
        {
            centre = _centre;
            radius = _radius;
        }
        public Sphere(Point3 _centre, float _radius,Color _materialColor)
        {
            centre = _centre;
            radius = _radius;
            materialColor = _materialColor;
        }
        public Sphere(float cx, float cy, float cz, float _radius)
        {
            centre = new Point3(cx, cy, cz);
            radius = _radius;
        }

        public override bool HitTest(ref Ray ray)
        {
            ray.direction.normalize();
            Vec3 CO = ray.origin - centre;
            float A = Vec3.dot(ray.direction, ray.direction);
            float B = 2 * Vec3.dot(ray.direction, CO);
            float C = Vec3.dot(CO, CO) - radius * radius;
            float discriminant = B * B - 4 * A * C;

            if (discriminant > 0)
            {
                float temp = (-B - (float)Math.Sqrt(discriminant)) / (2 * A);
                if (temp < float.MaxValue && temp > 0.001)
                {
                    ray.t = temp;
                    ray.GetEndPoint();
                    ray.normal = (ray.origin - centre) / radius;
                    return true;
                }
                temp = (-B + (float)Math.Sqrt(discriminant)) / (2 * A);
                if (temp < float.MaxValue && temp > 0.001)
                {
                    ray.t = temp;
                    ray.GetEndPoint();
                    ray.normal = (ray.origin - centre) / radius;
                    return true;
                }
            }
            return false;
        }

        public override void AddToCuda()
        {
            CudaUtil.AddSphere(centre, materialColor, radius);
        }
    }
    public class Triangle : Primitive
    {
        public Point3[] points = new Point3[3];
        public Point2[] uv = new Point2[3];
        public Normal normal = new Normal();
        public Triangle(Point3[] _points,Point2[] _uv,Color _materialColor)
        {
            centre.x = (_points[0].x + _points[1].x + _points[2].x);
            centre.y = (_points[0].y + _points[1].y + _points[2].y);
            centre.z = (_points[0].z + _points[1].z + _points[2].z);
            materialColor = _materialColor;
            points[0] = _points[0];
            points[1] = _points[1];
            points[2] = _points[2];
            uv[0] = _uv[0];
            uv[1] = _uv[1];
            uv[2] = _uv[2];
        }
        public override bool HitTest(ref Ray ray)
        {
            //暂未实现
            return false;
        }
        public override void AddToCuda()
        {
            CudaUtil.AddTriangle(materialColor,points,uv);
        }
    }
    public class Plane : Primitive
    {
        public Normal normal;
        public Plane(Point3 _centre, Color _materialColor, Normal _normal)
        {
            centre = _centre;
            materialColor = _materialColor;
            normal = _normal;
        }
        public override bool HitTest(ref Ray ray)
        {
            //暂未实现
            return false;
        }
        public override void AddToCuda()
        {
            CudaUtil.AddPlane(centre, materialColor, normal);
        }
    }

    #endregion
    #region Scene
    public class Scene
    {
        public List<Primitive> primitives = new List<Primitive>();
        public int primitive_head_ptr = 0;
        public Camera camera = new Camera();

        public Scene()
        {
        }

        public void AddPrimitiveToCuda()
        {
            foreach (Primitive item in primitives)
            {
                item.AddToCuda();
            }
            camera.SendToCuda();
        }
    }

    #endregion
}
