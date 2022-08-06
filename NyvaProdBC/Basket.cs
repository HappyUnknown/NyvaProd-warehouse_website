using NyvaProdBC.Models;
using System;

namespace NyvaProdBC
{
    public static class Basket
    {
        public static SelectorPair[] BaseArray = new SelectorPair[0];
        public static void Add(SelectorPair b)
        {
            SelectorPair[] temp = new SelectorPair[BaseArray.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = BaseArray[i];
            }
            BaseArray = new SelectorPair[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                BaseArray[i] = temp[i];
            }
            BaseArray[BaseArray.Length - 1] = b;
        }
        public static string RemoveAt(int index)
        {
            int i = 0;
            int j = 0;
            try
            {
                SelectorPair[] temp = new SelectorPair[BaseArray.Length];
                for (i = 0; i < temp.Length; i++)
                    temp[i] = BaseArray[i];
                BaseArray = new SelectorPair[temp.Length - 1];
                for (j = 0; j < index; j++)
                    BaseArray[j] = temp[j];
                for (j = index + 1; j < temp.Length; j++)
                    BaseArray[j - 1] = temp[j];
            }
            catch (Exception ex)
            {
                return new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name + ", i-" + i + ", j-" + j + ", rindex-" + index + ": " + ex.Message;
            }
            return string.Empty;
        }
        public static int IndexOf(SelectorPair b)
        {
            for (int i = 0; i < BaseArray.Length; i++)
            {
                if (BaseArray[i].selector.UniqueID == b.selector.UniqueID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int IndexOfUnselector(SelectorPair b)
        {
            for (int i = 0; i < BaseArray.Length; i++)
            {
                if (BaseArray[i].selector.UniqueID == b.unselector.UniqueID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void Clear()
        {
            BaseArray = new SelectorPair[0];
        }
    }
}