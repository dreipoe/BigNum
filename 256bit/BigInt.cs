﻿using System;

namespace BigNum
{
    public struct BigInt : IComparable<BigInt>
    {
        const byte N = 4;
        uint[] words;

        public BigInt(int v = 0)
        {
            words = new uint[N];
            words[N - 1] = (uint)v;
        }

        public static implicit operator BigInt(int v)
        {
            return new BigInt(v);
        }

        #region Implementation of operators

        public static BigInt operator ++(BigInt number)
        {
            for (int i = N - 1; i >= 0; i--)
            {
                number.words[i]++;
                if (number.words[i] != 0) break;
            }

            return number;
        }

        public static BigInt operator --(BigInt number)
        {
            for (int i = N - 1; i >= 0; i--)
            {
                number.words[i]--;
                if (number.words[i] != 0xFFFFFFFF) break;
            }

            return number;
        }

        public static BigInt operator +(BigInt a, BigInt b)
        {
            BigInt result = 0;

            for (int i = N - 1; i >= 0; i--)
            {
                result.words[i] = a.words[i] + b.words[i];
                if (result.words[i] < a.words[i])
                {
                    result.words[i - 1]++;
                }
            }

            return result;
        }

        public static BigInt operator -(BigInt a, BigInt b)
        {
            throw new NotImplementedException();
        }

        public static BigInt operator *(BigInt a, BigInt b)
        {
            throw new NotImplementedException();
        }

        public static BigInt operator /(BigInt a, BigInt b)
        {
            throw new NotImplementedException();
        }

        public static BigInt operator %(BigInt a, BigInt b)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) > 0);
        }

        public static bool operator <(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) < 0);
        }

        public static bool operator >=(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) >= 0);
        }

        public static bool operator <=(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) <= 0);
        }

        public static bool operator ==(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) == 0);
        }

        public static bool operator !=(BigInt a, BigInt b)
        {
            return (a.CompareTo(b) != 0);
        }

        #endregion

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(BigInt other)
        {
            for (int i = 0; i < N; i++)
                if (words[i] < other.words[i])
                    return -1;
                else if (words[i] > other.words[i])
                    return 1;

            return 0;
        }
    }
}
