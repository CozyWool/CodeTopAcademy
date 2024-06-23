using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using Application = System.Windows.Forms.Application;
using TreeView = System.Windows.Controls.TreeView;

namespace DirectoryViewerWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string path = Application.StartupPath;
    public MainWindow()
    {
        InitializeComponent();
        PathTextBox.Text = path;
        DirectoryInfo directoryInfo = new(path);
        DirectoryTreeView.Items.Clear();
        DirectoryTreeView.Items.Add(CreateDirectroyTreeItem(directoryInfo));
    }

    private void SelectDirectoryButton_Click(object sender, RoutedEventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        {
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
                PathTextBox.Text = path;
            }
        }
        DirectoryInfo directoryInfo = new(path);
        DirectoryTreeView.Items.Clear();
        DirectoryTreeView.Items.Add(CreateDirectroyTreeItem(directoryInfo));
    }

    private TreeViewItem CreateDirectroyTreeItem(DirectoryInfo dirInfo)
    {
        TreeViewItem DirTreeItem = new() { Header = $"{dirInfo.Name}" };
        if (dirInfo.GetDirectories().Length == 0)
        {
            foreach (var file in dirInfo.GetFiles())
            {
                var fileItem = new TreeViewItem { Header = $"{file.Name}" };
                DirTreeItem.Items.Add(fileItem);
            }
            return DirTreeItem;
        }
        foreach (var currentDir in dirInfo.GetDirectories())
        {
            var newDirItem = CreateDirectroyTreeItem(currentDir);
            foreach (var file in currentDir.GetFiles())
            {
                var fileItem = new TreeViewItem { Header = $"{file.Name}" };
                newDirItem.Items.Add(fileItem);
            }
            DirTreeItem.Items.Add(newDirItem);
        }
        return DirTreeItem;
    }
}
