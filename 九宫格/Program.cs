using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 九宫格
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr=new int[9] { 1,2,3,4,5,6,7,8,9} ;
            Random ra = new Random(6);

            // 打乱数组顺序
            arr = reArrange(arr);
            //显示当前九宫格，数组中的9替换为空
            output(arr);
            int index = Array.IndexOf(arr,9);//获取9的索引，输出的时候把9换成“ ”


           var keyinput= Console.ReadKey().Key.ToString();//读取键盘输入
            string[] wasd = new string[] { "W", "A", "S", "D" };
            while (Array.IndexOf(wasd, keyinput) >= 0)//如果键盘输入的始终在 "W", "A", "S", "D"这几个按键中那就进行游戏，如果不在退出
            {
                if (keyinput == "W")//如果输入时W键，那么上移
                {
                    if (index >= 3&& index <= 8)//如果9的索引大于等于3，那么可以进行上移
                    {
                        arr = swap(arr, index, index - 3);//将数组中9的索引与9的索引-3相交换，也就是进行了上移
                        index= Array.IndexOf(arr, 9);//获取新数组中9的索引
                    }
                    Console.Clear();//情况控制台，制造刷新效果
                    output(arr);//输出数组
                    keyinput = Console.ReadKey().Key.ToString();//等待接收新的键盘输入命令
                } else if(keyinput == "A")
                {
                    if (index != 0&& index != 3&& index != 6)//如果索引不在0,3,6之间，说明不在最左侧的时候可以进行左移
                    {
                        arr = swap(arr, index, index - 1);//左移其实就是与索引-1相交换
                        index = Array.IndexOf(arr, 9);
                    }
                    Console.Clear();
                    output(arr);
                    keyinput = Console.ReadKey().Key.ToString();
                } else if(keyinput == "S")
                {
                    if (index <= 5&& index >= 0)// 如果索引大于5，说明在第三行，不能够下移
                    {
                        arr = swap(arr, index, index+3);
                        index = Array.IndexOf(arr, 9);
                    }
                    Console.Clear();
                    output(arr);
                    keyinput = Console.ReadKey().Key.ToString();
                }
                else
                {
                    if (index != 2 && index != 5 && index != 8)//如果索引不在2,5,8之间，说明不在最右侧的时候可以进行右移
                    {
                        arr = swap(arr, index, index +1);
                        index = Array.IndexOf(arr, 9);
                    }
                    Console.Clear();
                    output(arr);
                    keyinput = Console.ReadKey().Key.ToString();
                }
            }

            

        }
        
        //此方法用来重排数组
        public static int[] reArrange(int[] arr)
        {
            int[] newarr = new int[arr.Length];
            int k = 0;
            while (k < arr.Length)
            {
                int temp = new Random().Next(0, arr.Length);
                if (arr[temp] != 0)
                {
                    newarr[k] = arr[temp];
                    k++;
                    arr[temp] = 0;
                }
            }
            return newarr;
        }
        

        // 此方法用来输出数组，9替换成“ ”
        public static void output(int[] arr)
        {
            int index = Array.IndexOf(arr, 9);
            string[] newarr=new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newarr[i] = arr[i].ToString();
            }
            newarr[index] = " ";
            Console.WriteLine("-------");
            Console.WriteLine("|" + newarr[0] + "|" + newarr[1] + "|" + newarr[2] + "|");
            Console.WriteLine("-------");
            Console.WriteLine("|" + newarr[3] + "|" + newarr[4] + "|" + newarr[5] + "|");
            Console.WriteLine("-------");
            Console.WriteLine("|" + newarr[6] + "|" + newarr[7] + "|" + newarr[8] + "|");
            Console.WriteLine("-------");

        }

        // 此方法用来交换数组中两个索引位置的值
        public static int[] swap(int[] arr,int index1,int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return arr;
        }
    }
}
