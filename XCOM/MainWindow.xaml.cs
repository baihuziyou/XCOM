using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.IO;
using System.Text;
using System.Collections;

namespace XCOM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    delegate void Display();

    public partial class MainWindow : Window
    {
        SerialPort mySerialPort = new SerialPort();
        List<string> dataSaveList = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            #region                   //恢复之前的配置
            try                          //File.ReadAllLines如果没有这个文档会报错,所以要放在try下。恢复之前的设置
            {
                List<string> dataSaveList = new List<string>();
                dataSaveList = (File.ReadAllLines("save.txt")).ToList(); //读取save.txt中的数据，使用ToList()方法把字符串数组转换为list<>

                SerialPort serialPort = new SerialPort();
                string[] arryPort = SerialPort.GetPortNames(); //获取计算机所有的串口


                if (arryPort.Length == 0){ }
                else
                {
                    ComBox_XCOMChioce.Items.Add(dataSaveList[0]);
                    ComBox_XCOMChioce.SelectedIndex = 0;
                }
                if (ComBox_BoadRate.Text != dataSaveList[1])//如果默认的ComBox_BoadRate的文本值和保存的不一样。根据save.txt中的数据，自动把波特率给选择上，恢复了上一次关闭时候的界面
                {
                    switch (dataSaveList[1])
                    {
                        case "1200":
                            ComBox_BoadRate.SelectedIndex = 0;
                            break;
                        case "2400":
                            ComBox_BoadRate.SelectedIndex = 1;
                            break;
                        case "4800":
                            ComBox_BoadRate.SelectedIndex = 2;
                            break;
                        case "9600":
                            ComBox_BoadRate.SelectedIndex = 3;
                            break;
                        case "14400":
                            ComBox_BoadRate.SelectedIndex = 4;
                            break;
                        case "19200":
                            ComBox_BoadRate.SelectedIndex = 5;
                            break;
                        case "38400":
                            ComBox_BoadRate.SelectedIndex = 6;
                            break;
                        case "43000":
                            ComBox_BoadRate.SelectedIndex = 7;
                            break;
                        case "57600":
                            ComBox_BoadRate.SelectedIndex = 8;
                            break;
                        case "76800":
                            ComBox_BoadRate.SelectedIndex = 9;
                            break;
                        case "115200":
                            ComBox_BoadRate.SelectedIndex = 10;
                            break;
                        case "128000":
                            ComBox_BoadRate.SelectedIndex = 11;
                            break;
                        case "230400":
                            ComBox_BoadRate.SelectedIndex = 12;
                            break;
                        case "256000":
                            ComBox_BoadRate.SelectedIndex = 13;
                            break;
                        case "460800":
                            ComBox_BoadRate.SelectedIndex = 14;
                            break;
                        default:
                            break;
                    }
                }
                else//如果和默认的保持一样的话就不用修改了
                { }

                if (ComBox_StopBits.Text != dataSaveList[2])//如果save.txt中的数据（上次点击保存进去的数据）与系统默认设置的停止位不一样时 执行
                {
                    switch (dataSaveList[2])       //根据date.txt中的值来选择ComBox_StopBits中的选项
                    {
                        case "1":
                            ComBox_StopBits.SelectedIndex = 0;
                            break;
                        case "1.5":
                            ComBox_StopBits.SelectedIndex = 1;
                            break;
                        case "2":
                            ComBox_StopBits.SelectedIndex = 2;
                            break;
                        default:
                            break;
                    }
                }
                else
                { }

                if (ComBox_DataBits.Text != dataSaveList[3])//同理恢复上一次设置的“数据位”
                {
                    switch (dataSaveList[3])
                    {
                        case "8":
                            ComBox_DataBits.SelectedIndex = 0;
                            break;
                        case "7":
                            ComBox_DataBits.SelectedIndex = 1;
                            break;
                        case "6":
                            ComBox_DataBits.SelectedIndex = 2;
                            break;
                        case "5":
                            ComBox_DataBits.SelectedIndex = 3;
                            break;
                        default:
                            break;
                    }
                }
                else
                { }

                if (ComBox_Parity.Text != dataSaveList[4])
                {
                    switch (dataSaveList[4])
                    {
                        case "无":
                            ComBox_Parity.SelectedIndex = 0;
                            break;
                        case "奇校验":
                            ComBox_Parity.SelectedIndex = 1;
                            break;
                        case "偶校验":
                            ComBox_Parity.SelectedIndex = 2;
                            break;
                        default:
                            break;
                    }
                }
                else
                { }

                //打开串口 按钮如果上次的配置是打开串口后就直接关闭，再次打开就是恢复打开串口这个操作，也就是去调用Button_OpenXCOMClick（）这个事件即可
                if (Button_OpenXCOM.Content as string != dataSaveList[5])
                {
                    if (Button_OpenXCOM.Content as string == "打开串口")
                    {
                        Button_OpenXCOMClick(new object(), new EventArgs());
                    }
                }
                else
                { }

            }
            catch
            {
                MessageBox.Show("不能恢复上一次保存的设置");
            }
            #endregion  
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);//串口接受到数据后就会触发这个事件ReceiveData。就去这个函数里面执行相关代码了
        }



        //选择串口 这个ComBox单击时的事件,把计算机端口读出来并给ComBox赋上
        public void ComBox_XCOMChioceClick(object o, EventArgs e)
        {
            SerialPort serialPort = new SerialPort();
            string[] arryPort = SerialPort.GetPortNames(); //获取计算机所有的串口
            if (arryPort.Length == 0)                      //没有就打出"没有可用的串口"的消息
            {
                MessageBox.Show("没有可用的串口");
                ComBox_XCOMChioce.Items.Clear();
            }
            else                                          //有的话就把串口的名称依次加到ComBox_XCOMChioce中,这样ComBox_XCOMChioce这个里面就有可选项了
            {
                foreach (var item in arryPort)
                {
                    int time = 0;                          //用于确保一个for循环只添加一次
                    var i = ComBox_XCOMChioce.Items.Count;  //一开始ComBox_XCOMChioce这个ComBox是没有设置的所以肯定是0开始,（我没有给他设置任何的items,是动态添加的）下次单击时候ComBox_XCOMChioce这个里就有item了,避免单机一次出现一个重复的COM口
                    for (; i < arryPort.Length; i++)        //使用for循环是为了再一次点击ComBox_XCOMChioce的时候不会重复添加
                    {
                        time++;
                        if (time == 1)
                        {
                            ComBox_XCOMChioce.Items.Add(item);
                        }
                    }
                }
            }

        }

        //打开串口 这个按钮单击时的事件,把背景切换,按钮中的类容改为关闭串口。并给mySeiralPort赋值，并进行打开，关闭操作
        public void Button_OpenXCOMClick(object o, EventArgs e)
        {

            SerialPort serialPort = new SerialPort();
            string[] arryPort = SerialPort.GetPortNames(); //动态获取计算机的串口端口，并把它的名字存放在arryPort数组中
            if (arryPort.Length == 0)                      //如果数组的长度为0，也就是代表计算机没有可用的串口打开 
            {
                MessageBox.Show("没有可用的串口");
            }
            else                                          //否则就是计算机有可用的串口
            {
                if ((ComBox_XCOMChioce.SelectedItem) == null)  //判断串口选择处有没有选中串口了，==null就是没有选择串口
                {
                    MessageBox.Show("请选择串口");
                }

                else                                           //串口已经选择了
                {
                    if ((Button_OpenXCOM.Content as string) == "打开串口")  //根据打开串口的文本的内容判断处于什么状态
                    {
                        mySerialPort.PortName = ComBox_XCOMChioce.Text;     //把串口选择下拉组合钮的选中的值赋给mySerialPort
                        mySerialPort.BaudRate = Convert.ToInt32(ComBox_BoadRate.Text);            //串口的波特率赋值为下拉按扭组合中的选中项
                        mySerialPort.DataBits = Convert.ToInt32(ComBox_DataBits.Text);            //串口的停止位赋值为下拉按扭组合中的选中项
                        switch (ComBox_StopBits.Text)                              //根据下拉按钮框中的选中项给mySerialPort.StopBits赋值，不能像上面那样赋值，因为StopBits要赋的是一个枚举类型的值
                        {

                            case "1":
                                mySerialPort.StopBits = StopBits.One;
                                break;
                            case "1.5":
                                mySerialPort.StopBits = StopBits.OnePointFive;
                                break;
                            case "2":
                                mySerialPort.StopBits = StopBits.Two;
                                break;
                            default:
                                break;
                        }
                        switch (ComBox_Parity.Text)                                  //同理设置奇偶校验
                        {
                            case "无":
                                mySerialPort.Parity = Parity.None;
                                break;
                            case "奇校验":
                                mySerialPort.Parity = Parity.Odd;
                                break;
                            case "偶校验":
                                mySerialPort.Parity = Parity.Even;
                                break;
                            default:
                                break;
                        }
                        try                                                           //尝试打开串口，如果串口被其他程序占用会抛出异常会打不开
                        {
                            mySerialPort.Open();
                            Button_OpenXCOM.Background = Brushes.Red;
                            Button_OpenXCOM.Foreground = Brushes.LimeGreen;
                            Button_OpenXCOM.Content = "关闭串口";                //切换button“打开串口”中的text和颜色
                        }
                        catch
                        {
                            MessageBox.Show("无法打开串口，串口被其他程序占用");
                            ComBox_XCOMChioce.Text = null;
                        }
                    }
                    else
                    {
                        try
                        {
                            mySerialPort.Close();
                            Button_OpenXCOM.Background = Brushes.Silver;
                            Button_OpenXCOM.Foreground = Brushes.Black;
                            Button_OpenXCOM.Content = "打开串口";
                        }
                        catch
                        {
                            MessageBox.Show("无法关闭串口");
                        }
                    }
                }
            }

        }

        //清除数据 按钮单击事件,把ScrollViewer窗口中的值设为空就行
        public void Button_ClearDataClick(object o, EventArgs e)
        {
            ScrollViewer_DispalyWindow.Content = null;
        }

        //白底黑字 的选项变换时发生的事件，改变显示窗口的背景颜色
        public void CheckBox_ChangeColor(object o, EventArgs e)
        {
            if (ChcekBox_WhiteBlack.IsChecked == true)
            {

                ScrollViewer_DispalyWindow.Background = Brushes.White;
                ScrollViewer_DispalyWindow.Foreground = Brushes.Black;
            }
            else
            {
                ScrollViewer_DispalyWindow.Background = Brushes.Black;
                ScrollViewer_DispalyWindow.Foreground = Brushes.LimeGreen;
            }
        }

        //清除发送 按钮按下时的事件处理器
        public void Button_ClearSendClick(object o, EventArgs e)
        {
            TextBox_SendData.Text = null;
        }

        //发送按钮 按下时触发的事件
        public void Button_SendClick(object o, EventArgs e)
        {
            SerialPort serialPort = new SerialPort();
            string[] arryPort = SerialPort.GetPortNames();     //还是去检测计算机拥有那些串口
            if (arryPort.Length == 0)                          //计算机没有串口时显示“没有可用串口”    
            {
                ComBox_XCOMChioce.Items.Clear();
                MessageBox.Show("没有可用的串口");
            }

            else                                              //有串口时候，检擦一下打开串口按钮有没有按下
            {
                if (Button_OpenXCOM.Content as string == "打开串口")
                {
                    MessageBox.Show("请打开串口");              //没有的话显示“请打开串口”
                }
                else                                    //有串口并且，打开串口按钮按下过（代表给mySerialPort赋过值）那么就把串口打开。打开之前把串口的接受发送缓冲区清空
                {
                    mySerialPort.DiscardInBuffer();    //清除输入缓冲区，不清楚可能接受数据会有错误
                    mySerialPort.DiscardOutBuffer();   //清除输出缓冲区

                    byte[] sendByte = new byte[1];     //一个byte存一个整数
                    try
                    {
                        sendByte[0] = Byte.Parse(TextBox_SendData.Text);
                        mySerialPort.Write(sendByte, 0, 1);  //发送数据
                    }

                    catch
                    {
                        MessageBox.Show("数过大,范围-127到128");
                    }
                    
                    
                    
                }
            }

        }

        //接受数据 事件触发时执行这个函数
        public void ReceiveData(object o, SerialDataReceivedEventArgs e)
        {
            Display display = new Display(scrollDisplay);
            Dispatcher.Invoke(display);//这里是副线程无法访问主线程的ScrollViewer_DispalyWindow字段，所以要这样访问,invoke中它的参数，所以定义一个
            //Dispatcher.Invoke(() => { ScrollViewer_DispalyWindow.Content += Convert.ToString(mySerialPort.ReadByte()); });拉姆达表达式
        }

        //滚动屏的显示
        public void scrollDisplay()
        {
            ScrollViewer_DispalyWindow.Content += Convert.ToString(mySerialPort.ReadByte()+" ");

        }

        //关闭图标 单击时执行的操作
        public void Button_CloseClick(object o, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        //主窗口关闭时执行的操作
        public void MainWind_CloseClick(object o, EventArgs e)
        {
            #region//把用户的配置保存一下
            dataSaveList.Add(ComBox_XCOMChioce.Text);
            dataSaveList.Add(ComBox_BoadRate.Text);
            dataSaveList.Add(ComBox_StopBits.Text);
            dataSaveList.Add(ComBox_DataBits.Text);
            dataSaveList.Add(ComBox_Parity.Text);
            dataSaveList.Add((string)Button_OpenXCOM.Content);
            File.WriteAllLines("save.txt", dataSaveList);//写入save.txt文件中，没有会自动创建的
            #endregion
        }

    }
    
}
