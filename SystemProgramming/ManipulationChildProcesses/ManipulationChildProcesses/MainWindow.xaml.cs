using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace ManipulationChildProcesses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //объявление делегата, принимающего параметр типа Process
        delegate void ProcessDelegate(Process proc);

        //константа, идентифицирующая сообщение WM_SETTEXT
        const uint WM_SETTEXT = 0x0C;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd,
            uint Msg,
            int wParam,
            [MarshalAs(UnmanagedType.LPStr)] string lParam);

        /*список, в котором будут храниться объекты, 
         * описывающие дочерние процессы приложения*/
        List<Process> Processes = new List<Process>();

        /*счётчик запущенных процессов*/
        int Counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
        }

        /*метод, загружающий доступные исполняумые 
         * файлы из домашней директории проекта*/
        void LoadAvailableAssemblies()
        {
            //название файла сборки текущего приложения
            string except = Assembly.GetExecutingAssembly().GetName().Name;
            //получаем название файла без расширения                                                                                                                                                   
            // except =  except.Substring(0, except.IndexOf("."));
            //получаем все *.exe файлы из домашней директории
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain. BaseDirectory, "*.exe");
            foreach (var file in files)
            { 
                //получаем имя файла
                string fileName = new FileInfo(file).Name;
                /*если имя афйла не содержит имени исполняемого файла проекта, то оно добавляется в список*/
                if (fileName.IndexOf(except) == -1)
                    AvailableAssemblies.Items.Add(fileName);
            }
        }
        /*private void ChildOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("ChildOne.exe");
            process.Start();
            SendMessage(process.MainWindowHandle, 0x0C, 0, "Child window one");
        }

        private void ChildTwoButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("ChildTwo.exe");
            SendMessage(process.MainWindowHandle, 0x0C, 0, "Child window one");
            process.Start();
        }*/

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            RunProcess(AvailableAssemblies.SelectedItem.ToString());
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), Kill);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), CloseMainWindow);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), Refresh);
        }

        private void RunCalcButton_OnClick(object sender, RoutedEventArgs e)
        {
            RunProcess("calc.exe");
        }

        /*метод, запускающий процесс на исполнение и 
         * сохраняющий объект, который его описывает*/
        void RunProcess(string AssamblyName)
        {
            //запускаем процесс на соновании ичполняемого файла
            Process proc = Process.Start(AssamblyName);
            //добавляем процесс в список
            Processes.Add(proc);
            /*проверяем, стал ли созданный процесс дочерним, 
             * по отношению к текущему и, если стал, выводим MessageBox*/
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
                MessageBox.Show(proc.ProcessName + " действительно дочерний процесс текущего процесса!");
            /*указываем, что процесс должен генерировать собития*/
            proc.EnableRaisingEvents = true;
            //добавляем обработчик на событие завершения процесса
            proc.Exited += proc_Exited;
            /*устанавливаем новый текст главному окну дочернего процесса*/
            SetChildWindowText(proc.MainWindowHandle, "Chils process #" + (++Counter));
            /*проверяем, запускали ли мы экземпляр такого приложения 
             * и, елси нет, то добавляем в список запущенных приложений*/
            if (!StartedAssemblies.Items.Contains(proc.ProcessName))
                StartedAssemblies.Items.Add(proc.ProcessName);
            /*убираем приложение из списка лдоступных приложений*/
            AvailableAssemblies.Items.Remove(AvailableAssemblies.SelectedItem);
        }

        /*метод, получающий PID родительского процесса (использует WMI)*/
        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }

            return parentId;
        }

        /*метод обёртывания для отправки сообщения WM_SETTEXT*/
        void SetChildWindowText(IntPtr Handle, string text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, text);
        }

        /*обработчик события Exited класса Process*/
        void proc_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;
            //убираем процесс из списка запущенных приложений
            StartedAssemblies.Items.Remove(proc.ProcessName);
            //добавляем процесс в список доступных приложений
            AvailableAssemblies.Items.Add(proc.ProcessName);
            //убираем процесс из списка дочерних процессов
            Processes.Remove(proc);
            //уменьшаем счётчик дочерних процессов на 1
            Counter--;
            int index = 0;
            /*меняем текст для главных окон всех дочерних процессов*/
            foreach (var p in Processes)
                SetChildWindowText(p.MainWindowHandle, "Child process #" + ++index);
        }

        /*метод, котоорый выполняет проход по всем дочерним процессам с заданым 
         *именем и выполняющий для этих процессов заданый делегатом метод*/
        void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            /*оплучаем список, запущенных в операционной системе процессов*/
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (var process in processes)
                /*если PID родительского процесса равен PID текущего процесса*/
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
                    //запускаем метод
                    func(process);
        }

        void Kill(Process proc)
        {
            proc.Kill();
        }

        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        void Refresh(Process proc)
        {
            proc.Refresh();
        }

        private void StartedAssemblies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if (StartedAssemblies.SelectedItems.Count == 0)
            // {
            //     StopButton.IsEnabled = false;
            //     RefreshButton.IsEnabled = false;
            //     CloseWindowButton.IsEnabled = false;
            // }
            // else
            // {
            //     StopButton.IsEnabled = true;
            //     RefreshButton.IsEnabled = true;
            //     CloseWindowButton.IsEnabled = true;
            // }
        }

        private void AvailableAssemblies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // StartButton.IsEnabled = StartedAssemblies.SelectedItems.Count != 0;
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            foreach (var proc in Processes)
            {
                proc.Kill();
            }
        }
    }
}