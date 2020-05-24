using System;

namespace WinRTUtil
{
    public static class ConvertTo<T>
    {
        public static T From(object obj)
        {
            return (T)Activator.CreateInstance(typeof(T), obj);
        }
    }
}
