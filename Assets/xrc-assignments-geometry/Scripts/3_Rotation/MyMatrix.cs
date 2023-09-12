using UnityEngine;
using System;


namespace XRC.Assignments.Geometry
{
    public class MyMatrix
    {
        private float[] m_Values;
        private int m_Rows;
        private int m_Cols;

        public enum RotationType
        {
            Pitch,
            Yaw,
            Roll
        }

        public MyMatrix(int r, int c)
        {
            m_Rows = r;
            m_Cols = c;
            m_Values = new float[m_Rows * m_Cols];
        }


        /// <summary>
        /// Get the value at row r (start from zero), column c (start from zero)
        /// </summary>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <returns></returns>
        public float GetValue(int r, int c)
        {
            float value = m_Values[r * m_Cols + c];
            return value;
        }

        public void SetValues(float[] v)
        {
            Array.Copy(v, m_Values, m_Rows * m_Cols);
        }

        public float[] GetValues()
        {
            return m_Values;
        }

        /// <summary>
        /// CalculateMatrix multiplication
        /// </summary>
        /// <param name="a">CalculateMatrix A</param>
        /// <param name="b">CalculateMatrix B</param>
        /// <returns></returns>
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.m_Cols != b.m_Rows)
                return null;

            MyMatrix result = new MyMatrix(a.m_Rows, b.m_Cols);
            float[] resultValues = new float[a.m_Rows * b.m_Cols];

            for (int i = 0; i < a.m_Rows; i++)
            {
                for (int j = 0; j < b.m_Cols; j++)
                {
                    float sum = 0.0f;
                    for (int k = 0; k < a.m_Cols; k++)
                    {
                        sum += a.GetValue(i, k) * b.GetValue(k, j);
                    }
                    resultValues[i * b.m_Cols + j] = sum;
                }
            }

            result.SetValues(resultValues);
            return result;
        }

            /// <summary>
            /// This helper function should return the standard yaw, pitch, or roll matrix (3x3) 
            /// </summary>
            /// <param name="angle">Angle in radians</param>
            /// <param name="type"></param>
            /// <returns></returns>
            public static MyMatrix GetRotationMatrix(float angle, RotationType type)
            {
                MyMatrix result = new MyMatrix(3, 3);

                float[] resultValues = new float[9];

                // TODO - Calculate the result values based on the rotation type
                // <solution>
                float cos = Mathf.Cos(angle);
                float sin = Mathf.Sin(angle);
                switch (type)
                {
                    case RotationType.Roll: // Rz
                        resultValues[0] = cos;
                        resultValues[1] = -sin;
                        resultValues[2] = 0;
                        resultValues[3] = sin;
                        resultValues[4] = cos;
                        resultValues[5] = 0;
                        resultValues[6] = 0;
                        resultValues[7] = 0;
                        resultValues[8] = 1;
                        break;

                    case RotationType.Pitch: // Rx
                        resultValues[0] = 1;
                        resultValues[1] = 0;
                        resultValues[2] = 0;
                        resultValues[3] = 0;
                        resultValues[4] = cos;
                        resultValues[5] = -sin;
                        resultValues[6] = 0;
                        resultValues[7] = sin;
                        resultValues[8] = cos;
                        break;

                    case RotationType.Yaw: // Ry
                        resultValues[0] = cos;
                        resultValues[1] = 0;
                        resultValues[2] = sin;
                        resultValues[3] = 0;
                        resultValues[4] = 1;
                        resultValues[5] = 0;
                        resultValues[6] = -sin;
                        resultValues[7] = 0;
                        resultValues[8] = cos;
                        break;
                }

                // </solution>
                result.SetValues(resultValues);
                return result;
            }
        }
    }
