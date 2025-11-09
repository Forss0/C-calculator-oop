using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyArray : IOutput, IMath, ISort
{
    private int[] arr;

    public MyArray(int[] array)
    {
        arr = array;
    }

    public void Show()
    {
        Console.WriteLine("Елементи масиву:");
        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();
    }

    public void Show(string info)
    {
        Console.WriteLine(info);
        Show();
    }

    public int Max()
    {
        int max = arr[0];
        foreach (var x in arr)
            if (x > max) max = x;
        return max;
    }

    public int Min()
    {
        int min = arr[0];
        foreach (var x in arr)
            if (x < min) min = x;
        return min;
    }

    public float Avg()
    {
        float sum = 0;
        foreach (var x in arr)
            sum += x;
        return sum / arr.Length;
    }

    public bool Search(int valueToSearch)
    {
        foreach (var x in arr)
            if (x == valueToSearch)
                return true;
        return false;
    }

    public void SortAsc()
    {
        Array.Sort(arr);
    }

    public void SortDesc()
    {
        Array.Sort(arr);
        Array.Reverse(arr);
    }

    public void SortByParam(bool isAsc)
    {
        if (isAsc)
            SortAsc();
        else
            SortDesc();
    }
}